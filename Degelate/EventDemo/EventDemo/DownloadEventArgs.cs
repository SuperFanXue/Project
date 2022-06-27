using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    //1. 声明事件参数类型
    public class DownloadEventArgs : EventArgs
    {
        public double Precent;
    }
}
