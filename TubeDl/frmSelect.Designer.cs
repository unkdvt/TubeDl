namespace TubeDl
{
    partial class frmSelect
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblaudio = new System.Windows.Forms.Label();
            this.lblformat = new System.Windows.Forms.Label();
            this.lblsize = new System.Windows.Forms.Label();
            this.lblquality = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.exTextBox1 = new TextBoxWatermark.ExTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Youtube Video link";
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(228, 207);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(136, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Start &Download";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel download";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // cmbQuality
            // 
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Items.AddRange(new object[] {
            "1080p: 1920x1080 (no audio)",
            "720p: 1280x720",
            "480p: 854x480",
            "360p: 640x360",
            "240p: 426x240",
            "Mp3"});
            this.cmbQuality.Location = new System.Drawing.Point(405, 25);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(188, 21);
            this.cmbQuality.TabIndex = 13;
            this.cmbQuality.TabStop = false;
            this.cmbQuality.SelectedIndexChanged += new System.EventHandler(this.cmbQuality_SelectedIndexChanged);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblaudio);
            this.grpInfo.Controls.Add(this.lblformat);
            this.grpInfo.Controls.Add(this.lblsize);
            this.grpInfo.Controls.Add(this.lblquality);
            this.grpInfo.Controls.Add(this.lbltitle);
            this.grpInfo.Controls.Add(this.label12);
            this.grpInfo.Controls.Add(this.label11);
            this.grpInfo.Controls.Add(this.label10);
            this.grpInfo.Controls.Add(this.label9);
            this.grpInfo.Controls.Add(this.label8);
            this.grpInfo.Controls.Add(this.label7);
            this.grpInfo.Controls.Add(this.label6);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Location = new System.Drawing.Point(211, 52);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(386, 100);
            this.grpInfo.TabIndex = 15;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Download info";
            // 
            // lblaudio
            // 
            this.lblaudio.AutoEllipsis = true;
            this.lblaudio.AutoSize = true;
            this.lblaudio.Location = new System.Drawing.Point(293, 78);
            this.lblaudio.Name = "lblaudio";
            this.lblaudio.Size = new System.Drawing.Size(0, 13);
            this.lblaudio.TabIndex = 19;
            // 
            // lblformat
            // 
            this.lblformat.AutoEllipsis = true;
            this.lblformat.AutoSize = true;
            this.lblformat.Location = new System.Drawing.Point(103, 78);
            this.lblformat.Name = "lblformat";
            this.lblformat.Size = new System.Drawing.Size(0, 13);
            this.lblformat.TabIndex = 18;
            // 
            // lblsize
            // 
            this.lblsize.AutoEllipsis = true;
            this.lblsize.AutoSize = true;
            this.lblsize.Location = new System.Drawing.Point(103, 56);
            this.lblsize.Name = "lblsize";
            this.lblsize.Size = new System.Drawing.Size(0, 13);
            this.lblsize.TabIndex = 17;
            // 
            // lblquality
            // 
            this.lblquality.AutoEllipsis = true;
            this.lblquality.AutoSize = true;
            this.lblquality.Location = new System.Drawing.Point(103, 34);
            this.lblquality.Name = "lblquality";
            this.lblquality.Size = new System.Drawing.Size(0, 13);
            this.lblquality.TabIndex = 16;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoEllipsis = true;
            this.lbltitle.Location = new System.Drawing.Point(101, 16);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(275, 18);
            this.lbltitle.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(278, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Audio quality";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "File Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quality";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Set Download quality";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(211, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 20);
            this.textBox1.TabIndex = 17;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Mp4 Video files (*.Mp4)|*.mp4";
            this.saveFileDialog1.InitialDirectory = "D:\\";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save File";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(211, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(194, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Remeber this path for all downloads";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(86, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Download &later";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exTextBox1
            // 
            this.exTextBox1.Hint = null;
            this.exTextBox1.Location = new System.Drawing.Point(11, 25);
            this.exTextBox1.Name = "exTextBox1";
            this.exTextBox1.ReadOnly = true;
            this.exTextBox1.Size = new System.Drawing.Size(388, 20);
            this.exTextBox1.TabIndex = 9;
            // 
            // frmSelect
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(609, 242);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.exTextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "addDialog";
            this.Text = "Add Download";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private TextBoxWatermark.ExTextBox exTextBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblaudio;
        private System.Windows.Forms.Label lblformat;
        private System.Windows.Forms.Label lblsize;
        private System.Windows.Forms.Label lblquality;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}