using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degelate
{
    //定义委托
    public delegate void InfoHandler(string name);
    public class UsingDelegate
    {
        public void InfoZhangSan(string name)
        {
            Console.WriteLine($"{name}, 张三，老板来了！");
        }

        public void InfoLiSi(string name)
        {
            Console.WriteLine($"{name}, 李四，老板来了！");
        }

        public void InfoWangWu(string name)
        {
            Console.WriteLine($"{name}, 王五， 老板来了！");
        }

        public void InfoGuaPi(string name)
        {
            Console.WriteLine($"{name}, 瓜皮，老板来了！");
        }
        public void InfoAll(string name, InfoHandler infoDelegate)
        {
            infoDelegate(name);
        }

        public void SendInfo()
        {
            //声明委托(并“注册”了一个方法[张三方法])
            InfoHandler myInfo = new InfoHandler(InfoZhangSan);

            //多播委托
            myInfo += new InfoHandler(InfoLiSi);
            myInfo += new InfoHandler(InfoWangWu);
            myInfo += new InfoHandler(InfoGuaPi);

            //通知大家
            InfoAll("我是前台小张", myInfo);
        }
    }
}
