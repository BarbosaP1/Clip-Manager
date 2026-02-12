namespace ClipManager
{
    partial class ClipManager_ImportClip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipManager_ImportClip));
            videoFileLabel = new Label();
            videoFileTextBox = new TextBox();
            videoFileButton = new Button();
            clipTitleLabel = new Label();
            clipTitleTextBox = new TextBox();
            seasonLabel = new Label();
            seasonComboBox = new ComboBox();
            episodeLabel = new Label();
            episodeComboBox = new ComboBox();
            charactersTextBox = new TextBox();
            charactersLabel = new Label();
            durationLabel = new Label();
            fileSizeLabel = new Label();
            importClipButton = new Button();
            cancelButton = new Button();
            previewButton = new Button();
            SuspendLayout();
            // 
            // videoFileLabel
            // 
            videoFileLabel.AutoSize = true;
            videoFileLabel.ForeColor = Color.White;
            videoFileLabel.Location = new Point(30, 38);
            videoFileLabel.Name = "videoFileLabel";
            videoFileLabel.Size = new Size(58, 15);
            videoFileLabel.TabIndex = 0;
            videoFileLabel.Text = "Video File";
            // 
            // videoFileTextBox
            // 
            videoFileTextBox.Location = new Point(30, 56);
            videoFileTextBox.Name = "videoFileTextBox";
            videoFileTextBox.PlaceholderText = "Select File...";
            videoFileTextBox.ReadOnly = true;
            videoFileTextBox.Size = new Size(353, 23);
            videoFileTextBox.TabIndex = 1;
            // 
            // videoFileButton
            // 
            videoFileButton.Location = new Point(389, 56);
            videoFileButton.Name = "videoFileButton";
            videoFileButton.Size = new Size(46, 23);
            videoFileButton.TabIndex = 2;
            videoFileButton.Text = "Select";
            videoFileButton.UseVisualStyleBackColor = true;
            videoFileButton.Click += SelectVideoButton;
            // 
            // clipTitleLabel
            // 
            clipTitleLabel.AutoSize = true;
            clipTitleLabel.ForeColor = Color.White;
            clipTitleLabel.Location = new Point(30, 106);
            clipTitleLabel.Name = "clipTitleLabel";
            clipTitleLabel.Size = new Size(54, 15);
            clipTitleLabel.TabIndex = 3;
            clipTitleLabel.Text = "Clip Title";
            // 
            // clipTitleTextBox
            // 
            clipTitleTextBox.Location = new Point(30, 124);
            clipTitleTextBox.Name = "clipTitleTextBox";
            clipTitleTextBox.PlaceholderText = "Select Title";
            clipTitleTextBox.Size = new Size(384, 23);
            clipTitleTextBox.TabIndex = 4;
            // 
            // seasonLabel
            // 
            seasonLabel.AutoSize = true;
            seasonLabel.ForeColor = Color.White;
            seasonLabel.Location = new Point(30, 177);
            seasonLabel.Name = "seasonLabel";
            seasonLabel.Size = new Size(44, 15);
            seasonLabel.TabIndex = 5;
            seasonLabel.Text = "Season";
            // 
            // seasonComboBox
            // 
            seasonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            seasonComboBox.FormattingEnabled = true;
            seasonComboBox.Items.AddRange(new object[] { "Season 1", "Season 2", "Season 3", "Season 4", "Season 5", "Season 6", "Season 7", "Season 8" });
            seasonComboBox.Location = new Point(30, 195);
            seasonComboBox.Name = "seasonComboBox";
            seasonComboBox.Size = new Size(121, 23);
            seasonComboBox.TabIndex = 6;
            seasonComboBox.SelectedIndexChanged += seasonComboBox_SelectedIndexChanged;
            // 
            // episodeLabel
            // 
            episodeLabel.AutoSize = true;
            episodeLabel.ForeColor = Color.White;
            episodeLabel.Location = new Point(203, 177);
            episodeLabel.Name = "episodeLabel";
            episodeLabel.Size = new Size(48, 15);
            episodeLabel.TabIndex = 7;
            episodeLabel.Text = "Episode";
            // 
            // episodeComboBox
            // 
            episodeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            episodeComboBox.FormattingEnabled = true;
            episodeComboBox.Items.AddRange(new object[] { "Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10" });
            episodeComboBox.Location = new Point(203, 195);
            episodeComboBox.Name = "episodeComboBox";
            episodeComboBox.Size = new Size(121, 23);
            episodeComboBox.TabIndex = 8;
            // 
            // charactersTextBox
            // 
            charactersTextBox.Location = new Point(30, 259);
            charactersTextBox.Name = "charactersTextBox";
            charactersTextBox.PlaceholderText = "Rick, Morty";
            charactersTextBox.Size = new Size(384, 23);
            charactersTextBox.TabIndex = 10;
            // 
            // charactersLabel
            // 
            charactersLabel.AutoSize = true;
            charactersLabel.ForeColor = Color.White;
            charactersLabel.Location = new Point(30, 241);
            charactersLabel.Name = "charactersLabel";
            charactersLabel.Size = new Size(63, 15);
            charactersLabel.TabIndex = 9;
            charactersLabel.Text = "Characters";
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            durationLabel.ForeColor = Color.White;
            durationLabel.Location = new Point(30, 319);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(138, 21);
            durationLabel.TabIndex = 11;
            durationLabel.Text = "Duration: 00:00:04";
            // 
            // fileSizeLabel
            // 
            fileSizeLabel.AutoSize = true;
            fileSizeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileSizeLabel.ForeColor = Color.White;
            fileSizeLabel.Location = new Point(30, 349);
            fileSizeLabel.Name = "fileSizeLabel";
            fileSizeLabel.Size = new Size(121, 21);
            fileSizeLabel.TabIndex = 12;
            fileSizeLabel.Text = "File Size: 5,2 MB";
            // 
            // importClipButton
            // 
            importClipButton.Location = new Point(344, 469);
            importClipButton.Name = "importClipButton";
            importClipButton.Size = new Size(116, 32);
            importClipButton.TabIndex = 13;
            importClipButton.Text = "Import Clip";
            importClipButton.UseVisualStyleBackColor = true;
            importClipButton.Click += ImportClipButtonClick;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(113, 469);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(116, 32);
            cancelButton.TabIndex = 14;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // previewButton
            // 
            previewButton.Location = new Point(438, 56);
            previewButton.Name = "previewButton";
            previewButton.Size = new Size(60, 23);
            previewButton.TabIndex = 15;
            previewButton.Text = "Preview";
            previewButton.UseVisualStyleBackColor = true;
            previewButton.Click += previewButton_Click;
            // 
            // ClipManager_ImportClip
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(562, 522);
            Controls.Add(previewButton);
            Controls.Add(cancelButton);
            Controls.Add(importClipButton);
            Controls.Add(fileSizeLabel);
            Controls.Add(durationLabel);
            Controls.Add(charactersTextBox);
            Controls.Add(charactersLabel);
            Controls.Add(episodeComboBox);
            Controls.Add(episodeLabel);
            Controls.Add(seasonComboBox);
            Controls.Add(seasonLabel);
            Controls.Add(clipTitleTextBox);
            Controls.Add(clipTitleLabel);
            Controls.Add(videoFileButton);
            Controls.Add(videoFileTextBox);
            Controls.Add(videoFileLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClipManager_ImportClip";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Clip - Clip Manager";
            DragDrop += ClipManager_ImportClip_DragDrop;
            DragEnter += ClipManager_ImportClip_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label videoFileLabel;
        private TextBox videoFileTextBox;
        private Button videoFileButton;
        private Label clipTitleLabel;
        private TextBox clipTitleTextBox;
        private Label seasonLabel;
        private ComboBox seasonComboBox;
        private Label episodeLabel;
        private ComboBox episodeComboBox;
        private TextBox charactersTextBox;
        private Label charactersLabel;
        private Label durationLabel;
        private Label fileSizeLabel;
        private Button importClipButton;
        private Button cancelButton;
        private Button previewButton;
    }
}