using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using YoutubeExtractor;

namespace TubeDl
{
    public static class TubeDlMethods
    {
        public static string downloadurl;
        public static VideoInfo video;
        public static Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed

        public static List<DownloadHelper.downloadFile> ldf = new List<DownloadHelper.downloadFile>();

        public static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        public static string GetFileSize(Uri uriPath)
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


    }
}
