using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SP.Labs.Lab14
{
    class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
    }

    class ChatServerMultiple
    {
        public static void main(string[] args)
        {
            var countryInfo = new List<Country> {
                new Country {Name = "Pakistan", Capital ="Islamabad" },
                new Country {Name = "China", Capital ="Beijing" },
                new Country {Name = "Afghanistan", Capital ="Kabul" },
                new Country {Name = "Iran", Capital ="Tehran" },
            };

            int myPortNo = 25931; // 1 - 65535
            string myIp = "127.0.0.1";
            IPEndPoint localep = new IPEndPoint(IPAddress.Parse(myIp), myPortNo);

            //READY FOR CONNECTION
            TcpListener listener = new TcpListener(localep);
            listener.Start(); // once

            Console.WriteLine("====Ready for connection request");
            int clientsCount = 0;
            while (true)
            {
                Socket socket = listener.AcceptSocket();//blocking function
                if (clientsCount == 3)
                {
                    IPEndPoint remoteep = socket.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine("[ERR] \tClient [ {0} ] Tried to connect, but server limit has been reached!", remoteep);
                    continue;
                }
                clientsCount++;
                Console.WriteLine("[INFO]\tClients Connected {0}/3", clientsCount);
                var t = new Thread(() =>
                {
                    IPEndPoint remoteep = socket.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine("[INFO]\tClient [ {0} ] has connected", remoteep);

                    Stream stream = new NetworkStream(socket);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.AutoFlush = true;//?????
                    StreamReader reader = new StreamReader(stream);

                    string countryName = "";
                    do
                    {
                        countryName = reader.ReadLine();//receiving from client
                        if (countryName == "")
                        {
                            Console.WriteLine("[INFO]\t{0} ended the session", remoteep);
                            clientsCount--;
                            Console.WriteLine("[INFO]\tClients Connected {0}/3", clientsCount);
                            break;
                        }
                        var cInfo = countryInfo.FirstOrDefault(c => c.Name == countryName);
                        if (cInfo == null)
                            writer.WriteLine("No information found");
                        else
                            writer.WriteLine(cInfo.Capital);

                    } while (true);
                });
                t.Start();
            }
            listener.Stop();
        }
    }
}
