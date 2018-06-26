﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YoutubeExtractor;
using System.IO;
using System.Threading.Tasks;

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
            cmbQuality.SelectedIndex = 1;
        }

        private void frmSelect_Load(object sender, EventArgs e)
        {
            AcceptButton = btnOk;
            try
            {
                catchlink();
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }



        public async void catchlink()
        {
            //try
            //{
            if (string.IsNullOrWhiteSpace(url_))
            {
                return;
            }
            else
            {
                cmbQuality.Enabled = false;
                btnCancel.Enabled = false;
                btnOk.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                //    pbdown.Value = 0;
                // Our test youtube link
                string link = url_;
                pictureBox1.Image = Properties.Resources.loading;
                /*
                 * Get the available video formats.
                 * We'll work with them in the video and audio download examples.
                 */
                IEnumerable<VideoInfo> videoInfos = await DownloadUrlResolver.GetDownloadUrlsAsync(link);

                /*
                   * download selected quality video or extract audio
                   */
                if (cmbQuality.SelectedItem.ToString().Trim().Contains("Mp3"))
                {
                    TubeDlHelpers.video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 0 && info.AudioBitrate == 128);
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
                    TubeDlHelpers.video = videoInfos
                       .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == vres);
                }
#if DEBUG
                //  MessageBox.Show(TubeDlMethods.video.CanExtractAudio.ToString());
#endif
                /*
                 * If the video has a decrypted signature, decipher it
                 */
                if (TubeDlHelpers.video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(TubeDlHelpers.video);
                }

                /*
                 * show video info
                 * */
                lbltitle.Text = TubeDlHelpers.video.Title;
                if (TubeDlHelpers.video.Resolution.ToString() == ("0"))
                    lblformat.Text = "Mp3";
                else
                    lblformat.Text = "Mp4";
                lblquality.Text = TubeDlHelpers.video.Resolution.ToString() == ("0")
                    ? "Audio" : TubeDlHelpers.video.Resolution.ToString() + "p";
                lblsize.Text = TubeDlHelpers.GetFileSize(new Uri(TubeDlHelpers.video.DownloadUrl));
                lblaudio.Text = TubeDlHelpers.video.AudioType.ToString() + " " + TubeDlHelpers.video.AudioBitrate.ToString() + "kHz";
                var imgurl = "https://img.youtube.com/vi/" +
                    url_.Replace("http://", "").Replace("https://", "").Replace("www", "").Replace("youtube.com/watch?v=", "").Trim()
                    + "/0.jpg";
                pictureBox1.ImageLocation = imgurl;
                string vname = TubeDlHelpers.RemoveIllegalPathCharacters(TubeDlHelpers.video.Title)
            + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + TubeDlHelpers.Extention();

                TubeDlHelpers.downloadurl = TubeDlHelpers.video.DownloadUrl;
                textBox1.Text = Path.Combine(TubeDlHelpers.SavePath, vname);
                cmbQuality.Enabled = true;
                btnCancel.Enabled = true;
                btnOk.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
#if DEBUG
                //  textBox1.Text = imgurl;
                //  richTextBox1.Text = String.Join("\n", videoInfos).Replace(lbltitle.Text, "").Replace("Full", "").Replace("Title: ", "");

#endif
            }
            //}
            //catch (YoutubeParseException ex)
            //{
            //    //btndownload.Enabled = false;
            //    if (MessageBox.Show("Error while prase URL \n" + exTextBox1.Text, Text, MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            //    {
            //        catchlink();
            //    }
            //    else
            //    {
            //        Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK);
            //    Close();
            //}
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                catchlink();
            }
            catch { }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vname = TubeDlHelpers.RemoveIllegalPathCharacters(TubeDlHelpers.video.Title)
              + " " + (TubeDlHelpers.video.Resolution == 0 ? "" : TubeDlHelpers.video.Resolution.ToString() + "p") + TubeDlHelpers.Extention();

            TubeDlHelpers.customSavePath = "";
            saveFileDialog1.FileName = vname;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFullPath(TubeDlHelpers.customSavePath = saveFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }
    }
}
