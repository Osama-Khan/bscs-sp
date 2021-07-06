using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SP.Final.Q8
{
    class TCPClient
    {
        public static void main(string[] args)
        {
            var ip = IPAddress.Parse("127.0.0.1");
            var ep = new IPEndPoint(ip, 20000);
            var client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("you are now connected to server");
            var count = 1;
            while (true)
            {
                var stream = client.GetStream();

                byte[] rec = new byte[1024];
                int recCount = stream.Read(rec, 0, rec.Length);

                string msg = Encoding.ASCII.GetString(rec, 0, recCount);
                Console.WriteLine("Server: {0}", msg);

                Console.Write("Enter song name: ");
                msg = Console.ReadLine();

                byte[] send = Encoding.ASCII.GetBytes(msg);
                stream.Write(send, 0, send.Length);
                if (msg == "exit")
                {
                    Console.WriteLine("You exited!");
                    break;
                }
                if (count == 5)
                {
                    Console.WriteLine("You have reached message limit!");
                    break;
                }
                count++;
            }
        }
    }
}
