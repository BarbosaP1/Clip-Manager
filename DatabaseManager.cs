using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace ClipManager
{
    public static class ClipUtils
    {
        public static bool IsClipRegistered(string path)
        {
            return DatabaseManager.SearchByPath(path) != null;
        }
        public static string ClipInfoToEpisode(ClipInfo clipInfo)
        {
            return String.Concat("S", StringUtils.IntToFormatedString(clipInfo.Season), "E", StringUtils.IntToFormatedString(clipInfo.Episode));
        }
        public static ListViewItem[] ClipsToListViewItems(IEnumerable<ClipInfo> clips)
        {
            return clips.Select(clip =>
            {
                var item = new ListViewItem(new string[]
                {
                    clip.Title,
                    ClipInfoToEpisode(clip),
                    string.Join(", ", clip.Characters ?? Array.Empty<string>()),
                    GetClipDuration(clip.FilePath)
                });

                item.Tag = clip.FilePath;
                return item;

            }).ToArray();
        }
        public static string GetClipDuration(string path)
        {
            try
            {
                using (ShellObject shell = ShellObject.FromParsingName(path))
                {
                    IShellProperty prop = shell.Properties.System.Media.Duration;
                    string duration = prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
                    return duration;
                }
            }
            catch
            {
                return "--:--:--";
            }
        }
    }
    public class ClipInfo
    {
        public required string Title { get; set; }
        public required int Season { get; set; }
        public required int Episode { get; set; }
        public required string[] Characters { get; set; }
        public required string FilePath { get; set; }
    }


    public static class DatabaseManager
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "ClipManager");
        private static readonly string ClipsJsonPath = Path.Combine(BaseFolder, "clips.json");
        private static readonly string SettingsJsonPath = Path.Combine(BaseFolder, "settings.json");

        private static void EnsureDatabase()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);

            if (!File.Exists(ClipsJsonPath))
                File.WriteAllText(ClipsJsonPath, "[]");
        }

        private static List<ClipInfo>? _clipsCache;
        private static string[]? _charactersCache;
        private static string[]? _titlesCache;


        private static List<ClipInfo> LoadClips()
        {
            if (_clipsCache != null)
                return _clipsCache;

            EnsureDatabase();
            string json = File.ReadAllText(ClipsJsonPath);

            var clips = JsonSerializer.Deserialize<List<ClipInfo>>(json) ?? new List<ClipInfo>();

            var validClips = clips
                .Where(c => !string.IsNullOrWhiteSpace(c.FilePath) && File.Exists(c.FilePath))
                .ToList();

            if (validClips.Count != clips.Count)
                SaveClips(validClips);
            else
                _clipsCache = validClips;

            return _clipsCache!;
        }

        private static void SaveClips(List<ClipInfo> clips)
        {
            string json = JsonSerializer.Serialize(clips, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ClipsJsonPath, json);

            _clipsCache = clips;
            _charactersCache = null;
            _titlesCache = null;
        }

        public static void AddClip(ClipInfo clip)
        {
            var clips = LoadClips();
            clips.Add(clip);
            SaveClips(clips);
        }

        public static bool RemoveClip(ClipInfo clip)
        {
            var clips = LoadClips();

            var existing = clips.FirstOrDefault(c =>
                string.Equals(c.FilePath, clip.FilePath, StringComparison.OrdinalIgnoreCase));

            if (existing == null)
                return false;

            clips.Remove(existing);
            SaveClips(clips);

            return true;
        }
        public static bool EditClip(ClipInfo oldClip, ClipInfo newClip)
        {
            var clips = LoadClips();

            var existing = clips.FirstOrDefault(c =>
                string.Equals(c.FilePath, oldClip.FilePath, StringComparison.OrdinalIgnoreCase));

            if (existing == null)
                return false;

            existing.Title = newClip.Title;
            existing.Season = newClip.Season;
            existing.Episode = newClip.Episode;
            existing.Characters = newClip.Characters;
            existing.FilePath = newClip.FilePath;

            SaveClips(clips);
            return true;
        }

        public static List<ClipInfo> SearchByTitle(string title)
        {
            return LoadClips().Where(c => c.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<ClipInfo> SearchBySeason(int season)
        {
            return LoadClips().Where(c => c.Season == season).ToList();
        }

        public static List<ClipInfo> SearchByEpisode(int season, int episode)
        {
            return LoadClips().Where(c => c.Season == season && c.Episode == episode).ToList();
        }

        public static List<ClipInfo> SearchByCharacter(string character)
        {
            return LoadClips().Where(c => c.Characters.Any(ch => ch.Contains(character, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public static ClipInfo? SearchByPath(string path)
        {
            return LoadClips().FirstOrDefault(c => string.Equals(c.FilePath, path, StringComparison.OrdinalIgnoreCase));
        }

        public static List<ClipInfo> GetAll()
        {
            return LoadClips();
        }

        public static List<ClipInfo> GetFilteredClips(int season, int episode, string character)
        {
            IEnumerable<ClipInfo> query = LoadClips();

            if (season > 0)
                query = query.Where(c => c.Season == season);

            if (episode > 0)
                query = query.Where(c => c.Episode == episode);

            if (!string.IsNullOrWhiteSpace(character))
                query = query.Where(c => c.Characters.Any(ch =>
                    ch.Contains(character, StringComparison.OrdinalIgnoreCase)));

            return query.ToList();
        }

        public static string[] GetAllCharacters()
        {
            if (_charactersCache != null)
                return _charactersCache;

            _charactersCache = LoadClips()
                .SelectMany(c => c.Characters ?? Array.Empty<string>())
                .Where(ch => !string.IsNullOrWhiteSpace(ch))
                .Select(ch => ch.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(ch => ch)
                .ToArray();

            return _charactersCache;
        }
        public static string[] GetAllTitles()
        {
            if (_titlesCache != null)
                return _titlesCache;

            _titlesCache = LoadClips()
                .Select(c => c.Title)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Select(t => t.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(t => t)
                .ToArray();

            return _titlesCache;
        }
    }
}
