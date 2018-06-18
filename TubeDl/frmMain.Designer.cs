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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.list_Items = new System.Windows.Forms.ListView();
            this.fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downloaded_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.added = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flatStatusBar1 = new FlatUI.FlatStatusBar();
            this.exButton7 = new TubeDl.ExButton();
            this.exButton6 = new TubeDl.ExButton();
            this.exButton5 = new TubeDl.ExButton();
            this.exButton4 = new TubeDl.ExButton();
            this.exButton3 = new TubeDl.ExButton();
            this.exButton2 = new TubeDl.ExButton();
            this.exButton1 = new TubeDl.ExButton();
            this.youtubeSeperator7 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator5 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator6 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator3 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator4 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.youtubeSeperator2 = new YoutubeTheme.Skin.YoutubeSeperator();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exButton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.exButton7);
            this.panel1.Controls.Add(this.exButton6);
            this.panel1.Controls.Add(this.exButton5);
            this.panel1.Controls.Add(this.exButton4);
            this.panel1.Controls.Add(this.exButton3);
            this.panel1.Controls.Add(this.exButton2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.youtubeSeperator7);
            this.panel1.Controls.Add(this.youtubeSeperator5);
            this.panel1.Controls.Add(this.youtubeSeperator6);
            this.panel1.Controls.Add(this.youtubeSeperator3);
            this.panel1.Controls.Add(this.youtubeSeperator4);
            this.panel1.Controls.Add(this.youtubeSeperator2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 67);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumBlue;
            this.panel2.Controls.Add(this.exButton1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
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
            this.list_Items.FullRowSelect = true;
            this.list_Items.GridLines = true;
            this.list_Items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Items.HideSelection = false;
            this.list_Items.Location = new System.Drawing.Point(0, 110);
            this.list_Items.Name = "list_Items";
            this.list_Items.Size = new System.Drawing.Size(825, 377);
            this.list_Items.TabIndex = 18;
            this.list_Items.UseCompatibleStateImageBehavior = false;
            this.list_Items.View = System.Windows.Forms.View.Details;
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
            // exButton7
            // 
            this.exButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton7.Enabled = false;
            this.exButton7.Image = global::TubeDl.Properties.Resources.download_folder_color;
            this.exButton7.ImageDisable = global::TubeDl.Properties.Resources.download_folder_gray;
            this.exButton7.ImageEnable = global::TubeDl.Properties.Resources.download_folder_color;
            this.exButton7.Location = new System.Drawing.Point(421, 16);
            this.exButton7.Name = "exButton7";
            this.exButton7.Size = new System.Drawing.Size(32, 32);
            this.exButton7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton7.TabIndex = 21;
            this.exButton7.TabStop = false;
            // 
            // exButton6
            // 
            this.exButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton6.Enabled = false;
            this.exButton6.Image = global::TubeDl.Properties.Resources.delete_color;
            this.exButton6.ImageDisable = global::TubeDl.Properties.Resources.delete_gray;
            this.exButton6.ImageEnable = global::TubeDl.Properties.Resources.delete_color;
            this.exButton6.Location = new System.Drawing.Point(287, 16);
            this.exButton6.Name = "exButton6";
            this.exButton6.Size = new System.Drawing.Size(32, 32);
            this.exButton6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton6.TabIndex = 20;
            this.exButton6.TabStop = false;
            // 
            // exButton5
            // 
            this.exButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton5.Enabled = false;
            this.exButton5.Image = global::TubeDl.Properties.Resources.remove_color;
            this.exButton5.ImageDisable = global::TubeDl.Properties.Resources.remove_gray;
            this.exButton5.ImageEnable = global::TubeDl.Properties.Resources.remove_color;
            this.exButton5.Location = new System.Drawing.Point(355, 16);
            this.exButton5.Name = "exButton5";
            this.exButton5.Size = new System.Drawing.Size(32, 32);
            this.exButton5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton5.TabIndex = 19;
            this.exButton5.TabStop = false;
            // 
            // exButton4
            // 
            this.exButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton4.Enabled = false;
            this.exButton4.Image = global::TubeDl.Properties.Resources.stop_color;
            this.exButton4.ImageDisable = global::TubeDl.Properties.Resources.stop_gray;
            this.exButton4.ImageEnable = global::TubeDl.Properties.Resources.stop_color;
            this.exButton4.Location = new System.Drawing.Point(219, 16);
            this.exButton4.Name = "exButton4";
            this.exButton4.Size = new System.Drawing.Size(32, 32);
            this.exButton4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton4.TabIndex = 18;
            this.exButton4.TabStop = false;
            // 
            // exButton3
            // 
            this.exButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton3.Enabled = false;
            this.exButton3.Image = global::TubeDl.Properties.Resources.pause_color;
            this.exButton3.ImageDisable = global::TubeDl.Properties.Resources.pause_gray;
            this.exButton3.ImageEnable = global::TubeDl.Properties.Resources.pause_color;
            this.exButton3.Location = new System.Drawing.Point(153, 16);
            this.exButton3.Name = "exButton3";
            this.exButton3.Size = new System.Drawing.Size(32, 32);
            this.exButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton3.TabIndex = 17;
            this.exButton3.TabStop = false;
            // 
            // exButton2
            // 
            this.exButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton2.Enabled = false;
            this.exButton2.Image = global::TubeDl.Properties.Resources.start_color;
            this.exButton2.ImageDisable = global::TubeDl.Properties.Resources.start_gray;
            this.exButton2.ImageEnable = global::TubeDl.Properties.Resources.start_color;
            this.exButton2.Location = new System.Drawing.Point(80, 16);
            this.exButton2.Name = "exButton2";
            this.exButton2.Size = new System.Drawing.Size(32, 32);
            this.exButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exButton2.TabIndex = 16;
            this.exButton2.TabStop = false;
            // 
            // exButton1
            // 
            this.exButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exButton1.Image = global::TubeDl.Properties.Resources.add_white;
            this.exButton1.ImageDisable = ((System.Drawing.Image)(resources.GetObject("exButton1.ImageDisable")));
            this.exButton1.ImageEnable = global::TubeDl.Properties.Resources.add_white;
            this.exButton1.Location = new System.Drawing.Point(16, 16);
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
            this.youtubeSeperator7.Location = new System.Drawing.Point(402, 12);
            this.youtubeSeperator7.Name = "youtubeSeperator7";
            this.youtubeSeperator7.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator7.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator7.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator7.TabIndex = 14;
            // 
            // youtubeSeperator5
            // 
            this.youtubeSeperator5.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator5.Location = new System.Drawing.Point(335, 12);
            this.youtubeSeperator5.Name = "youtubeSeperator5";
            this.youtubeSeperator5.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator5.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator5.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator5.TabIndex = 12;
            // 
            // youtubeSeperator6
            // 
            this.youtubeSeperator6.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator6.Location = new System.Drawing.Point(469, 12);
            this.youtubeSeperator6.Name = "youtubeSeperator6";
            this.youtubeSeperator6.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator6.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator6.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator6.TabIndex = 10;
            // 
            // youtubeSeperator3
            // 
            this.youtubeSeperator3.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator3.Location = new System.Drawing.Point(268, 12);
            this.youtubeSeperator3.Name = "youtubeSeperator3";
            this.youtubeSeperator3.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator3.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator3.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator3.TabIndex = 9;
            // 
            // youtubeSeperator4
            // 
            this.youtubeSeperator4.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator4.Location = new System.Drawing.Point(200, 12);
            this.youtubeSeperator4.Name = "youtubeSeperator4";
            this.youtubeSeperator4.SeperatorColor = System.Drawing.Color.Gray;
            this.youtubeSeperator4.SeperatorStyle = YoutubeTheme.Skin.YoutubeSeperator.Style.Vertiacal;
            this.youtubeSeperator4.Size = new System.Drawing.Size(4, 40);
            this.youtubeSeperator4.TabIndex = 8;
            // 
            // youtubeSeperator2
            // 
            this.youtubeSeperator2.BackColor = System.Drawing.Color.Transparent;
            this.youtubeSeperator2.Location = new System.Drawing.Point(134, 12);
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
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exButton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exButton2)).EndInit();
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
        private ExButton exButton2;
        private ExButton exButton3;
        private ExButton exButton4;
        private ExButton exButton5;
        private ExButton exButton6;
        private FlatUI.FlatStatusBar flatStatusBar1;
        private ExButton exButton7;
    }
}