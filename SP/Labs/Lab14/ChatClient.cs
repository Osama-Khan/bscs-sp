using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SP.Labs.Lab14
{
    class ChatClient
    {
        public static void main(string[] args)
        {
            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            string serverIP = "127.0.0.1";
            int serverPortNo = 17000;

            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverIP), serverPortNo);
            TcpClient client = new TcpClient();

            client.Connect(serverEP);
            Console.WriteLine("You are now connected to Server");

            Stream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            var serverName = reader.ReadLine();
            writer.WriteLine(name);
            do
            {
                string serverMessage = reader.ReadLine();
                Console.WriteLine("{0}: {1}", serverName, serverMessage);
                if (serverMessage.ToLower() == "stop")
                {
                    Console.WriteLine("{0} has ended session", serverName);
                    break;
                }

                Console.Write("{0}: ", name);
                string myMessage = Console.ReadLine();
                writer.WriteLine(myMessage);
                if (myMessage.ToLower() == "stop")
                {
                    Console.WriteLine("You have ended session");
                    break;
                }
            } while (true);
            reader.Close();
            writer.Close();
        }
    }
}
