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
            this.btnTargetFolder = new TubeDl.ExButton();
            this.btnRemove = new TubeDl.ExButton();
            this.btnDelete = new TubeDl.ExButton();
            this.btnStopDownload = new TubeDl.ExButton();
            this.btnPauseDownload = new TubeDl.ExButton();
            this.btnStartDownload = new TubeDl.ExButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exButton1 = new TubeDl.ExButton();
            this.list_Items = new System.Windows.Forms.ListView();
            this.fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloaded_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transferrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTargetFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDownload)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exButton1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.btnTargetFolder);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnStopDownload);
            this.panel1.Controls.Add(this.btnPauseDownload);
            this.panel1.Controls.Add(this.btnStartDownload);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 61);
            this.panel1.TabIndex = 5;
            // 
            // btnTargetFolder
            // 
            this.btnTargetFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTargetFolder.Image = global::TubeDl.Properties.Resources.download_folder_color;
            this.btnTargetFolder.ImageDisable = global::TubeDl.Properties.Resources.download_folder_gray;
            this.btnTargetFolder.ImageEnable = global::TubeDl.Properties.Resources.download_folder_color;
            this.btnTargetFolder.Location = new System.Drawing.Point(355, 13);
            this.btnTargetFolder.Name = "btnTargetFolder";
            this.btnTargetFolder.Size = new System.Drawing.Size(32, 32);
            this.btnTargetFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTargetFolder.TabIndex = 21;
            this.btnTargetFolder.TabStop = false;
            this.toolTip1.SetToolTip(this.btnTargetFolder, "Click to Open target location");
            this.btnTargetFolder.Click += new System.EventHandler(this.btnTargetFolder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::TubeDl.Properties.Resources.delete_color;
            this.btnRemove.ImageDisable = global::TubeDl.Properties.Resources.delete_gray;
            this.btnRemove.ImageEnable = global::TubeDl.Properties.Resources.delete_color;
            this.btnRemove.Location = new System.Drawing.Point(221, 13);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 32);
            this.btnRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRemove.TabIndex = 20;
            this.btnRemove.TabStop = false;
            this.toolTip1.SetToolTip(this.btnRemove, "Click to remove selection from list");
            this.btnRemove.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::TubeDl.Properties.Resources.remove_color;
            this.btnDelete.ImageDisable = global::TubeDl.Properties.Resources.remove_gray;
            this.btnDelete.ImageEnable = global::TubeDl.Properties.Resources.remove_color;
            this.btnDelete.Location = new System.Drawing.Point(289, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDelete.TabIndex = 19;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "Click to delete selected iteme to recycle bin");
            this.btnDelete.Click += new System.EventHandler(this.deletePermenatlyToolStripMenuItem_Click);
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopDownload.Enabled = false;
            this.btnStopDownload.Image = global::TubeDl.Properties.Resources.stop_color;
            this.btnStopDownload.ImageDisable = global::TubeDl.Properties.Resources.stop_gray;
            this.btnStopDownload.ImageEnable = global::TubeDl.Properties.Resources.stop_color;
            this.btnStopDownload.Location = new System.Drawing.Point(422, 13);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(32, 32);
            this.btnStopDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStopDownload.TabIndex = 18;
            this.btnStopDownload.TabStop = false;
            this.btnStopDownload.Visible = false;
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
            this.toolTip1.SetToolTip(this.btnPauseDownload, "Click to pause download");
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
            this.toolTip1.SetToolTip(this.btnStartDownload, "click to start download");
            this.btnStartDownload.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
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
            this.toolTip1.SetToolTip(this.exButton1, "Click to add new download");
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
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
            this.transferrate,
            this.status,
            this.added});
            this.list_Items.ContextMenuStrip = this.contextMenuStrip1;
            this.list_Items.FullRowSelect = true;
            this.list_Items.GridLines = true;
            this.list_Items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Items.HideSelection = false;
            this.list_Items.Location = new System.Drawing.Point(0, 86);
            this.list_Items.Name = "list_Items";
            this.list_Items.Size = new System.Drawing.Size(825, 309);
            this.list_Items.TabIndex = 18;
            this.list_Items.UseCompatibleStateImageBehavior = false;
            this.list_Items.View = System.Windows.Forms.View.Details;
            this.list_Items.SelectedIndexChanged += new System.EventHandler(this.list_Items_SelectedIndexChanged);
            this.list_Items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_Items_MouseClick);
            // 
            // fname
            // 
            this.fname.Text = "Name";
            this.fname.Width = 401;
            // 
            // total_length
            // 
            this.total_length.Text = "Size";
            // 
            // downloaded_length
            // 
            this.downloaded_length.Text = "Progress";
            this.downloaded_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // transferrate
            // 
            this.transferrate.Text = "Transfer rate";
            this.transferrate.Width = 79;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 85;
            // 
            // added
            // 
            this.added.Text = "Added";
            this.added.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.added.Width = 132;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "--";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Info";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = "--";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 422);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_Items);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnTargetFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDownload)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exButton1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView list_Items;
        private System.Windows.Forms.ColumnHeader fname;
        private System.Windows.Forms.ColumnHeader total_length;
        private System.Windows.Forms.ColumnHeader downloaded_length;
        private System.Windows.Forms.ColumnHeader added;
        private System.Windows.Forms.ColumnHeader status;
        private ExButton exButton1;
        private System.Windows.Forms.Panel panel2;
        private ExButton btnStartDownload;
        private ExButton btnPauseDownload;
        private ExButton btnStopDownload;
        private ExButton btnDelete;
        private ExButton btnRemove;
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
        private System.Windows.Forms.ColumnHeader transferrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}