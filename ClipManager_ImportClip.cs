using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipManager
{
    public partial class ClipManager_ImportClip : Form
    {
        public ClipManager_Main clipManager_Main = null;
        public ClipManager_ImportClip(string path = "", ClipManager_Main mainWindow = null)
        {
            if (mainWindow != null)
            {
                clipManager_Main = mainWindow;
            }
            InitializeComponent();
            if (!String.IsNullOrWhiteSpace(path))
            {
                ApplyVideoPathText(path);
            }
        }
        public void ApplyVideoPathText(string path)
        {
            if (File.Exists(path))
            {
                if (FileUtils.IsVideoFile(path))
                {
                    videoFileTextBox.Text = path;
                    ApplyVideoDurationText(ClipUtils.GetClipDuration(path));
                    ApplyFileSizeText(FileUtils.GetFileSize(path));
                }
                else
                {
                    MessageBox.Show("This file type is not supported!", "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This file doesn't exist!", "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);// impossível, mas nunca duvide de um usuário.
            }
        }
        public void ApplyVideoDurationText(string duration)
        {
            string formattedDuration = String.Concat("Duration: ", duration);
            durationLabel.Text = formattedDuration;
        }
        public void ApplyFileSizeText(string fileSize)
        {
            string formattedSize = String.Concat("File Size: ", fileSize);
            fileSizeLabel.Text = formattedSize;
        }
        private void SelectVideoButton(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Video File";
            openFileDialog.Filter = "Video Files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.flv;*.webm;*.mpeg;*.mpg;*.m4v|All file types|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (FileUtils.IsVideoFile(path))
                {
                    ApplyVideoPathText(path);
                }
                else
                {
                    MessageBox.Show("This file type is not supported!", "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void videoFileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void ClipManager_ImportClip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ClipManager_ImportClip_DragDrop(object sender, DragEventArgs e)
        {
            if (e != null)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null)
                {
                    string[] videoFiles = files.Where(FileUtils.IsVideoFile).ToArray();
                    if (videoFiles.Length > 0)
                    {
                        ApplyVideoPathText(videoFiles[0].ToString());
                    }
                }
            }
        }
        private void ImportClipButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(clipTitleTextBox.Text))
            {
                ShowError("No title has been selected!");
                return;
            }
            if (string.IsNullOrWhiteSpace(videoFileTextBox.Text) || !FileUtils.IsVideoFile(videoFileTextBox.Text))
            {
                ShowError("A video file is required!");
                return;
            }
            if (ClipUtils.IsClipRegistered(videoFileTextBox.Text))
            {
                ShowError("This clip has already been registered!");
                return;
            }
            if (string.IsNullOrWhiteSpace(seasonComboBox.Text))
            {
                ShowError("No season has been selected!");
                return;
            }
            if (string.IsNullOrWhiteSpace(episodeComboBox.Text))
            {
                ShowError("No episode has been selected!");
                return;
            }
            if (string.IsNullOrWhiteSpace(charactersTextBox.Text))
            {
                ShowError("No characters have been selected!");
                return;
            }
            var clipInfo = new ClipInfo
            {
                Title = clipTitleTextBox.Text,
                FilePath = videoFileTextBox.Text,
                Season = StringUtils.ExtractInt(seasonComboBox.Text),
                Episode = StringUtils.ExtractInt(episodeComboBox.Text),
                Characters = charactersTextBox.Text.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToArray()
            };

            DatabaseManager.AddClip(clipInfo);
            clipManager_Main.UpdateMainMenu();
            this.Close();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Clip Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            string path = videoFileTextBox.Text;
            if (FileUtils.IsVideoFile(path))
                FileUtils.OpenFile(path);
        }

        private void seasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int season = StringUtils.ExtractInt(seasonComboBox.Text);
            episodeComboBox.Items.Clear();
            if (season == 1)
                episodeComboBox.Items.AddRange(new object[] {"Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10", "Episode 11" });
            else
                episodeComboBox.Items.AddRange(new object[] {"Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10" });

        }
    }
}
