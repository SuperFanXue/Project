using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class UserDownloader
    {
        static void Main(string[] args)
        {
            Downloader downloader = new Downloader();
            //6. 在事件的订阅者类中，注册事件
            downloader.Downing += ShowProgress;
            downloader.DoDownload();
        }

        //5. 在事件的订阅者中，写一个事件方法来表示事件发生时在执行的任务
        public static void ShowProgress(object sender, DownloadEventArgs e)
        {
            Console.WriteLine($"Downloading 。。。{e.Precent:##.#%}");
        }
    }
}
