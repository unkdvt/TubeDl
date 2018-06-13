using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
    }
} 
