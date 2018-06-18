using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
            if (String.IsNullOrEmpty(Properties.Settings.Default.savepath))
            {
                Properties.Settings.Default.savepath = SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.savepath = SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
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

        protected override void WndProc(ref System.Windows.Forms.Message m)
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
            //try
            //{
            IDataObject iData = new DataObject();
            iData = Clipboard.GetDataObject();


            if (iData.GetDataPresent(DataFormats.Text))
            {
                var videoUrl = (string)iData.GetData(DataFormats.Text);
                bool isYoutubeUrl = DownloadUrlResolver.TryNormalizeYoutubeUrl(videoUrl, out videoUrl);
                if (isYoutubeUrl)
                {
                    Url = videoUrl;
                    var select = new frmSelect(videoUrl);
                    if (select.ShowDialog() == DialogResult.OK)
                    {
                        Download(TubeDlMethods.video.DownloadUrl);
                    }
                }
            }
            //            }
            //            catch (Exception e)
            //            {
            //#if DEBUG
            //                MessageBox.Show(e.ToString());
            //#endif
            //            }
        }
        #endregion

        #region methods
        public void Download(string link)
        {
            //    try
            //   {
            var ext = TubeDlMethods.video.Resolution.ToString();
            if (ext == "0")
                ext = ".mp3";
            else
                ext = ".Mp4";

            var vname = TubeDlMethods.RemoveIllegalPathCharacters(TubeDlMethods.video.Title)
                + " " + (TubeDlMethods.video.Resolution == 0 ? ext.Replace(".", "") : TubeDlMethods.video.Resolution.ToString() + "p" + ext);
            ListViewItem item = list_Items.FindItemWithText(vname);

            if (item != null)
                MessageBox.Show(TubeDlMethods.video.Resolution == 0 ? "Audio" : "Video" + " already in download list",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            // video exists           

            else
            {

                // doesn't exist 


                if (File.Exists(Path.Combine(savePath, vname)))
                {
                    if (MessageBox.Show("File Already exist, Replace?", Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(Path.Combine(savePath, vname));

                        int indx = list_Items.Items.Count;
                        list_Items.Items.Add(vname);
                        for (int i = 1; i < 6; i++)
                        {
                            list_Items.Items[indx].SubItems.Add("");
                        }

                        DownloadHelper.downloadFile d =
                            new DownloadHelper.downloadFile(link, Path.Combine(savePath, vname));
                        TubeDlMethods.ldf.Add(d);

                        Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                        {
                            list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));

                        });

                        d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                        d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                        d.eSpeed += (object s1, string size) => act1.Invoke(indx, 3, size);
                        d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 4, size);
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

                    DownloadHelper.downloadFile d = new DownloadHelper.downloadFile(link, Path.Combine(savePath, vname));
                    TubeDlMethods.ldf.Add(d);

                    Action<int, int, object> act1 = new Action<int, int, object>(delegate (int idx, int sidx, object obj)
                    {
                        list_Items.Invoke(new Action(() => list_Items.Items[idx].SubItems[sidx].Text = obj.ToString()));



                    });

                    d.eSize += (object s1, string size) => act1.Invoke(indx, 1, size);
                    d.eDownloadedSize += (object s1, string size) => act1.Invoke(indx, 2, size);
                    d.eSpeed += (object s1, string size) => act1.Invoke(indx, 3, size);
                    d.eDownloadState += (object s1, string size) => act1.Invoke(indx, 4, size);
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
        #endregion
        private void exButton1_Click(object sender, EventArgs e)
        {
            var select = new frmSelect(Url);
            if (select.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
