using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    public class Server
    {
        private Socket socketServer;
        private IPEndPoint ipep;

        public Server()
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2000);
            socketServer.Bind(ipep);

            while(true)
            {
                EndPoint ep = (EndPoint)ipep;
                byte[] buffer = new byte[1024 * 1024];
                int dataLength = socketServer.ReceiveFrom(buffer, ref ep);
                string result = Encoding.UTF8.GetString(buffer, 0, dataLength);
                Console.WriteLine($"客服端发来数据: {result}");
            }
        }
        static void Main(string[] args)
        {
            Server server = new Server();
        }
    }
}
