using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YoutubeExtractor;
namespace TubeDl
{
    public partial class frmSelect : Form
    {
        string url_;

        public frmSelect(string url)
        {
            if (url == null)
                Close();
            InitializeComponent();
            url_ = exTextBox1.Text = url;
           // Bitmap bm = new Bitmap(Properties.Resources.ok_colore, 21, 21);
          //  btnOk.Image = bm;
            cmbQuality.SelectedIndex = 1;
        }

        private void frmSelect_Load(object sender, EventArgs e)
        {
            AcceptButton = btnOk;
            textBox1.Text = Properties.Settings.Default.savepath;
            catchlink();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
          
            Close();
        }

        public void catchlink()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url_))
                {
                    return;
                }
                else
                {
                    //    pbdown.Value = 0;
                    // Our test youtube link
                    string link = url_;

                    /*
                     * Get the available video formats.
                     * We'll work with them in the video and audio download examples.
                     */
                    IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link, false);

                    /*
                       * download selected quality video or extract audio
                       */
                    if (cmbQuality.SelectedItem.ToString().Trim().Contains("Mp3"))
                    {
                        TubeDlMethods.video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 0 && info.AudioBitrate == 128);
                    }
                    else
                    {
                        int vres;
                        switch (cmbQuality.SelectedItem.ToString().Trim())
                        {
                            case "1080p: 1920x1080 (no audio)":
                                vres = 1080;
                                break;
                            case "720p: 1280x720":
                                vres = 720;
                                break;
                            case "480p: 854x480":
                                vres = 480;
                                break;
                            case "360p: 640x360":
                                vres = 360;
                                break;
                            case "240p: 426x240":
                                vres = 240;
                                break;

                            default:
                                vres = 720;
                                break;

                                /*1080p: 1920x1080 
                                720p: 1280x720
                                480p: 854x480
                                360p: 640x360
                                240p: 426x240*/

                        }
                        TubeDlMethods.video = videoInfos
                           .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == vres);
                    }
#if DEBUG
                    //  MessageBox.Show(TubeDlMethods.video.CanExtractAudio.ToString());
#endif
                    /*
                     * If the video has a decrypted signature, decipher it
                     */
                    if (TubeDlMethods.video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(TubeDlMethods.video);
                    }

                    /*
                     * show video info
                     * */
                    lbltitle.Text = TubeDlMethods.video.Title;
                    if (TubeDlMethods.video.Resolution.ToString() == ("0"))
                        lblformat.Text = "Mp3";
                    else
                        lblformat.Text = "Mp4";
                    lblquality.Text = TubeDlMethods.video.Resolution.ToString() == ("0")
                        ? "Audio" : TubeDlMethods.video.Resolution.ToString() + "p";
                    lblsize.Text = TubeDlMethods.GetFileSize(new Uri(TubeDlMethods.video.DownloadUrl));
                    lblaudio.Text = TubeDlMethods.video.AudioType.ToString() + " " + TubeDlMethods.video.AudioBitrate.ToString() + "kHz";
                    var imgurl = "https://img.youtube.com/vi/" +
                        url_.Replace("http://", "").Replace("https://", "").Replace("www", "").Replace("youtube.com/watch?v=", "").Trim()
                        + "/0.jpg";
                    pictureBox1.ImageLocation = imgurl;
                    TubeDlMethods.downloadurl = TubeDlMethods.video.DownloadUrl;
#if DEBUG
                    //  textBox1.Text = imgurl;
                    //  richTextBox1.Text = String.Join("\n", videoInfos).Replace(lbltitle.Text, "").Replace("Full", "").Replace("Title: ", "");

#endif
                }
            }
            catch (YoutubeParseException ex)
            {
                //btndownload.Enabled = false;
                if (MessageBox.Show("Error while prase URL \n" + exTextBox1.Text, Text, MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    catchlink();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK);
                Close();
            }
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            catchlink();
        }
    }
}
