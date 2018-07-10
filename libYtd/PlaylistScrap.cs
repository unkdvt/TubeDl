
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Unkdevt
{
    public static class PlaylistScrap
    {

        //https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50&playlistId=RDzoUBv75BC0I&key=AIzaSyArc5H7bBtQAB7CR9kypwqoBjaA_wM4V_s


        static string api = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50&playlistId=";
        static string apiKey = "&key=AIzaSyArc5H7bBtQAB7CR9kypwqoBjaA_wM4V_s";
        public static String ScrapPlaylist(string playlistID)
        {
            var request = WebRequest.Create(api + playlistID + apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            request.ContentType = "application/json";
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        public static Task ScrapPlaylistasync(string playlistID)
        {
            return Task.Run(() => videoList(playlistID));
        }

        public static class ListInfo
        {
            public static string Total { get; set; }

        }

        public static void videoList(string playlistID)
        {
            try
            {
                JObject blogPostArray = JObject.Parse(ScrapPlaylist(playlistID));
                ListInfo.Total = blogPostArray["pageInfo"]["totalResults"].ToString();
                ListInfo.Total = blogPostArray["pageInfo"]["totalResults"].ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
