namespace View.Size
{
    public static class getlength
    {
  
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
