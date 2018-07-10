using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YoutubeExtractor;
using Unkdevt;
using System.Text;

namespace TubeDl
{
    public partial class frmMain : Form
    {

        //for testing : https://www.youtube.com/watch?v=IYfejxVZ7lg
        public frmMain()
        {
            InitializeComponent();
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            if (String.IsNullOrEmpty(Properties.Settings.Default.savepath))
            {
                Properties.Settings.Default.savepath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                Properties.Settings.Default.Save();
            }
            TubeDlHelpers.SavePath = Properties.Settings.Default.savepath;
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var ReleaseType = versionInfo.LegalTrademarks;
            Text = Application.ProductName + " " + Application.ProductVersion + ReleaseType;
        }


        #region variables 
        string path_;
        bool capture_ = false;
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
                var select = new frmDownloadDialog(videoUrl);

                Form fc = Application.OpenForms[select.Name];//multipe time opening bug fixed

                if (fc == null)
                    if (isYoutubeUrl)
                    {
                        Url = videoUrl;

                        switch (select.ShowDialog())
                        {
                            case DialogResult.OK:
                                if (TubeDlHelpers.Combine)
                                {
                                    if (TubeDlHelpers.Custome)
                                    {
                                        Download(TubeDlHelpers.downloadurl,
                                            true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName);
                                        Download(TubeDlHelpers.downloadurl,
                                               true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName.Replace(".mp4", ".mp3"));
                                        combineid++;
                                    }
                                    else
                                    {
                                        string vname = StringHelpers.RemoveIllegalPathCharacters(TubeDlHelpers.video.Title)
                           + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + ".mp4";

                                        string aname = StringHelpers.RemoveIllegalPathCharacters(TubeDlHelpers.video.Title)
                           + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + ".mp3";

                                        Download(TubeDlHelpers.downloadurl,
                                          true, TubeDlHelpers.SavePath, vname);
                                        Download(TubeDlHelpers.downloadurl,
                                               true, TubeDlHelpers.SavePath, aname);
                                        combineid++;
                                    }
                                }
                                else if (TubeDlHelpers.Custome)
                                    Download(TubeDlHelpers.downloadurl, true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName);
                                else
                                    Download(TubeDlHelpers.downloadurl);
                                break;

                            case DialogResult.Ignore:
                                if (TubeDlHelpers.Custome)
                                    Download(TubeDlHelpers.downloadurl, true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName);
                                else
                                    Download(TubeDlHelpers.downloadurl);
                                TubeDlHelpers.ldf[list_Items.Items.Count - 1].CancelDownload();
                                break;

                        }
                    }
            }
            catch (Exception e)
            {
#if DEBUG
                //      MessageBox.Show(e.Message);
#endif
            }
        }
        #endregion

        #region Functions
        private void Updatelist()
        {
            if (this.list_Items.SelectedIndices.Count > 0)
                for (int i = 0; i < this.list_Items.SelectedIndices.Count; i++)
                {
                    this.list_Items.Items[this.list_Items.SelectedIndices[i]].Selected = false;
                }
            list_Items.Update();
        }
        void enableButtons(bool e)
        {

            btnDelete.Enabled = e;
            btnRemove.Enabled = e;
            btnStartDownload.Enabled = e;
            btnPauseDownload.Enabled = e;

        }

        int combineid = 0;
        public void Download(string link)
        {
            Download(link, false, "", "");
        }
        public void Download(string link, bool custome, string path, string filename)
        {
            try
            {
                var ext = TubeDlHelpers.Extention();


                string vname = TubeDlHelpers.Combine ? filename :

                    StringHelpers.RemoveIllegalPathCharacters(custome ? filename : TubeDlHelpers.video.Title)
                    + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + TubeDlHelpers.Extention();

                path_ = (custome ? path : TubeDlHelpers.SavePath);
                ListViewItem item = list_Items.FindItemWithText(vname);

                if (item != null)
                    MessageBox.Show(TubeDlHelpers.video.Resolution == 0 ? "Audio" : "Video" + " already in download list",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                // video exists           

                else
                {
                    // doesn't exist 

                    if (File.Exists(Path.Combine(custome ? path : path_, vname)))
                    {
                        var msg = new MsgBox("\'" + vname + "\' Already exist in " + path_ +
                            "\r\nReplace file in destination ? ", Text, "Replace", "Add duplicate", DialogResult.Yes, DialogResult.No);
                        switch (msg.ShowDialog())
                        {
                            case DialogResult.Yes:
                                File.Delete(Path.Combine(path_, vname));
                                break;
                            case DialogResult.No:
                                int count = 0;
                                string added;

                                do
                                {
                                    count++;
                                    added = "(" + count + ")";
                                } while (File.Exists(Path.Combine(custome ? path : path_, vname.Replace(ext, " " + added + ext))));

                                vname = vname.Replace(ext, " " + added + ext);
                                break;
                        }
                    }
                    int indx = list_Items.Items.Count;
                    list_Items.Items.Add(vname);
                    for (int i = 1; i < 7; i++)
                    {
                        list_Items.Items[indx].SubItems.Add("");
                    }
                    list_Items.Items[indx].SubItems[5].Text = DateTime.Now.ToString();
                    if (TubeDlHelpers.Combine)
                    {
                        list_Items.Items[indx].SubItems[6].Text = combineid.ToString();
                    }
                    DownloadHelper.downloadFile d = new DownloadHelper.downloadFile(link, Path.Combine(path_, vname));
                    TubeDlHelpers.ldf.Add(d);

                    Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                    {
                        list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));
                    });

                    d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                    d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, String.Format("{0} ({1})", size,
                        Math.Round((TubeDlHelpers.ldf[indx].DownloadedLength / TubeDlHelpers.filesize) * 100) + "%"));
                    d.eSpeed += (object s1, string size) => act1.Invoke(indx, 3, size);
                    d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 4, size);
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
#endif
                /// btndownload.Enabled = true;
                //btnPause.Enabled = false;

            }
        }

        private void OpenLocation()
        {

            if (list_Items.SelectedItems.Count == 1)
                Process.Start("explorer.exe", "/select," + TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].FilePath);
            else
                Process.Start("explorer.exe", TubeDlHelpers.SavePath);
        }
        #endregion

        #region Events
        private void exButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var add = new frmAddlink();
                switch (add.ShowDialog())
                {
                    case DialogResult.OK:
                        if (TubeDlHelpers.Custome)
                            Download(TubeDlHelpers.downloadurl, true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName);
                        else
                            Download(TubeDlHelpers.downloadurl);
                        break;

                    case DialogResult.Ignore:
                        if (TubeDlHelpers.Custome)
                            Download(TubeDlHelpers.downloadurl, true, Path.GetDirectoryName(TubeDlHelpers.customSavePath), TubeDlHelpers.customeSavefileName);
                        else
                            Download(TubeDlHelpers.downloadurl);
                        TubeDlHelpers.ldf[list_Items.Items.Count - 1].CancelDownload();
                        break;

                }
            }
            catch (Exception ex)
            {
#if DEBUG
                //MessageBox.Show(ex.Message);
#endif
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
            label1.Text = string.Format("{0} : {1}", "Default Download Location", TubeDlHelpers.savePath);
            backgroundWorker1.RunWorkerAsync();
            // backgroundWorker2.RunWorkerAsync();

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
                if (list_Items.SelectedItems.Count == 0)
                {
                    btnDelete.Enabled = false;
                    btnRemove.Enabled = false;
                    btnStartDownload.Enabled = false;
                    btnPauseDownload.Enabled = false;
                }
                if (list_Items.SelectedItems.Count == 1)
                {
                    if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Downloading")
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

                    if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Paused")
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
                    if (TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].DownloadState == "Completed")
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
            if (list_Items.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }

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
            Process.Start("explorer.exe", TubeDlHelpers.ldf[list_Items.SelectedItems[0].Index].FilePath);
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

                if (list_Items.SelectedItems[0].SubItems[4].Text == "Paused")
                {
                    try
                    {
                        TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                    }
                    catch { }
                    try
                    {

                        File.Delete(Path.Combine(path_, list_Items.SelectedItems[0].SubItems[0].Text));
                    }
                    catch { }
                    list_Items.SelectedItems[0].Remove();
                }
                if (list_Items.SelectedItems[0].SubItems[4].Text == "Completed")
                {
                    TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                    list_Items.SelectedItems[0].Remove();
                }

            }
            catch { }
            Updatelist();

        }

        private void deletePermenatlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem l in list_Items.SelectedItems)
                    if (list_Items.SelectedItems[0].SubItems[4].Text == "Completed" || list_Items.SelectedItems[0].SubItems[4].Text == "Paused")
                    {
                        if (MessageBox.Show("Are you sure, Do you want to move this file into recycle bin?", Text,
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            try
                            {
                                FileSystem.DeleteFile(Path.Combine(path_, list_Items.SelectedItems[0].SubItems[0].Text)
                                    , UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException);
                                File.Delete(Path.Combine(path_, list_Items.SelectedItems[0].SubItems[0].Text));
                                TubeDlHelpers.ldf.RemoveAt(list_Items.SelectedItems[0].Index);
                                list_Items.SelectedItems[0].Remove();

                            }
                            catch { }
                        }
                    }
                Updatelist();
            }
            catch { }
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    foreach (ListViewItem l in list_Items.Items)
            //        if (list_Items.Items[0].SubItems[4].Text == "Downloading")
            //        {
            //            TubeDlHelpers.ldf[list_Items.Items[0].Index].CancelDownload();
            //        }
            //}
            //catch { }
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
                                Invoke(new Action(() => items.BackColor = Color.AliceBlue));
                                break;
                            case "Combining..":
                                Invoke(new Action(() => items.BackColor = Color.DarkOrange));
                                break;
                            case "Done":
                                Invoke(new Action(() => items.BackColor = Color.Lime));
                                break;

                        }

                    }


                    if (list_Items.SelectedItems.Count == 0)
                    {
                        Invoke(new Action(() => enableButtons(false)));
                    }
                    int downcount = 0;
                    int pausedcount = 0;
                    int compcount = 0;
                    foreach (ListViewItem ls in list_Items.Items)
                    {
                        if (ls.SubItems[4].Text == "Downloading")
                            downcount++;
                        if (ls.SubItems[4].Text == "Paused")
                            pausedcount++;
                        if (ls.SubItems[4].Text == "Completed")
                            compcount++;
                    }

                    toolStripStatusLabel1.Text =
                        "*Active downloads - " + downcount + "  |  *Paused - " + pausedcount + "  |  *Completed - " + compcount;

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


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            int count = 0;
            foreach (ListViewItem ls in list_Items.Items)
            {
                if (ls.SubItems[4].Text == "Downloading" || ls.SubItems[4].Text == "Paused")
                    count++;
            }

            if (count > 0)
            {
                if (MessageBox.Show("There " + count + " reaming active downloads.\nDo you want to ext now?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    e.Cancel = true;
            }
        }
        #endregion

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (TubeDlHelpers.Custome)
                {

                    BeginInvoke((MethodInvoker)delegate
                    {

                        foreach (ListViewItem items in list_Items.Items)
                            if (items.SubItems[6].Text == items.FindNearestItem(SearchDirectionHint.Down).SubItems[6].Text)
                                MessageBox.Show("looaokoksakd");
                    });
                }
            }
            catch (Exception) { }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //try
            //{
            //    if (!TubeDlHelpers.Custome)
            //    {

            //        BeginInvoke((MethodInvoker)delegate
            //        {

            //            foreach (ListViewItem item in list_Items.Items)
            //            {
            //                try
            //                {
            //                    if (item.SubItems[4].Text == "Completed")
            //                        if (item.SubItems[6].Text == list_Items.Items[item.Index + 1].SubItems[6].Text)
            //                        {
            //                            var s = Path.Combine(TubeDlHelpers.Custome ? Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath,
            //                                list_Items.Items[item.Index].Text);
            //                            var dis = Path.Combine(TubeDlHelpers.Custome ? Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath,
            //                                "video.mp4");
            //                            File.Move(s, dis);

            //                            var s1 = Path.Combine(TubeDlHelpers.Custome ? Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath,
            //                                list_Items.Items[item.Index + 1].Text);
            //                            var dis1 = Path.Combine(TubeDlHelpers.Custome ? Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath,
            //                                "audio.mp3");
            //                            File.Move(s1, dis1);

            //                            MessageBox.Show(s + "\n" + dis);
            //                            MessageBox.Show(s1 + "\n" + dis1);
            //                            MessageBox.Show(Path.Combine(TubeDlHelpers.Custome ?
            //                            Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath, item.Text));

            //                            Process process = new Process();
            //                            process.StartInfo.WorkingDirectory = Application.StartupPath;
            //                            process.StartInfo.FileName = "ffmpeg.exe";
            //                            process.StartInfo.Arguments = "-i " + dis + " -i " + dis1
            //                            + " -c:v copy -c:a aac -strict experimental -map 0:v:0 -map 1:a:0 " + Path.Combine(TubeDlHelpers.Custome ?
            //                            Path.GetDirectoryName(TubeDlHelpers.customSavePath) : TubeDlHelpers.SavePath, item.Text);
            //                            process.StartInfo.UseShellExecute = false;
            //                            process.StartInfo.CreateNoWindow = true;
            //                            process.StartInfo.RedirectStandardError = true;
            //                            process.Exited += Process_Exited;
            //                            process.ErrorDataReceived += new DataReceivedEventHandler((sendexr, ex) =>
            //                            {
            //                                // Prepend line numbers to each line of the output.
            //                                if (!String.IsNullOrEmpty(ex.Data))
            //                                {
            //                                    if (!ex.Data.Contains("overhead"))
            //                                    {
            //                                        Invoke(new Action(() => item.SubItems[6].Text = "Combining.."));
            //                                    }
            //                                    else
            //                                    {
            //                                        Invoke(new Action(() => item.SubItems[6].Text = "Completed"));
            //                                        Invoke(new Action(() => list_Items.Items[item.Index + 1].Remove()));
            //                                        Invoke(new Action(() => TubeDlHelpers.ldf.RemoveAt(item.Index + 1)));
            //                                    }
            //                                }
            //                            });

            //                            process.Start();

            //                            // Asynchronously read the standard output of the spawned process. 
            //                            // This raises OutputDataReceived events for each line of output.
            //                            process.BeginErrorReadLine();

            //                        }
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                }
            //            }
            //        });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void Process_Exited(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var msg = new MsgBox("Already exist in \r\nReplace file in destination ? ", Text, "Replace", "Add duplicate", DialogResult.Yes, DialogResult.No);
            msg.ShowDialog();
        }

        private void list_Items_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            toolTip1.SetToolTip(this.list_Items, e.Item.Text);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PlaylistScrap.videoList("RDzoUBv75BC0I");
            richTextBox1.Text = PlaylistScrap.ListInfo.Total;
        }
    }
}
