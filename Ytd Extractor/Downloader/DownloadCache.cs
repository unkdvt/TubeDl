using FileDownloader;
using System;
using System.IO;
using System.Net;
using System.Text;

public class DownloadCache : IDownloadCache
{
    public void Add(Uri uri, string path, WebHeaderCollection headers)
    {
        string destinationFolder, destinationFileName;
        GetCacheFileName(uri, headers, out destinationFolder, out destinationFileName);

        Directory.CreateDirectory(destinationFolder);

        File.Copy(path, destinationFileName);
    }

    public string Get(Uri uri, WebHeaderCollection headers)
    {
        string destinationFolder, destinationFileName;
        GetCacheFileName(uri, headers, out destinationFolder, out destinationFileName);

        if (File.Exists(destinationFileName))
        {
            return destinationFileName;
        }
        return null;
    }

    public void Invalidate(Uri uri)
    {
        var fileName = MD5(uri.ToString());

        string destinationFolder = Path.Combine(Path.GetTempPath(), fileName);

        if (Directory.Exists(destinationFolder))
        {
            Directory.Delete(destinationFolder, true);
        }
    }

    private static void GetCacheFileName(Uri uri, WebHeaderCollection headers, out string destinationFolder, out string destinationFileName)
    {
        var etag = MD5(headers.Get("ETag"));
        var fileName = MD5(uri.ToString());

        destinationFolder = Path.Combine(Path.GetTempPath(), fileName);
        destinationFileName = Path.Combine(destinationFolder, etag);
    }

    private static string MD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
