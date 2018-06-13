using FileDownloader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace Ytd_Extractor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
        }
        private static void DownloadAudio(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderByDescending(info => info.AudioBitrate)
                .First();

            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */

            var audioDownloader = new AudioDownloader(video,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RemoveIllegalPathCharacters(video.Title) + video.AudioExtension));

            // Register the progress events. We treat the download progress as 85% of the progress
            // and the extraction progress only as 15% of the progress, because the download will
            // take much longer than the audio extraction.
            audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
            audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            audioDownloader.Execute();
        }


        string url;
        string name;
        string savePath;
        VideoDownloader videoDownloader;
        IFileDownloader fileDownloader;
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        private static string GetFileSize(Uri uriPath)
        {
            var webRequest = HttpWebRequest.Create(uriPath);
            webRequest.Method = "HEAD";

            using (var webResponse = webRequest.GetResponse())
            {
                var fileSize = webResponse.Headers.Get("Content-Length");
                var fileSizeInMegaByte = View.Size.getlength.GetLengthString(Math.Round(
                    Convert.ToDouble(fileSize)));
                return fileSizeInMegaByte;
            }
        }


        private void btndownload_Click(object sender, EventArgs e)
        {

            /*
             * Execute the video downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            try
            {
                btndownload.Enabled = false;
                btnPause.Enabled = true;
                fileDownloader = new FileDownloader.FileDownloader();
                fileDownloader.DownloadFileCompleted += DownloadFileCompleted;
                fileDownloader.DownloadProgressChanged += FileDownloader_DownloadProgressChanged;
                fileDownloader.DownloadFileAsync(new Uri(url), Path.Combine(savePath, name));
            }
            catch (Exception ex)
            {
                rtlog.AppendText(ex.Message);
                btndownload.Enabled = true;
                btnPause.Enabled = false;

            }
        }//

        private void FileDownloader_DownloadProgressChanged(object sender, DownloadFileProgressChangedArgs e)
        {
            pbdown.Value = e.ProgressPercentage;
        }

        void DownloadFileCompleted(object sender, DownloadFileCompletedArgs eventArgs)
        {
            if (eventArgs.State == CompletedState.Succeeded)
            {
                btndownload.Enabled = false;
                btnPause.Enabled = false;

            }
            else if (eventArgs.State == CompletedState.Failed)
            {
                btndownload.Enabled = false;
                btnPause.Enabled = false;

            }
        }
        private void VideoDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
        }

        private void txtlink_TextChanged(object sender, EventArgs e)
        {

        }



        private void Main_Load(object sender, EventArgs e)
        {

            btndownload.Enabled = false;
            savePath = lblpath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            cmbQuality.SelectedIndex = 1;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = folderBrowserDialog1.SelectedPath;
                lblpath.Text = savePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtlink.Text))
                {
                    btndownload.Enabled = false;
                    return;
                }
                else
                {

                    // Our test youtube link
                    string link = txtlink.Text.Trim();

                    /*
                     * Get the available video formats.
                     * We'll work with them in the video and audio download examples.
                     */
                    IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link, false);

                    /*
                       * Select the first .mp4 video with 360p resolution
                       */
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
                    VideoInfo video = videoInfos
                        .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == vres);

                    /*
                     * If the video has a decrypted signature, decipher it
                     */
                    if (video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(video);
                    }


                    lbltitle.Text = video.Title;
                    lblformat.Text = video.VideoType.ToString();
                    lblsize.Text = GetFileSize(new Uri(video.DownloadUrl));
                    lblquality.Text = video.Resolution.ToString();
                    lblaudio.Text = video.AudioType.ToString() + " " + video.AudioBitrate.ToString();
                    
                    url = video.DownloadUrl;
                    name =
                       RemoveIllegalPathCharacters(video.Title) + video.VideoExtension;
                    btndownload.Enabled = true;
#if DEBUG
                    MessageBox.Show(url + "\n" + savePath + "\n" + name);
#endif
                    //https://www.youtube.com/watch?v=sTAIvHEvd48
                }
            }
            catch (Exception ex)
            {
                btndownload.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            fileDownloader.CancelDownloadAsync();
            btnPause.Enabled = false;
            btndownload.Enabled = true;
        }

        private void txtlink_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

