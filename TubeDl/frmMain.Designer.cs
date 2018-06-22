namespace TubeDl
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.list_Items = new System.Windows.Forms.ListView();
            this.fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloaded_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.added = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePermenatlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flatStatusBar1 = new FlatUI.FlatStatusBar();
            this.btnTargetFolder = new TubeDl.ExButton();
            this.btnRemove = new TubeDl.ExButton();
            this.btnRemveCompleted = new TubeDl.ExButton();
            this.btnStopDownload = new TubeDl.ExButton();
            this.btnPauseDownload = new TubeDl.ExButton();
            this.btnStartDownload = new TubeDl.ExButton();
            this.exButton1 = new TubeDl.ExButton();
            this.youtubeSeperator7 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator5 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator6 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator3 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator4 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator2 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTargetFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemveCompleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.btnTargetFolder);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnRemveCompleted);
            this.panel1.Controls.Add(this.btnStopDownload);
            this.panel1.Controls.Add(this.btnPauseDownload);
            this.panel1.Controls.Add(this.btnStartDownload);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.youtubeSeperator7);
            this.panel1.Controls.Add(this.youtubeSeperator5);
            this.panel1.Controls.Add(this.youtubeSeperator6);
            this.panel1.Controls.Add(this.youtubeSeperator3);
            this.panel1.Controls.Add(this.youtubeSeperator4);
            this.panel1.Controls.Add(this.youtubeSeperator2);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 61);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumBlue;
            this.panel2.Controls.Add(this.exButton1);
            this.panel2.Location = new System.Drawing.Point(0, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(66, 67);
            this.panel2.TabIndex = 16;
            // 
            // list_Items
            // 
            this.list_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Items.BackColor = System.Drawing.SystemColors.Window;
            this.list_Items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fname,
            this.total_length,
            this.downloaded_length,
            this.status,
            this.added});
            this.list_Items.ContextMenuStrip = this.contextMenuStrip1;
            this.list_Items.FullRowSelect = true;
            this.list_Items.GridLines = true;
            this.list_Items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Items.HideSelection = false;
            this.list_Items.Location = new System.Drawing.Point(0, 106);
            this.list_Items.Name = "list_Items";
            this.list_Items.Size = new System.Drawing.Size(825, 385);
            this.list_Items.TabIndex = 18;
            this.list_Items.UseCompatibleStateImageBehavior = false;
            this.list_Items.View = System.Windows.Forms.View.Details;
            this.list_Items.SelectedIndexChanged += new System.EventHandler(this.list_Items_SelectedIndexChanged);
            this.list_Items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_Items_MouseClick);
            // 
            // fname
            // 
            this.fname.Text = "Name";
            this.fname.Width = 407;
            // 
            // total_length
            // 
            this.total_length.Text = "Size";
            this.total_length.Width = 80;
            // 
            // downloaded_length
            // 
            this.downloaded_length.Text = "Progress";
            this.downloaded_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.downloaded_length.Width = 120;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 95;
            // 
            // added
            // 
            this.added.Text = "Added";
            this.added.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.added.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.openFileLocationToolStripMenuItem,
            this.removeFromListToolStripMenuItem,
            this.deletePermenatlyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pauseToolStripMenuItem.Text = "&Pause Download";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resumeToolStripMenuItem.Text = "&Resume Download";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileLocationToolStripMenuItem.Text = "&Open file location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.removeFromListToolStripMenuItem.Text = "&Remove From list";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // deletePermenatlyToolStripMenuItem
            // 
            this.deletePermenatlyToolStripMenuItem.Name = "deletePermenatlyToolStripMenuItem";
            this.deletePermenatlyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deletePermenatlyToolStripMenuItem.Text = "&Delete permenatly";
            this.deletePermenatlyToolStripMenuItem.Click += new System.EventHandler(this.deletePermenatlyToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // flatStatusBar1
            // 
            this.flatStatusBar1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flatStatusBar1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatStatusBar1.ForeColor = System.Drawing.Color.White;
            this.flatStatusBar1.Location = new System.Drawing.Point(0, 493);
            this.flatStatusBar1.Name = "flatStatusBar1";
            this.flatStatusBar1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatStatusBar1.ShowTimeDate = false;
            this.flatStatusBar1.Size = new System.Drawing.Size(825, 23);
            this.flatStatusBar1.TabIndex = 19;
            this.flatStatusBar1.TextColor = System.Drawing.Color.White;
            // 
            // btnTargetFolder
            // 
            this.btnTargetFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTargetFolder.Image = global::TubeDl.Properties.Resources.download_folder_color;
            this.btnTargetFolder.ImageDisable = global::TubeDl.Properties.Resources.download_folder_gray;
            this.btnTargetFolder.ImageEnable = global::TubeDl.Properties.Resources.download_folder_color;
            this.btnTargetFolder.Location = new System.Drawing.Point(421, 13);
            this.btnTargetFolder.Name = "btnTargetFolder";
            this.btnTargetFolder.Size = new System.Drawing.Size(32, 32);
            this.btnTargetFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTargetFolder.TabIndex = 21;
            this.btnTargetFolder.TabStop = false;
            this.btnTargetFolder.Click += new System.EventHandler(this.btnTargetFolder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::TubeDl.Properties.Resources.delete_color;
            this.btnRemove.ImageDisable = global::TubeDl.Properties.Resources.delete_gray;
            this.btnRemove.ImageEnable = global::TubeDl.Properties.Resources.delete_color;
            this.btnRemove.Location = new System.Drawing.Point(287, 13);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 32);
            this.btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRemove.TabIndex = 20;
            this.btnRemove.TabStop = false;
            this.btnRemove.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // btnRemveCompleted
            // 
            this.btnRemveCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemveCompleted.Enabled = false;
            this.btnRemveCompleted.Image = global::TubeDl.Properties.Resources.remove_color;
            this.btnRemveCompleted.ImageDisable = global::TubeDl.Properties.Resources.remove_gray;
            this.btnRemveCompleted.ImageEnable = global::TubeDl.Properties.Resources.remove_color;
            this.btnRemveCompleted.Location = new System.Drawing.Point(355, 13);
            this.btnRemveCompleted.Name = "btnRemveCompleted";
            this.btnRemveCompleted.Size = new System.Drawing.Size(32, 32);
            this.btnRemveCompleted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRemveCompleted.TabIndex = 19;
            this.btnRemveCompleted.TabStop = false;
            this.btnRemveCompleted.Click += new System.EventHandler(this.deletePermenatlyToolStripMenuItem_Click);
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopDownload.Enabled = false;
            this.btnStopDownload.Image = global::TubeDl.Properties.Resources.stop_color;
            this.btnStopDownload.ImageDisable = global::TubeDl.Properties.Resources.stop_gray;
            this.btnStopDownload.ImageEnable = global::TubeDl.Properties.Resources.stop_color;
            this.btnStopDownload.Location = new System.Drawing.Point(219, 13);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(32, 32);
            this.btnStopDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStopDownload.TabIndex = 18;
            this.btnStopDownload.TabStop = false;
            this.btnStopDownload.Click += new System.EventHandler(this.btnStopDownload_Click);
            // 
            // btnPauseDownload
            // 
            this.btnPauseDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPauseDownload.Enabled = false;
            this.btnPauseDownload.Image = global::TubeDl.Properties.Resources.pause_color;
            this.btnPauseDownload.ImageDisable = global::TubeDl.Properties.Resources.pause_gray;
            this.btnPauseDownload.ImageEnable = global::TubeDl.Properties.Resources.pause_color;
            this.btnPauseDownload.Location = new System.Drawing.Point(153, 13);
            this.btnPauseDownload.Name = "btnPauseDownload";
            this.btnPauseDownload.Size = new System.Drawing.Size(32, 32);
            this.btnPauseDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPauseDownload.TabIndex = 17;
            this.btnPauseDownload.TabStop = false;
            this.btnPauseDownload.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartDownload.Enabled = false;
            this.btnStartDownload.Image = global::TubeDl.Properties.Resources.start_color;
            this.btnStartDownload.ImageDisable = global::TubeDl.Properties.Resources.start_gray;
            this.btnStartDownload.ImageEnable = global::TubeDl.Properties.Resources.start_color;
            this.btnStartDownload.Location = new System.Drawing.Point(80, 13);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(32, 32);
            this.btnStartDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStartDownload.TabIndex = 16;
            this.btnStartDownload.TabStop = false;
            this.btnStartDownload.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // exButton1
            // 
            this.exButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton1.Image = global::TubeDl.Properties.Resources.add_white;
            this.exButton1.ImageDisable = ((System.Drawing.Image)(resources.GetObject("exButton1.ImageDisable")));
            this.exButton1.ImageEnable = global::TubeDl.Properties.Resources.add_white;
            this.exButton1.Location = new System.Drawing.Point(16, 17);
            this.exButton1.Name = "exButton1";
            this.exButton1.Size = new System.Drawing.Size(32, 32);
            this.exButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton1.TabIndex = 15;
            this.exButton1.TabStop = false;
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // youtubeSeperator7
            // 
            this.youtubeSeperator7.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator7.Location = new System.Drawing.Point(402, 9);
            this.youtubeSeperator7.Name = "youtubeSeperator7";
            this.youtubeSeperator7.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator7.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator7.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator7.TabIndex = 14;
            // 
            // youtubeSeperator5
            // 
            this.youtubeSeperator5.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator5.Location = new System.Drawing.Point(335, 9);
            this.youtubeSeperator5.Name = "youtubeSeperator5";
            this.youtubeSeperator5.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator5.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator5.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator5.TabIndex = 12;
            // 
            // youtubeSeperator6
            // 
            this.youtubeSeperator6.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator6.Location = new System.Drawing.Point(469, 9);
            this.youtubeSeperator6.Name = "youtubeSeperator6";
            this.youtubeSeperator6.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator6.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator6.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator6.TabIndex = 10;
            // 
            // youtubeSeperator3
            // 
            this.youtubeSeperator3.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator3.Location = new System.Drawing.Point(268, 9);
            this.youtubeSeperator3.Name = "youtubeSeperator3";
            this.youtubeSeperator3.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator3.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator3.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator3.TabIndex = 9;
            // 
            // youtubeSeperator4
            // 
            this.youtubeSeperator4.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator4.Location = new System.Drawing.Point(200, 9);
            this.youtubeSeperator4.Name = "youtubeSeperator4";
            this.youtubeSeperator4.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator4.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator4.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator4.TabIndex = 8;
            // 
            // youtubeSeperator2
            // 
            this.youtubeSeperator2.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator2.Location = new System.Drawing.Point(134, 9);
            this.youtubeSeperator2.Name = "youtubeSeperator2";
            this.youtubeSeperator2.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator2.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator2.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator2.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 516);
            this.Controls.Add(this.flatStatusBar1);
            this.Controls.Add(this.list_Items);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnTargetFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemveCompleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator6;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator3;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator4;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator2;
        private System.Windows.Forms.ListView list_Items;
        private System.Windows.Forms.ColumnHeader fname;
        private System.Windows.Forms.ColumnHeader total_length;
        private System.Windows.Forms.ColumnHeader downloaded_length;
        private System.Windows.Forms.ColumnHeader added;
        private System.Windows.Forms.ColumnHeader status;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator7;
        private YoutubeTheme.Skin.YoutubeSeperator youtubeSeperator5;
        private ExButton exButton1;
        private System.Windows.Forms.Panel panel2;
        private ExButton btnStartDownload;
        private ExButton btnPauseDownload;
        private ExButton btnStopDownload;
        private ExButton btnRemveCompleted;
        private ExButton btnRemove;
        private FlatUI.FlatStatusBar flatStatusBar1;
        private ExButton btnTargetFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePermenatlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}