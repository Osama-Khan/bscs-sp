using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SP.Final.Q8
{
    class SongPriority
    {
        public string name;
        public int priority = 0;
    }
    class TCPServer
    {
        static List<SongPriority> list = new List<SongPriority>();

        public static void AddSong(string name)
        {
            var prev = list.FirstOrDefault((p) => p.name == name);
            if (prev == null)
            {
                prev = new SongPriority
                {
                    name = name
                };
                list.Add(prev);
            }
            else prev.priority += 1;
            list = list.OrderByDescending((sp) => sp.priority).ToList();
        }

        public static void main(string[] args)
        {
            string myIP = "127.0.0.1";
            short myPortNo = 17000;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(myIP), myPortNo);
            TcpListener lis = new TcpListener(ep);
            lis.Start();
            while (true)
            {
                Socket socket = lis.AcceptSocket();
                new Thread(() => ClientInstance(socket)).Start();
            }
            lis.Stop();
        }

        public static void ClientInstance(Socket socket)
        {
            IPEndPoint ep = socket.RemoteEndPoint as IPEndPoint;
            Console.WriteLine("Client Info:{0}", ep);
            var count = 1;
            while (true)
            {
                Stream stream = new NetworkStream(socket);
                var top = list.Count > 0? list[0].name: "None";

                byte[] send = Encoding.ASCII.GetBytes("Top song is " + top);
                stream.Write(send, 0, send.Length);

                byte[] rec = new byte[1024];

                int recCount = stream.Read(rec, 0, rec.Length);

                string msg = Encoding.ASCII.GetString(rec, 0, recCount);
                if (msg == "exit")
                {
                    Console.WriteLine("Client {0} has exited!", ep);
                    break;
                }
                if (count == 5)
                {
                    Console.WriteLine("Client {0} has reached message limit!", ep);
                    break;
                }
                count++;
                Console.WriteLine("Client {0} wants to add song {1}", ep,  msg);
                AddSong(msg);
                Console.WriteLine("Done, top song is now {0}", list[0].name);
            }
            socket.Close();
        }
    }
}
