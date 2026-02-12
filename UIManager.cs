using ClipManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClipManager
{
    public static class GlobalConstants
    {
        private static readonly Random _random = new();
        public static string RandomPlaceholder
        {
            get
            {
                string[] titles = DatabaseManager.GetAllTitles();
                return titles[_random.Next(titles.Length)];
            }
        }
    }
}
namespace UIManager
{
    public static class MainWindowUtils
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int CB_SETCUEBANNER = 0x1703;
        public static void SetComboBoxPlaceholderText(ComboBox comboBox, string placeholder)
        {
            if (comboBox != null)
            {
                if (placeholder == "@random")
                {
                    Random random = new Random();

                    placeholder = comboBox.Items[random.Next(0, comboBox.Items.Count)].ToString();
                }
                SendMessage(comboBox.Handle, CB_SETCUEBANNER, 0, placeholder);
            }
            
           
        }
        public static void SetRandomSearchBarPlaceholder(TextBox searchBar)
        {
            searchBar.PlaceholderText = GlobalConstants.RandomPlaceholder;
        }
        public enum SortingFilter
        {
            Name,             // A-Z
            ReverseName,      // Z-A
            Episode,          // S01E01-S08E10
            ReverseEpisode,   // S01E01-S08E10
            Characters,       // A-Z
            ReverseCharacters,// Z-A
            Duration,         // Shorter-Longer
            ReverseDuration   // Longer-Shorter
        }
        public static SortingFilter GetFilterForColumn(int column, bool reverse)
        {
            return column switch
            {
                0 => reverse ? SortingFilter.ReverseName : SortingFilter.Name,
                1 => reverse ? SortingFilter.ReverseEpisode : SortingFilter.Episode,
                2 => reverse ? SortingFilter.ReverseCharacters : SortingFilter.Characters,
                3 => reverse ? SortingFilter.ReverseDuration : SortingFilter.Duration,
                _ => SortingFilter.Name
            };
        }

        public static ListViewItem[] SortListViewItems(ListViewItem[] items, SortingFilter sortingFilter)
        {
            IEnumerable<ListViewItem> query = items;

            switch (sortingFilter)
            {
                case SortingFilter.Name:
                    query = items.OrderBy(i => i.SubItems[0].Text);
                    break;

                case SortingFilter.ReverseName:
                    query = items.OrderByDescending(i => i.SubItems[0].Text);
                    break;

                case SortingFilter.Episode:
                    query = items.OrderBy(i => StringUtils.ParseEpisode(i.SubItems[1].Text));
                    break;

                case SortingFilter.ReverseEpisode:
                    query = items.OrderByDescending(i => StringUtils.ParseEpisode(i.SubItems[1].Text));
                    break;

                case SortingFilter.Characters:
                    query = items.OrderBy(i => i.SubItems[2].Text);
                    break;

                case SortingFilter.ReverseCharacters:
                    query = items.OrderByDescending(i => i.SubItems[2].Text);
                    break;

                case SortingFilter.Duration:
                    query = items.OrderBy(i => StringUtils.ParseDuration(i.SubItems[3].Text));
                    break;

                case SortingFilter.ReverseDuration:
                    query = items.OrderByDescending(i => StringUtils.ParseDuration(i.SubItems[3].Text));
                    break;
            }

            return query.ToArray();
        }
    }
}