using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degelate
{
    //委托定义四步走：
    //1. 定义委托
    //2. 声明委托实例
    //3. 委托注册（注册方法）
    //4. 调用委托

    
    class UseDelegate
    {
        //声明委托
        InfoHandler MyInfo;                     //委托实例
        
        public UseDelegate()
        {
            //委托注册
            MyInfo = new InfoHandler(InfoZhangSan);
            MyInfo += new InfoHandler(InfoLiSi);
            MyInfo += new InfoHandler(InfoWangWu);
            MyInfo += new InfoHandler(InfoGuaPi);
        }

        //调用委托
        public void Send()
        {
            MyInfo("我是前台小张");
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
    }
}
