using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SP.Labs.Lab16
{
    class TCPClient
    {
        public static void main(string[] args)
        {
            string serverIP = "127.0.0.1";
            short serverPortNo = 17000;
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverIP), serverPortNo);
            TcpClient client = new TcpClient();
            client.Connect(serverEP);
            Console.WriteLine("you are now connected to server");

            while (true)
            {
                Stream stream = client.GetStream();

                byte[] dataToReceive = new byte[1024];
                int dataCount = stream.Read(dataToReceive, 0, dataToReceive.Length);

                string serverMessage = ASCIIEncoding.ASCII.GetString(dataToReceive, 0, dataCount);
                Console.WriteLine("Server:\t{0}", serverMessage);

                if (serverMessage.StartsWith("[WARNING]"))
                {
                    byte[] dataToSend = ASCIIEncoding.ASCII.GetBytes("[WARNING_ACK] Sorry!");
                    stream.Write(dataToSend, 0, dataToSend.Length);
                }
                else
                {
                    Console.Write("You:   \t");
                    string clientMessage = Console.ReadLine();

                    byte[] dataToSend = ASCIIEncoding.ASCII.GetBytes(clientMessage);
                    stream.Write(dataToSend, 0, dataToSend.Length);
                }
            }
            Console.ReadKey();
        }
    }
}
