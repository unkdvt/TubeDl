using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YoutubeExtractor;

namespace TubeDl
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //initilize clipboard capture
            if (String.IsNullOrEmpty(Properties.Settings.Default.savepath))
            {
                Properties.Settings.Default.savepath = SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                Properties.Settings.Default.Save();
            }
            SavePath = Properties.Settings.Default.savepath;
        }
        #region variables 
        #endregion
        #region Properties

        string savePath;
        /// <summary>
        /// file savepath
        /// </summary>
        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        string url;
        /// <summary>
        /// video url 
        /// </summary>
        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        #endregion

        #region DllImportAttributes
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Clipboard Capture
        IntPtr nextClipboardViewer;

        protected override void WndProc(ref Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void DisplayClipboardData()
        {
            try
            {

                var videoUrl = (string)Clipboard.GetData(DataFormats.Text);
                bool isYoutubeUrl = DownloadUrlResolver.TryNormalizeYoutubeUrl(videoUrl, out videoUrl);
                if (isYoutubeUrl)
                {
                    Url = videoUrl;
                    var select = new frmSelect(videoUrl);
                    if (select.ShowDialog() == DialogResult.OK)
                    {
                        Download(TubeDlMethods.downloadurl);
                    }
                }

            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show(e.ToString());
#endif
            }
        }
        #endregion

        #region methods

        private string Extention()
        {
            var ext = TubeDlMethods.video.Resolution.ToString();
            if (ext == "0")
                return ".mp3";
            else
                return ".Mp4";

        }
        public void Download(string link)
        {
            //    try
            //   {
            var ext = Extention();

            var vname = TubeDlMethods.RemoveIllegalPathCharacters(TubeDlMethods.video.Title)
                + " " + (TubeDlMethods.video.Resolution == 0 ? "" : TubeDlMethods.video.Resolution.ToString() + "p") + ext;

            ListViewItem item = list_Items.FindItemWithText(vname);

            if (item != null)
                MessageBox.Show(TubeDlMethods.video.Resolution == 0 ? "Audio" : "Video" + " already in download list",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            // video exists           

            else
            {
                // doesn't exist 

                if (File.Exists(Path.Combine(Properties.Settings.Default.savepath, vname)))
                {
                    if (MessageBox.Show("File Already exist, Replace?", Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(Path.Combine(Properties.Settings.Default.savepath, vname));

                        int indx = list_Items.Items.Count;
                        list_Items.Items.Add(vname);
                        for (int i = 1; i < 6; i++)
                        {
                            list_Items.Items[indx].SubItems.Add("");
                        }
                        list_Items.Items[indx].SubItems[4].Text = DateTime.Now.ToString("dd-mm-yyy hh:mm:ss");

                        DownloadHelper.downloadFile d =
                            new DownloadHelper.downloadFile(link, Path.Combine(Properties.Settings.Default.savepath, vname));
                        TubeDlMethods.ldf.Add(d);

                        Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                        {
                            list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));
                        });

                        d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                        d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                        d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 3, size);
                    }
                    else
                    {
                        // btndownload.Enabled = true;
                        // btnPause.Enabled = false;
                    }
                }
                else
                {
                    int indx = list_Items.Items.Count;
                    list_Items.Items.Add(vname);
                    for (int i = 1; i < 6; i++)
                    {
                        list_Items.Items[indx].SubItems.Add("");
                    }
                    list_Items.Items[indx].SubItems[4].Text = DateTime.Now.ToString("dd-mm-yyy hh:mm:ss");
                    DownloadHelper.downloadFile d = new DownloadHelper.downloadFile(link, Path.Combine(Properties.Settings.Default.savepath, vname));
                    TubeDlMethods.ldf.Add(d);

                    Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                    {
                        list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));
                    });

                    d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                    d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                    d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 3, size);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    /// btndownload.Enabled = true;
            //    //btnPause.Enabled = false;

            //}
        }

        private void OpenLocation()
        {
            if (list_Items.SelectedItems.Count == 1)
                System.Diagnostics.Process.Start("explorer.exe", "/select," + Path.Combine(Properties.Settings.Default.savepath, list_Items.SelectedItems[0].SubItems[0].Text));
            else
                System.Diagnostics.Process.Start("explorer.exe", Properties.Settings.Default.savepath);


        }
        #endregion
        private void exButton1_Click(object sender, EventArgs e)
        {
            var videoUrl = (string)Clipboard.GetData(DataFormats.Text);
            bool isYoutubeUrl = DownloadUrlResolver.TryNormalizeYoutubeUrl(videoUrl, out videoUrl);
            if (isYoutubeUrl)
            {
                Url = videoUrl;
                var select = new frmSelect(videoUrl);
                if (select.ShowDialog() == DialogResult.OK)
                {
                    Download(TubeDlMethods.downloadurl);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            backgroundWorker1.RunWorkerAsync();
        }

        private void list_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pauseToolStripMenuItem.Enabled = true; //pause
                resumeToolStripMenuItem.Enabled = true; //resume
                openFileLocationToolStripMenuItem.Enabled = true; //open
                openToolStripMenuItem.Enabled = true; //open target
                removeFromListToolStripMenuItem.Enabled = true; //remove from list
                deletePermenatlyToolStripMenuItem.Enabled = true; //delete


                if (list_Items.SelectedItems.Count > 1)
                {
                    pauseToolStripMenuItem.Enabled = false;
                    resumeToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = false;

                }
                else if (TubeDlMethods.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Downloading")
                {
                    resumeToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    removeFromListToolStripMenuItem.Enabled = false;
                    deletePermenatlyToolStripMenuItem.Enabled = false;
                }

                else if (TubeDlMethods.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Paused")
                {
                    pauseToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    removeFromListToolStripMenuItem.Enabled = true;
                    deletePermenatlyToolStripMenuItem.Enabled = true;
                }
                else if (TubeDlMethods.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Completed")
                {
                    pauseToolStripMenuItem.Enabled = false;
                    resumeToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = true;
                    openToolStripMenuItem.Enabled = true;
                    removeFromListToolStripMenuItem.Enabled = true;
                    deletePermenatlyToolStripMenuItem.Enabled = true;

                }
            }
            catch { }
        }

        private void btnTargetFolder_Click(object sender, EventArgs e)
        {
            OpenLocation();
        }

        private void list_Items_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (list_Items.SelectedItems.Count < 1)
            {
                e.Cancel = true;
            }
            //
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TubeDlMethods.ldf[list_Items.SelectedItems[0].Index].CancelDownload();

        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TubeDlMethods.ldf[list_Items.SelectedItems[0].Index].ResumeDownload();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + Path.Combine(Properties.Settings.Default.savepath, list_Items.SelectedItems[0].SubItems[0].Text) + "\"");
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLocation();
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_Items.SelectedItems[0].SubItems[3].Text == "Paused")
            {
                try
                {
                    TubeDlMethods.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                }
                catch { }
                try
                {
                    File.Delete(Path.Combine(Properties.Settings.Default.savepath, list_Items.SelectedItems[0].SubItems[0].Text));
                }
                catch { }
                list_Items.SelectedItems[0].Remove();
            }

            else
                foreach (ListViewItem l in list_Items.SelectedItems)
                    if (list_Items.SelectedItems[l.Index].SubItems[3].Text == "Completed")
                    {
                        TubeDlMethods.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                        list_Items.SelectedItems[l.Index].Remove();
                    }
        }

        private void deletePermenatlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in list_Items.SelectedItems)
                if (list_Items.SelectedItems[l.Index].SubItems[3].Text == "Completed" || list_Items.SelectedItems[0].SubItems[3].Text == "Paused")
                {
                    TubeDlMethods.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                    list_Items.SelectedItems[l.Index].Remove();
                    try
                    {
                        if (MessageBox.Show("Are you sure, Do you want to delete file\nThis action cannot be undone!", Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            File.Delete(Path.Combine(Properties.Settings.Default.savepath, list_Items.SelectedItems[l.Index].SubItems[0].Text));
                    }
                    catch { }
                }
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem l in list_Items.Items)
                    if (list_Items.Items[l.Index].SubItems[3].Text == "Downloading")
                    {
                        TubeDlMethods.ldf[list_Items.Items[l.Index].Index].CancelDownload();
                    }
            }
            catch { }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    foreach (ListViewItem l in list_Items.Items)
                        if (list_Items.Items[l.Index].SubItems[3].Text == "Downloading")
                        {
                            Invoke(new Action(() => btnStopDownload.Enabled = true));
                        }
                        else
                        {
                            Invoke(new Action(() => btnStopDownload.Enabled = false));

                        }
                });
            }
            catch { }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
