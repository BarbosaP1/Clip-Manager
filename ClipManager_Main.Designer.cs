using System.Security.Cryptography.X509Certificates;

namespace ClipManager
{
    partial class ClipManager_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipManager_Main));
            SidePanel = new Panel();
            filterButton = new Button();
            resetFilterButton = new Button();
            episodeComboBox = new ComboBox();
            episodeLabel = new Label();
            characterComboBox = new ComboBox();
            characterLabel = new Label();
            seasonComboBox = new ComboBox();
            seasonLabel = new Label();
            filtersLabel = new Label();
            Header = new Panel();
            searchButton = new Button();
            searchBar = new TextBox();
            DownPanel = new Panel();
            resultsLabel = new Label();
            importClipButton = new Button();
            listView = new ListView();
            titleHeader = new ColumnHeader();
            episodeHeader = new ColumnHeader();
            charactersHeader = new ColumnHeader();
            durationHeader = new ColumnHeader();
            listViewContextMenuStrip = new ContextMenuStrip(components);
            openButton = new ToolStripMenuItem();
            showInFolderButton = new ToolStripMenuItem();
            deleteClipButton = new ToolStripMenuItem();
            rightPanelTitle = new Label();
            rightPanelThumbnail = new PictureBox();
            fileInfoTableLayoutPanel = new TableLayoutPanel();
            SidePanel.SuspendLayout();
            Header.SuspendLayout();
            DownPanel.SuspendLayout();
            listViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightPanelThumbnail).BeginInit();
            SuspendLayout();
            // 
            // SidePanel
            // 
            SidePanel.BorderStyle = BorderStyle.FixedSingle;
            SidePanel.Controls.Add(filterButton);
            SidePanel.Controls.Add(resetFilterButton);
            SidePanel.Controls.Add(episodeComboBox);
            SidePanel.Controls.Add(episodeLabel);
            SidePanel.Controls.Add(characterComboBox);
            SidePanel.Controls.Add(characterLabel);
            SidePanel.Controls.Add(seasonComboBox);
            SidePanel.Controls.Add(seasonLabel);
            SidePanel.Controls.Add(filtersLabel);
            SidePanel.Location = new Point(-7, 80);
            SidePanel.Name = "SidePanel";
            SidePanel.Size = new Size(154, 323);
            SidePanel.TabIndex = 1;
            // 
            // filterButton
            // 
            filterButton.AllowDrop = true;
            filterButton.BackColor = Color.FromArgb(25, 25, 25);
            filterButton.BackgroundImageLayout = ImageLayout.Zoom;
            filterButton.Cursor = Cursors.Hand;
            filterButton.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterButton.ForeColor = SystemColors.Control;
            filterButton.ImageAlign = ContentAlignment.MiddleLeft;
            filterButton.Location = new Point(18, 266);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(121, 38);
            filterButton.TabIndex = 8;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = false;
            filterButton.Click += filterButton_Click;
            // 
            // resetFilterButton
            // 
            resetFilterButton.AllowDrop = true;
            resetFilterButton.BackColor = Color.FromArgb(25, 25, 25);
            resetFilterButton.BackgroundImageLayout = ImageLayout.Zoom;
            resetFilterButton.Cursor = Cursors.Hand;
            resetFilterButton.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            resetFilterButton.FlatStyle = FlatStyle.Flat;
            resetFilterButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resetFilterButton.ForeColor = SystemColors.Control;
            resetFilterButton.ImageAlign = ContentAlignment.MiddleLeft;
            resetFilterButton.Location = new Point(18, 237);
            resetFilterButton.Name = "resetFilterButton";
            resetFilterButton.Size = new Size(121, 23);
            resetFilterButton.TabIndex = 9;
            resetFilterButton.Text = "Reset";
            resetFilterButton.UseVisualStyleBackColor = false;
            resetFilterButton.Click += resetFilterButton_Click;
            // 
            // episodeComboBox
            // 
            episodeComboBox.BackColor = Color.FromArgb(25, 25, 25);
            episodeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            episodeComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            episodeComboBox.ForeColor = Color.White;
            episodeComboBox.FormattingEnabled = true;
            episodeComboBox.Items.AddRange(new object[] { "All", "Episode 1", "Episode 2", "Episode 3", "Episode 4", "Episode 5", "Episode 6", "Episode 7", "Episode 8", "Episode 9", "Episode 10" });
            episodeComboBox.Location = new Point(18, 208);
            episodeComboBox.Name = "episodeComboBox";
            episodeComboBox.Size = new Size(121, 23);
            episodeComboBox.TabIndex = 6;
            // 
            // episodeLabel
            // 
            episodeLabel.AutoSize = true;
            episodeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            episodeLabel.ForeColor = Color.White;
            episodeLabel.Location = new Point(18, 184);
            episodeLabel.Name = "episodeLabel";
            episodeLabel.Size = new Size(55, 17);
            episodeLabel.TabIndex = 5;
            episodeLabel.Text = "Episode";
            // 
            // characterComboBox
            // 
            characterComboBox.BackColor = Color.White;
            characterComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            characterComboBox.ForeColor = Color.Black;
            characterComboBox.FormattingEnabled = true;
            characterComboBox.Items.AddRange(new object[] { "All", "Morty", "Ethan" });
            characterComboBox.Location = new Point(18, 146);
            characterComboBox.Name = "characterComboBox";
            characterComboBox.Size = new Size(121, 23);
            characterComboBox.TabIndex = 4;
            characterComboBox.TextChanged += CharacterComboBox_TextChanged;
            // 
            // characterLabel
            // 
            characterLabel.AutoSize = true;
            characterLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            characterLabel.ForeColor = Color.White;
            characterLabel.Location = new Point(18, 121);
            characterLabel.Name = "characterLabel";
            characterLabel.Size = new Size(64, 17);
            characterLabel.TabIndex = 3;
            characterLabel.Text = "Character";
            // 
            // seasonComboBox
            // 
            seasonComboBox.BackColor = Color.FromArgb(25, 25, 25);
            seasonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            seasonComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonComboBox.ForeColor = Color.White;
            seasonComboBox.FormattingEnabled = true;
            seasonComboBox.Items.AddRange(new object[] { "All", "Season 1", "Season 2", "Season 3", "Season 4", "Season 5", "Season 6", "Season 7", "Season 8" });
            seasonComboBox.Location = new Point(18, 82);
            seasonComboBox.Name = "seasonComboBox";
            seasonComboBox.Size = new Size(121, 23);
            seasonComboBox.TabIndex = 0;
            seasonComboBox.SelectedIndexChanged += seasonComboBox_SelectedIndexChanged;
            // 
            // seasonLabel
            // 
            seasonLabel.AutoSize = true;
            seasonLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            seasonLabel.ForeColor = Color.White;
            seasonLabel.Location = new Point(18, 62);
            seasonLabel.Name = "seasonLabel";
            seasonLabel.Size = new Size(50, 17);
            seasonLabel.TabIndex = 1;
            seasonLabel.Text = "Season";
            // 
            // filtersLabel
            // 
            filtersLabel.AutoSize = true;
            filtersLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filtersLabel.ForeColor = Color.White;
            filtersLabel.Location = new Point(18, 18);
            filtersLabel.Name = "filtersLabel";
            filtersLabel.Size = new Size(62, 25);
            filtersLabel.TabIndex = 0;
            filtersLabel.Text = "Filters";
            // 
            // Header
            // 
            Header.BorderStyle = BorderStyle.FixedSingle;
            Header.Controls.Add(searchButton);
            Header.Controls.Add(searchBar);
            Header.Location = new Point(-7, 0);
            Header.Name = "Header";
            Header.Size = new Size(746, 81);
            Header.TabIndex = 0;
            // 
            // searchButton
            // 
            searchButton.AllowDrop = true;
            searchButton.BackColor = Color.FromArgb(25, 25, 25);
            searchButton.BackgroundImageLayout = ImageLayout.Zoom;
            searchButton.Cursor = Cursors.Hand;
            searchButton.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchButton.ForeColor = SystemColors.Control;
            searchButton.ImageAlign = ContentAlignment.MiddleLeft;
            searchButton.Location = new Point(18, 26);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(121, 38);
            searchButton.TabIndex = 0;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += SearchBarTextChanged;
            // 
            // searchBar
            // 
            searchBar.BackColor = Color.FromArgb(25, 25, 25);
            searchBar.BorderStyle = BorderStyle.FixedSingle;
            searchBar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBar.ForeColor = Color.White;
            searchBar.Location = new Point(153, 34);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(585, 25);
            searchBar.TabIndex = 1;
            searchBar.TextChanged += SearchBarTextChanged;
            // 
            // DownPanel
            // 
            DownPanel.BorderStyle = BorderStyle.FixedSingle;
            DownPanel.Controls.Add(resultsLabel);
            DownPanel.Controls.Add(importClipButton);
            DownPanel.Location = new Point(-7, 401);
            DownPanel.Name = "DownPanel";
            DownPanel.Size = new Size(746, 63);
            DownPanel.TabIndex = 2;
            // 
            // resultsLabel
            // 
            resultsLabel.AutoSize = true;
            resultsLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultsLabel.ForeColor = Color.White;
            resultsLabel.Location = new Point(23, 18);
            resultsLabel.Name = "resultsLabel";
            resultsLabel.Size = new Size(95, 17);
            resultsLabel.TabIndex = 2;
            resultsLabel.Text = "1 Result found.";
            // 
            // importClipButton
            // 
            importClipButton.AllowDrop = true;
            importClipButton.BackColor = Color.FromArgb(25, 25, 25);
            importClipButton.BackgroundImageLayout = ImageLayout.Zoom;
            importClipButton.Cursor = Cursors.Hand;
            importClipButton.FlatAppearance.BorderColor = Color.FromArgb(43, 43, 43);
            importClipButton.FlatStyle = FlatStyle.Flat;
            importClipButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importClipButton.ForeColor = SystemColors.Control;
            importClipButton.ImageAlign = ContentAlignment.MiddleLeft;
            importClipButton.Location = new Point(629, 8);
            importClipButton.Name = "importClipButton";
            importClipButton.Size = new Size(112, 39);
            importClipButton.TabIndex = 0;
            importClipButton.Text = "Import Clip";
            importClipButton.UseVisualStyleBackColor = false;
            importClipButton.Click += ImportButtonOnClick;
            importClipButton.MouseEnter += GlobalMouseEnterOnButton;
            importClipButton.MouseHover += GlobalMouseLeaveOnButton;
            // 
            // listView
            // 
            listView.BackColor = Color.FromArgb(25, 25, 25);
            listView.BackgroundImageTiled = true;
            listView.Columns.AddRange(new ColumnHeader[] { titleHeader, episodeHeader, charactersHeader, durationHeader });
            listView.ContextMenuStrip = listViewContextMenuStrip;
            listView.ForeColor = SystemColors.Control;
            listView.FullRowSelect = true;
            listView.Location = new Point(147, 80);
            listView.Name = "listView";
            listView.Size = new Size(592, 323);
            listView.TabIndex = 3;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.ColumnClick += listView_ColumnClick;
            listView.ItemDrag += listView_ItemDrag;
            listView.SelectedIndexChanged += listView_SelectedIndexChanged;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            // 
            // titleHeader
            // 
            titleHeader.Text = "Title";
            titleHeader.Width = 220;
            // 
            // episodeHeader
            // 
            episodeHeader.Text = "Episode";
            episodeHeader.Width = 80;
            // 
            // charactersHeader
            // 
            charactersHeader.Text = "Characters";
            charactersHeader.Width = 150;
            // 
            // durationHeader
            // 
            durationHeader.Text = "Duration";
            durationHeader.Width = 70;
            // 
            // listViewContextMenuStrip
            // 
            listViewContextMenuStrip.BackColor = Color.FromArgb(25, 25, 25);
            listViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { openButton, showInFolderButton, deleteClipButton });
            listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            listViewContextMenuStrip.RenderMode = ToolStripRenderMode.System;
            listViewContextMenuStrip.Size = new Size(151, 70);
            listViewContextMenuStrip.Opening += listViewContextMenuStrip_Opening;
            // 
            // openButton
            // 
            openButton.ForeColor = Color.White;
            openButton.Name = "openButton";
            openButton.Size = new Size(150, 22);
            openButton.Text = "Open";
            openButton.Click += openButton_Click;
            // 
            // showInFolderButton
            // 
            showInFolderButton.ForeColor = Color.White;
            showInFolderButton.Name = "showInFolderButton";
            showInFolderButton.Size = new Size(150, 22);
            showInFolderButton.Text = "Show in folder";
            showInFolderButton.Click += showInFolderButton_Click;
            // 
            // deleteClipButton
            // 
            deleteClipButton.ForeColor = Color.White;
            deleteClipButton.Name = "deleteClipButton";
            deleteClipButton.Size = new Size(150, 22);
            deleteClipButton.Text = "Delete Clip";
            deleteClipButton.Click += deleteClipButton_Click;
            // 
            // rightPanelTitle
            // 
            rightPanelTitle.AutoEllipsis = true;
            rightPanelTitle.AutoSize = true;
            rightPanelTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rightPanelTitle.ForeColor = Color.White;
            rightPanelTitle.Location = new Point(739, 140);
            rightPanelTitle.MaximumSize = new Size(250, 0);
            rightPanelTitle.Name = "rightPanelTitle";
            rightPanelTitle.Size = new Size(156, 20);
            rightPanelTitle.TabIndex = 4;
            rightPanelTitle.Text = "Morty Campfire Scene";
            rightPanelTitle.Visible = false;
            // 
            // rightPanelThumbnail
            // 
            rightPanelThumbnail.Image = Properties.Resources.vlcsnap_2026_02_07_22h34m48s093;
            rightPanelThumbnail.InitialImage = (Image)resources.GetObject("rightPanelThumbnail.InitialImage");
            rightPanelThumbnail.Location = new Point(738, 0);
            rightPanelThumbnail.Name = "rightPanelThumbnail";
            rightPanelThumbnail.Size = new Size(237, 124);
            rightPanelThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            rightPanelThumbnail.TabIndex = 6;
            rightPanelThumbnail.TabStop = false;
            // 
            // fileInfoTableLayoutPanel
            // 
            fileInfoTableLayoutPanel.ColumnCount = 2;
            fileInfoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            fileInfoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fileInfoTableLayoutPanel.ForeColor = Color.White;
            fileInfoTableLayoutPanel.Location = new Point(739, 202);
            fileInfoTableLayoutPanel.Name = "fileInfoTableLayoutPanel";
            fileInfoTableLayoutPanel.RowCount = 4;
            fileInfoTableLayoutPanel.RowStyles.Add(new RowStyle());
            fileInfoTableLayoutPanel.RowStyles.Add(new RowStyle());
            fileInfoTableLayoutPanel.RowStyles.Add(new RowStyle());
            fileInfoTableLayoutPanel.RowStyles.Add(new RowStyle());
            fileInfoTableLayoutPanel.Size = new Size(236, 209);
            fileInfoTableLayoutPanel.TabIndex = 9;
            // 
            // ClipManager_Main
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(975, 461);
            Controls.Add(fileInfoTableLayoutPanel);
            Controls.Add(rightPanelThumbnail);
            Controls.Add(rightPanelTitle);
            Controls.Add(listView);
            Controls.Add(DownPanel);
            Controls.Add(Header);
            Controls.Add(SidePanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClipManager_Main";
            Text = "Clip Manager - Main Window";
            Load += ClipManager_Main_Load;
            DragDrop += ClipManager_Main_DragDrop;
            DragEnter += ClipManager_Main_DragEnter;
            SidePanel.ResumeLayout(false);
            SidePanel.PerformLayout();
            Header.ResumeLayout(false);
            Header.PerformLayout();
            DownPanel.ResumeLayout(false);
            DownPanel.PerformLayout();
            listViewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightPanelThumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel SidePanel;
        private Panel Header;
        private Panel DownPanel;
        private ListView listView;
        private ColumnHeader titleHeader;
        private ColumnHeader episodeHeader;
        private ColumnHeader charactersHeader;
        private ColumnHeader durationHeader;
        private Label rightPanelTitle;
        private PictureBox rightPanelThumbnail;
        private Button importClipButton;
        private Label filtersLabel;
        private Label seasonLabel;
        private ComboBox seasonComboBox;
        private Label characterLabel;
        private ComboBox episodeComboBox;
        private Label episodeLabel;
        private ComboBox characterComboBox;
        private Button filterButton;
        private TextBox searchBar;
        private Button searchButton;
        private Label resultsLabel;
        private Button resetFilterButton;
        private ContextMenuStrip listViewContextMenuStrip;
        private ToolStripMenuItem openButton;
        private ToolStripMenuItem showInFolderButton;
        private ToolStripMenuItem deleteClipButton;
        private TableLayoutPanel fileInfoTableLayoutPanel;
    }
}
