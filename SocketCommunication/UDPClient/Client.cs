using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace UDPClient
{
    public class Client
    {
        private Socket socketClient;
        private IPEndPoint ipep;

        public Client()
        {
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2000);
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socketClient.Bind(ipep);

            while(true)
            {
                EndPoint ep = (EndPoint)ipep;
                Console.WriteLine("请输入发送信息：");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                byte[] bufferoutput = new byte[1024 * 1024];
                bufferoutput = Encoding.UTF8.GetBytes(input);
                socketClient.SendTo(bufferoutput, ep);
                //int length2 = socketClient.ReceiveFrom(bufferoutput, ref ep);
                //string result = Encoding.UTF8.GetString(bufferoutput, 0, length2);
                //Console.WriteLine($"服务器端发来消息: {result} ");
            }
            socketClient.Shutdown(SocketShutdown.Both);
            //清理连接的资源
            socketClient.Close();
        }
        static void Main(string[] args)
        {
            Client client = new Client();
        }
    }
}
