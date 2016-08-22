using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sync
            SyncGet();
            #endregion

            #region EventAsyncGet
            EventAsyncGet();
            #endregion

            #region DownLoadAsyncTwoTimes
            DownLoadAsyncTwoTimes();

            //async 和 await
            DownloadTaskAsync();
            #endregion

        }

        #region sync
        private static void SyncGet()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var url = "http://www.microsoft.com";
            Uri uri = new Uri(url);
            Console.WriteLine(client.DownloadString(url));
        }
        #endregion

        #region EventAsyncGet
        private static void EventAsyncGet()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var url = "http://www.microsoft.com";
            Uri uri = new Uri(url);
            client.DownloadStringAsync(uri);
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
        }
        private static void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            File.WriteAllText("result.txt", e.Result);
        }
        #endregion

        #region DownLoadAsyncTwoTimes
        /// <summary>
        /// 假设有这样一个场景，一个 C# 应用程序中（WinForm Or WPF）我需要从一个网站上下载一个内容，然后再根据内容里的网址再下载里面的内容
        /// 如果直接利用 WebClient 的 DownloadString 方法，很明显 UI 线程会被阻塞，没人会这么做
        ///如果只是一次下载，那利用 WebClient 的 DownloadStringAsync 就可以轻松解决了，
        ///但是如果是想这样需要两次下载，而且两次下载是有关联的呢？如果是三次四次呢？ 
        /// </summary>
        protected static void DownLoadAsyncTwoTimes()

        {

            WebClient client = new WebClient();

            client.DownloadStringCompleted += client_DownloadStringCompleted;

            client.DownloadStringAsync(new Uri("http://www.baidu.com"));

        }

        static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)

        {

            WebClient client = new WebClient();

            client.DownloadStringCompleted += client_DownloadStringCompleted2;

            client.DownloadStringAsync(new Uri(e.Result));

        }

        static void client_DownloadStringCompleted2(object sender, DownloadStringCompletedEventArgs e)

        {

            var result = e.Result;

            //do more 

        }
        #endregion

        #region async and await
        protected static async void DownloadTaskAsync()
        {

            WebClient client = new WebClient();

            var result1 = await client.DownloadStringTaskAsync("http://www.baidu.com");

            WebClient client2 = new WebClient();

            var result2 = await client.DownloadStringTaskAsync(result1);

            //do more 

        }
        #endregion
    }
}
