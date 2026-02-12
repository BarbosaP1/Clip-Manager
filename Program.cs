using Microsoft.WindowsAPICodePack.Shell;
using System.Diagnostics;
using System.IO;

namespace ClipManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ClipManager_Main());
        }
    }
    internal class FileUtils
    {
        public static bool IsVideoFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;
            string extension = Path.GetExtension(path).ToLowerInvariant();
            string[] videoExtensions = { ".mp4", ".mkv", ".avi", ".mov", ".wmv", ".flv", ".webm", ".mpeg", ".mpg", ".m4v" };
            return videoExtensions.Contains(extension);
        }
        public static Bitmap? GetVideoThumbnail(string path, int size = 256)
        {
            if (!File.Exists(path))
                return null;

            using var shellFile = ShellFile.FromFilePath(path);

            var bitmapSource = shellFile.Thumbnail.ExtraLargeBitmap;
            return bitmapSource != null ? new Bitmap(bitmapSource) : null;
        }
        public static void OpenFile(string path)
        {
            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
        }
        public static string GetFileSize(string path)
        {
            if (!File.Exists(path))
                return "0 B";

            long bytes = new FileInfo(path).Length;

            double kb = bytes / 1024.0;
            double mb = kb / 1024.0;
            double gb = mb / 1024.0;

            if (gb >= 1)
                return $"{gb:F2} GB";
            if (mb >= 1)
                return $"{mb:F2} MB";
            if (kb >= 1)
                return $"{kb:F2} KB";

            return $"{bytes} bytes";
        }
        public static void ShowFileInFolder(string path)
        {
            if (File.Exists(path))
            {
                Process.Start("explorer.exe", $"/select,\"{path}\"");
            }
        }
    }
    internal class StringUtils
    {
        public static int ExtractInt(string @string)
        {
            string digitsOnly = new string(@string.Where(c => Char.IsDigit(c)).ToArray());
            if (int.TryParse(digitsOnly, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        public static string IntToFormatedString(int i)
        {
            if (i < 10)
                return String.Concat(0, i);
            else
                return String.Concat(i);
        }
        public static int ParseEpisode(string text)
        {
            var parts = text.Replace("S", "").Split('E');

            if (parts.Length != 2)
                return 0;

            int season = int.TryParse(parts[0], out var s) ? s : 0;
            int episode = int.TryParse(parts[1], out var e) ? e : 0;

            return season * 100 + episode;
        }
        public static int ParseDuration(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var parts = text.Split(':');

            if (!parts.All(p => int.TryParse(p, out _)))
                return 0;

            return parts.Length switch
            {
                1 => int.Parse(parts[0]),
                2 => int.Parse(parts[0]) * 60 + int.Parse(parts[1]),
                3 => int.Parse(parts[0]) * 3600 +
                     int.Parse(parts[1]) * 60 +
                     int.Parse(parts[2]),
                _ => 0
            };
        }
    }
}