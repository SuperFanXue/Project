using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degelate
{
    //如何使用事件
    class UseEvent
    {
        //声明委托
        //InfoHandler MyInfo;                     //委托实例

        //
        public event InfoHandler eveInform;
        public UseEvent()
        {
            //委托注册
            eveInform = new InfoHandler(InfoZhangSan);
            eveInform += new InfoHandler(InfoLiSi);
            eveInform += new InfoHandler(InfoWangWu);
            eveInform += new InfoHandler(InfoGuaPi);
        }

        //调用事件
        public void Send()
        {
            eveInform("我是前台小张");
        }
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
            Console.WriteLine($"{name}, 王五，老板来了！");
        }

        public void InfoGuaPi(string name)
        {
            Console.WriteLine($"{name}, 瓜皮，老板来了！");
        }

        public static void Main(string[] args)
        {
            UseEvent obj = new UseEvent();
            obj.Send();
            
    }
}
}
