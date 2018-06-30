using System.IO;
using System.Text.RegularExpressions;

namespace Unkdevt
{
    public static class StringHelpers
    {


        public static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        public static string GetLengthString(double Length)
        {
            string Ext = "B";
            double L = Length;
            if (L > 1024)
            {
                L /= 1024;
                Ext = "kB";
            }

            if (L > 1024)
            {
                L /= 1024;
                Ext = "MB";
            }
            
            if (L > 1024)
            {
                L /= 1024;
                Ext = "GB";
            }

            return L.ToString("N1") + " " + Ext;
        }
        public static string InternetSpeed(double Length)
        {
            string Ext = "B/s";
            double L = Length;
            if (L > 1024)
            {
                L /= 1024;
                Ext = "kB/s";
            }

            if (L > 1024)
            {
                L /= 1024;
                Ext = "MB/s";
            }

            if (L > 1024)
            {
                L /= 1024;
                Ext = "GB/s";
            }

            return L.ToString("N1") + " " + Ext;
        }
    }
} 
