using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketClient
{
    public class Client
    {
        private Socket socketClient;
        private IPEndPoint ipep;

        public Client()
        {
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000);
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketClient.Connect(ipep);
            }
            catch
            {

            }
            Console.WriteLine("连接服务器成功！");
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        public void SendMsg()
        {
            while(true)
            {
                Console.WriteLine("请输入信息：");
                string str = Console.ReadLine();
                Byte[] byteArray = Encoding.UTF8.GetBytes(str);

                if(str == "exit")
                {
                    break;
                }
                //发送数据
                socketClient.Send(byteArray);
                Console.WriteLine($"Send: {str}");
            }
            //关闭连接
            socketClient.Shutdown(SocketShutdown.Both);
            //清理连接的资源
            socketClient.Close();

        }
        static void Main(string[] args)
        {
            Client client = new Client();
            client.SendMsg();
            Console.ReadKey();
        }
    }
}
