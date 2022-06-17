using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketCommunication
{
    public class Server
    {
        private Socket SocketListen;
        private bool IsListenConnection = true;

        public Server()
        {
            //定义网络终端
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000); //127.0.0.1代表本机ip
            SocketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定终端
            SocketListen.Bind(ipep);
            //开启监听
            SocketListen.Listen();
            //SocketListen.Listen(10); 参数标识监听队列的最大长度

            Console.WriteLine("服务器端已经启动！");

            try
            {
                while(IsListenConnection)
                {
                    //accept():接受客户端的连接;
                    //这个方法会阻塞当前线程的运行
                    //所以需要实例化一个新的socket的线程，进行数据通信
                    Socket SocketMessage = SocketListen.Accept();
                    Console.WriteLine("有一个客户端连接。。。。。");

                    //开启后台线程，进行服务器端和客服端的会话
                    Thread ClientMsg = new Thread(ClientMessage);
                    ClientMsg.IsBackground = true; //定义此线程为后台线程
                    ClientMsg.Name = "ClientMsg";
                    ClientMsg.Start(SocketMessage); //SocketMessage 作为方法参数，传给ClientMessage;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        /// <summary>
        /// 服务器端与客户端通信的后台线程
        /// </summary>
        /// <param name="ob">表示为服务器端的会话</param>
        private void ClientMessage(object ob)
        {
            Socket socketMsg = ob as Socket;

            while(true)
            {
                //准备一个 数据缓存
                byte[] msgArray = new byte[1024 * 1024];
                //接受客户端发来的数据，存储到msgArray,并返回数据的真实长度；
                int trueClientMessageLength = socketMsg.Receive(msgArray);
                //byte数组转string
                string result = Encoding.UTF8.GetString(msgArray, 0, trueClientMessageLength);
                Console.WriteLine($"收到客服端的数据： {result}");
            }
        }
        static void Main(string[] args)
        {
            Server server = new Server();
            Console.ReadKey();
        }
    }
}
