using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using YoutubeExtractor;

namespace TubeDl
{
    public static class TubeDlHelpers
    {
        public static string downloadurl;
        public static VideoInfo video;
        public static Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        public static string customSavePath;
        public static string customeSavefileName;
        public static List<DownloadHelper.downloadFile> ldf = new List<DownloadHelper.downloadFile>();

        public static string savePath;

        private static bool custome;

        /// <summary>
        /// Custome location download
        /// </summary>
        public static bool Custome
        {
            set { custome = value; }
            get { return custome; }
        }

        private static bool combine;
        /// <summary>
        ///download 420p and 240p video files
        ///
        /// </summary>
        public static bool Combine
        {
            set { combine = value; }
            get { return combine; }
        }
        /// <summary>
        /// file savepath
        /// </summary>
        public static string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        public static string Extention()
        {

            var ext = TubeDlHelpers.video.Resolution.ToString();
            if (ext == "0")
                return ".mp3";
            else
                return ".Mp4";

        }


        public static string GetFileSize(Uri uriPath)
        {
            var webRequest = HttpWebRequest.Create(uriPath);
            webRequest.Method = "HEAD";

            using (var webResponse = webRequest.GetResponse())
            {
                var fileSize = webResponse.Headers.Get("Content-Length");
                var fileSizeInMegaByte = Unkdevt.StringHelpers.GetLengthString(Math.Round(
                    Convert.ToDouble(fileSize)));
                return fileSizeInMegaByte;
            }
        }
    }
}
