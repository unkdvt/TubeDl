using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            //initilize clipboard capture
            if (String.IsNullOrEmpty(Properties.Settings.Default.savepath))
            {
                Properties.Settings.Default.savepath = TubeDlHelpers.SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                Properties.Settings.Default.Save();
            }
            TubeDlHelpers.SavePath = Properties.Settings.Default.savepath;
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            var companyName = versionInfo.LegalTrademarks;
            Text = Application.ProductName + " " + Application.ProductVersion + companyName;

            list_Items.LostFocus += List_Items_LostFocus;
        }

        private void List_Items_LostFocus(object sender, EventArgs e)
        {
            enableButtons(false);
        }
        #region variables 
        #endregion

        #region Properties
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

        private static extern int SetClipboardViewer(int hWndNewViewer);

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
                    switch (select.ShowDialog())
                    {
                        case DialogResult.OK:
                            Download(TubeDlHelpers.downloadurl);
                            break;
                        case DialogResult.Ignore:
                            Download(TubeDlHelpers.downloadurl);
                            TubeDlHelpers.ldf[list_Items.Items.Count - 1].CancelDownload();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show(e.Message);
#endif
            }
        }
        #endregion

        #region methods


        public void Download(string link)
        {
            try
            {
                var ext = TubeDlHelpers.Extention();

                string vname = TubeDlHelpers.RemoveIllegalPathCharacters(TubeDlHelpers.video.Title)
                    + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + TubeDlHelpers.Extention();

                ListViewItem item = list_Items.FindItemWithText(vname);

                if (item != null)
                    MessageBox.Show(TubeDlHelpers.video.Resolution == 0 ? "Audio" : "Video" + " already in download list",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                // video exists           

                else
                {
                    // doesn't exist 

                    if (File.Exists(Path.Combine(TubeDlHelpers.SavePath, vname)))
                    {
                        if (MessageBox.Show("File Already exist, Replace?", Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            File.Delete(Path.Combine(TubeDlHelpers.SavePath, vname));

                            int indx = list_Items.Items.Count;
                            list_Items.Items.Add(vname);
                            for (int i = 1; i < 6; i++)
                            {
                                list_Items.Items[indx].SubItems.Add("");
                            }
                            list_Items.Items[indx].SubItems[5].Text = DateTime.Now.ToString("dd MMM HH:mm:ss");

                            DownloadHelper.downloadFile d =
                                new DownloadHelper.downloadFile(link, Path.Combine(TubeDlHelpers.SavePath, vname));
                            TubeDlHelpers.ldf.Add(d);

                            Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                            {
                                list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));
                            });

                            d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                            d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                            d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 4, size);
                            d.eSpeed += (object s1, string size) => act1.Invoke(indx, 3, size);
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
                        list_Items.Items[indx].SubItems[5].Text = DateTime.Now.ToString("dd MMM HH:mm:ss");
                        DownloadHelper.downloadFile d = new DownloadHelper.downloadFile(link, Path.Combine(TubeDlHelpers.SavePath, vname));
                        TubeDlHelpers.ldf.Add(d);

                        Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                        {
                            list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));
                        });

                        d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                        d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                        d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 4, size);
                        d.eSpeed += (object s1, string size) => act1.Invoke(indx, 3, size);
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                /// btndownload.Enabled = true;
                //btnPause.Enabled = false;

            }
        }

        private void OpenLocation()
        {
            if (list_Items.SelectedItems.Count == 1)
                Process.Start("explorer.exe", "/select," + Path.Combine(TubeDlHelpers.SavePath, list_Items.SelectedItems[0].SubItems[0].Text));
            else
                Process.Start("explorer.exe", TubeDlHelpers.SavePath);
        }
        #endregion
        private void exButton1_Click(object sender, EventArgs e)
        {
            try
            {
                nextClipboardViewer = IntPtr.Zero;
                var videoUrl = (string)Clipboard.GetData(DataFormats.Text);
                bool isYoutubeUrl = DownloadUrlResolver.TryNormalizeYoutubeUrl(videoUrl, out videoUrl);
                if (isYoutubeUrl)
                {
                    Url = videoUrl;
                    var select = new frmSelect(videoUrl);
                    switch (select.ShowDialog())
                    {
                        case DialogResult.OK:
                            Download(TubeDlHelpers.downloadurl);
                            break;
                        case DialogResult.Ignore:
                            Download(TubeDlHelpers.downloadurl);
                            TubeDlHelpers.ldf[list_Items.Items.Count].CancelDownload();
                            break;
                    }
                }
                if (!isYoutubeUrl)
                    nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);

#endif
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            backgroundWorker1.RunWorkerAsync();
        }

        void enableButtons(bool e)
        {

            btnDelete.Enabled = e;
            btnRemove.Enabled = e;
            btnStartDownload.Enabled = e;
            btnPauseDownload.Enabled = e;

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

                    btnDelete.Enabled = false;
                    btnRemove.Enabled = false;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = false;

                }
                else if (list_Items.SelectedItems.Count ==-1)
                {
                    btnDelete.Enabled = false;
                    btnRemove.Enabled = false;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = false;
                }
                else if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Downloading")
                {
                    resumeToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    removeFromListToolStripMenuItem.Enabled = false;
                    deletePermenatlyToolStripMenuItem.Enabled = false;

                    btnDelete.Enabled = false;
                    btnRemove.Enabled = false;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = true;
                }

                else if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Paused")
                {
                    pauseToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = false;
                    openToolStripMenuItem.Enabled = false;
                    removeFromListToolStripMenuItem.Enabled = true;
                    deletePermenatlyToolStripMenuItem.Enabled = true;

                    btnDelete.Enabled = true;
                    btnRemove.Enabled = true;
                    btnStartDownload.Enabled = true;
                    btnPauseDownload.Enabled = false;
                }
                else if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Completed")
                {
                    pauseToolStripMenuItem.Enabled = false;
                    resumeToolStripMenuItem.Enabled = false;
                    openFileLocationToolStripMenuItem.Enabled = true;
                    openToolStripMenuItem.Enabled = true;
                    removeFromListToolStripMenuItem.Enabled = true;
                    deletePermenatlyToolStripMenuItem.Enabled = true;

                    btnDelete.Enabled = true;
                    btnRemove.Enabled = true;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = false;

                }
                else
                {
                    btnDelete.Enabled = false;
                    btnRemove.Enabled = false;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = false;
                }
            }
            catch { }

        }

        private void Updatelist()
        {
            if (this.list_Items.SelectedIndices.Count > 0)
                for (int i = 0; i < this.list_Items.SelectedIndices.Count; i++)
                {
                    this.list_Items.Items[this.list_Items.SelectedIndices[i]].Selected = false;
                }
            list_Items.Update();
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
            switch (e.Cancel)
            {
                case true:
                    // list_Items.SelectedItems[0].Focused = false;
                    break;
            }
            //
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].CancelDownload();
            Updatelist();
            btnDelete.Enabled = true;
            btnRemove.Enabled = true;
            btnStartDownload.Enabled = true;
            btnPauseDownload.Enabled = false;
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].ResumeDownload();
            Updatelist();
            btnDelete.Enabled = false;
            btnRemove.Enabled = false;
            btnStartDownload.Enabled = false;
            btnPauseDownload.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "\"" + Path.Combine(TubeDlHelpers.SavePath, list_Items.SelectedItems[0].SubItems[0].Text) + "\"");
            Updatelist();

        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLocation();
            Updatelist();
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem l in list_Items.SelectedItems)
                {
                    if (list_Items.SelectedItems[0].SubItems[4].Text == "Paused")
                    {
                        try
                        {
                            TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[l.Index].Index);
                        }
                        catch { }
                        try
                        {

                            File.Delete(Path.Combine(TubeDlHelpers.SavePath, list_Items.SelectedItems[l.Index].SubItems[0].Text));
                        }
                        catch { }
                        list_Items.SelectedItems[l.Index].Remove();
                    }
                    if (list_Items.SelectedItems[l.Index].SubItems[4].Text == "Completed")
                    {
                        TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                        list_Items.SelectedItems[l.Index].Remove();
                    }
                }
            }
            catch { }
            Updatelist();

        }

        private void deletePermenatlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in list_Items.SelectedItems)
                if (list_Items.SelectedItems[l.Index].SubItems[4].Text == "Completed" || list_Items.SelectedItems[0].SubItems[4].Text == "Paused")
                {

                    try
                    {
                        if (MessageBox.Show("Are you sure, Do you want to move this file into recycle bin?", Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            FileSystem.DeleteFile(Path.Combine(TubeDlHelpers.SavePath, list_Items.SelectedItems[l.Index].SubItems[0].Text)
                                , UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException);
                            //  File.Delete(Path.Combine(TubeDlHelpers.SavePath, list_Items.SelectedItems[l.Index].SubItems[0].Text));
                            TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                            list_Items.SelectedItems[l.Index].Remove();
                        }
                    }
                    catch { }
                }
            Updatelist();
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem l in list_Items.Items)
                    if (list_Items.Items[l.Index].SubItems[4].Text == "Downloading")
                    {
                        TubeDlHelpers.ldf[list_Items.Items[l.Index].Index].CancelDownload();
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

                    foreach (ListViewItem items in list_Items.Items)
                    {
                        switch (items.SubItems[4].Text)
                        {
                            case "Completed":
                                Invoke(new Action(() => items.BackColor = Color.Lime));
                                break;
                            case "Paused":
                                Invoke(new Action(() => items.BackColor = Color.Yellow));
                                break;
                            case "Downloading":
                                Invoke(new Action(() => items.BackColor = Color.SteelBlue));
                                break;
                        }

                    }
                });
            }
            catch (Exception wx)
            {
#if DEBUG
                MessageBox.Show(wx.Message + "\n\n" + wx.StackTrace);
#endif
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
