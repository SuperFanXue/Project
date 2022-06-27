using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    //2. 定义委托类型
    public delegate void DownloadEventHandler(object sender, DownloadEventArgs e);

    //定义事件源类
    public class Downloader
    {
        //3. 定义一个事件
        public event DownloadEventHandler Downing;

        public void DoDownload()
        {
            double total = 10000; //下载总量
            double already = 0;   //已下载量
            Random rnd = new Random();
            while(already < total)
            {
                System.Threading.Thread.Sleep(500);
                already += (rnd.NextDouble() / 4) * total;
                if(already > total)
                {
                    already = total;
                }
                //4. 在合适的时候，生成事件参数，并调用事件
                if(Downing != null)
                {
                    DownloadEventArgs args = new DownloadEventArgs();
                    args.Precent = already / total;
                    Downing(this, args);
                }
            }
        }
    }
}
