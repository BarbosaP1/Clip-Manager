using Microsoft.WindowsAPICodePack.Controls;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UIManager;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static UIManager.MainWindowUtils;

namespace ClipManager
{
    public partial class ClipManager_Main : Form
    {
        public ClipManager_Main()
        {
            InitializeComponent();
        }

        private SortingFilter _currentSort = SortingFilter.Name;
        private int _lastColumn = -1;
        private bool wasLastSearchWhiteOrNull = false;
        private void ClipManager_Main_Load(object sender, EventArgs e)
        {
            UIManager.MainWindowUtils.SetComboBoxPlaceholderText(seasonComboBox, "@random");
            UIManager.MainWindowUtils.SetComboBoxPlaceholderText(characterComboBox, "@random");
            UIManager.MainWindowUtils.SetComboBoxPlaceholderText(episodeComboBox, "@random");
            UIManager.MainWindowUtils.SetRandomSearchBarPlaceholder(searchBar);
            UpdateMainMenu();
            ClearSidePanel();
        }
        public void SetSidePanel(string title, string path)
        {
            rightPanelThumbnail.Image = FileUtils.GetVideoThumbnail(path);
            rightPanelThumbnail.Visible = true;
            rightPanelTitle.Text = title;
            rightPanelTitle.Visible = true;
            string fileSize = FileUtils.GetFileSize(path);
            string location = Path.GetDirectoryName(path);
            string lastModified = File.GetLastWriteTime(path).ToString();
            string duration = ClipUtils.GetClipDuration(path);
            AddRow("Size", fileSize, 0);
            AddRow("Location", location, 1);
            AddRow("Last Modified", lastModified, 2);
            AddRow("Duration", duration, 3);
            AddRow("", "", 4);
        }
        public void ClearSidePanel()
        {
            rightPanelThumbnail.Visible = false;
            rightPanelTitle.Visible = false;
            fileInfoTableLayoutPanel.Controls.Clear();
        }
        public void UpdateMainMenu()
        {
            UpdateCharacters();
            UpdateClips();
        }
        public void UpdateCharacters()
        {
            characterComboBox.Items.Clear();
            characterComboBox.Items.AddRange(new[] { "All" }.Concat(DatabaseManager.GetAllCharacters()).ToArray());
        }
        public void UpdateClips(ListViewItem[] filteredItems = null)
        {
            if (filteredItems == null)
            {
                filteredItems = ClipUtils.ClipsToListViewItems(DatabaseManager.GetAll());
                listView.Items.Clear();
                listView.Items.AddRange(filteredItems);
                SetResultsLabel(filteredItems.Length);
            }
            else
            {
                listView.Items.Clear();
                listView.Items.AddRange(filteredItems);
                SetResultsLabel(filteredItems.Length);
            }
        }
        private void GlobalMouseEnterOnButton(object sender, EventArgs e)
        {

        }
        private void GlobalMouseLeaveOnButton(object sender, EventArgs e)
        {

        }
        private void CharacterComboBox_TextChanged(object sender, EventArgs e)
        {
            var items = new[] { "All" }.Concat(DatabaseManager.GetAllCharacters()).ToArray().Where(p => p.Contains(characterComboBox.Text, StringComparison.OrdinalIgnoreCase)).ToArray();

            characterComboBox.BeginUpdate();
            characterComboBox.Items.Clear();
            characterComboBox.Items.AddRange(items);
            characterComboBox.EndUpdate();

            characterComboBox.SelectionStart = characterComboBox.Text.Length;
            if (!characterComboBox.DroppedDown)
                characterComboBox.DroppedDown = true;
            Cursor.Current = Cursors.Default;
        }

        private void ImportButtonOnClick(object sender, EventArgs e)
        {
            OpenImportClipWindow();
        }

        public void OpenImportClipWindow(string path = "")
        {
            ClipManager_ImportClip importClipWindow = new ClipManager_ImportClip(path, this);
            importClipWindow.ShowDialog();
        }

        private void ClipManager_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ClipManager_Main_DragDrop(object sender, DragEventArgs e)
        {
            if (e != null)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    string[] videoFiles = files.Where(FileUtils.IsVideoFile).ToArray();
                    if (videoFiles.Length > 0)
                    {
                        OpenImportClipWindow(videoFiles[0].ToString());
                    }
                }
            }
        }

        private void resetFilterButton_Click(object sender, EventArgs e)
        {
            seasonComboBox.SelectedIndex = 0;
            seasonComboBox.Text = seasonComboBox.Items[0].ToString();

            episodeComboBox.SelectedIndex = 0;
            episodeComboBox.Text = episodeComboBox.Items[0].ToString();

            characterComboBox.SelectedIndex = 0;
            characterComboBox.Text = episodeComboBox.Items[0].ToString();

            searchBar.Text = string.Empty;
        }

        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int season = StringUtils.ExtractInt(seasonComboBox.Text);
            episodeComboBox.Items.Clear();
            if (season == 1)
                episodeComboBox.Items.AddRange(new object[] { "All", "Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10", "Episode 11" });
            else
                episodeComboBox.Items.AddRange(new object[] { "All", "Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10" });
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                string title = listView.SelectedItems[0].SubItems[0].Text;
                string tag = listView.SelectedItems[0].Tag.ToString();
                SetSidePanel(title, tag);
            }
            else
            {
                ClearSidePanel();
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool reverse;

            if (e.Column == _lastColumn)
            {
                reverse = !_currentSort.ToString().StartsWith("Reverse");
            }
            else
            {
                reverse = false;
            }

            _currentSort = MainWindowUtils.GetFilterForColumn(e.Column, reverse);
            _lastColumn = e.Column;

            var items = listView.Items.Cast<ListViewItem>().ToArray();

            var sorted = MainWindowUtils.SortListViewItems(items, _currentSort);

            listView.BeginUpdate();
            listView.Items.Clear();
            listView.Items.AddRange(sorted);
            listView.EndUpdate();
        }
        public void SetResultsLabel(int resultsCount)
        {
            resultsLabel.Text = resultsCount switch
            {
                0 => "No results found.",
                1 => "1 result found.",
                _ => $"{resultsCount} results found."
            };
        }

        private void SearchBarTextChanged(object sender, EventArgs e)
        {
            string search = searchBar.Text;
            bool isWhiteOrNull = string.IsNullOrWhiteSpace(search);

            if (isWhiteOrNull)
            {
                if (!wasLastSearchWhiteOrNull)
                {
                    UpdateClips();
                    wasLastSearchWhiteOrNull = true;
                }
                return;
            }

            var filteredItems = ClipUtils.ClipsToListViewItems(DatabaseManager.SearchByTitle(search));

            UpdateClips(filteredItems);
            wasLastSearchWhiteOrNull = false;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenSelectedClip();
        }
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedClip();
        }
        private void OpenSelectedClip()
        {
            if (listView.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    string tag = item.Tag.ToString();
                    FileUtils.OpenFile(tag);
                }
            }
        }
        private void showInFolderButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 0)
            {
                string tag = listView.SelectedItems[0].Tag.ToString();
                FileUtils.ShowFileInFolder(tag);
                return;
            }
        }

        private void listViewContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView.SelectedItems.Count > 1)
            {
                openButton.Enabled = false;
                showInFolderButton.Enabled = false;
                deleteClipButton.Text = "Delete Clips";
            }
            else
            {
                openButton.Enabled = true;
                showInFolderButton.Enabled = true;
                deleteClipButton.Text = "Delete Clip";
            }
        }

        private void deleteClipButton_Click(object sender, EventArgs e)
        {
            int clipsCount = listView.SelectedItems.Count;
            if (clipsCount > 1)
            {
                if (MessageBox.Show($"Are you sure you want to delete {clipsCount} clips?", "Clip Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int removedClips = 0;
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        string tag = item.Tag.ToString();

                        ClipInfo clipInfo = DatabaseManager.SearchByPath(tag);
                        if (DatabaseManager.RemoveClip(clipInfo))
                        {
                            removedClips++;
                        }
                    }
                    MessageBox.Show($"{removedClips.ToString()} clips removed sucessfully.", "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    UpdateClips();
                }
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this clip?", "Clip Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string tag = listView.SelectedItems[0].Tag.ToString();
                    ClipInfo clipInfo = DatabaseManager.SearchByPath(tag);
                    if (DatabaseManager.RemoveClip(clipInfo))
                    {
                        UpdateClips();
                        MessageBox.Show("Clip removed sucessfully.", "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                return;
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            int season = StringUtils.ExtractInt(seasonComboBox.Text);//   0 = All
            int episode = StringUtils.ExtractInt(episodeComboBox.Text);// 0 = All
            string? character = characterComboBox.SelectedItem?.ToString();
            if (character == "All")
                character = string.Empty;
            UpdateClips(ClipUtils.ClipsToListViewItems(DatabaseManager.GetFilteredClips(season, episode, character)));
        }
        void AddRow(string name, string value, int row)
        {
            var lblName = new Label
            {
                Text = name,
                AutoSize = true,
                ForeColor = Color.LightGray,
                Margin = new Padding(3, 6, 3, 4)
            };

            var lblValue = new Label
            {
                Text = value,
                AutoSize = true,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 6, 3, 4),
                AutoEllipsis = true,
                MaximumSize = new Size(200, 0)
            };



            fileInfoTableLayoutPanel.Controls.Add(lblName, 0, row);
            fileInfoTableLayoutPanel.Controls.Add(lblValue, 1, row);
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var paths = listView.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag as string).Where(p => !string.IsNullOrWhiteSpace(p) && File.Exists(p)).ToArray();
            if (paths.Length != 0)
            {
                var data = new DataObject();
                data.SetData(DataFormats.FileDrop, paths);

                DoDragDrop(data, DragDropEffects.Copy);
            }
        }
    }
}
