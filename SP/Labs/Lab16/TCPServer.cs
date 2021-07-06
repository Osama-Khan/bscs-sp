using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SP.Labs.Lab16
{
    class TCPServer
    {
        public static void main(string[] args)
        {
            string myIP = "127.0.0.1";
            short myPortNo = 17000;
            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(myIP), myPortNo);
            TcpListener listener = new TcpListener(localEP);
            listener.Start();

            Socket socket = listener.AcceptSocket();
            IPEndPoint remoteEP = socket.RemoteEndPoint as IPEndPoint;
            Console.WriteLine("Client Info:{0}", remoteEP);
            int counter = 0;
            while (true) {
                Stream stream = new NetworkStream(socket);
                Console.Write("You:   \t");
                var yourMessage = Console.ReadLine();

                byte[] dataToSend = ASCIIEncoding.ASCII.GetBytes(yourMessage);
                stream.Write(dataToSend, 0, dataToSend.Length);

                byte[] dataToReceive = new byte[1024];

                int receiveCount = stream.Read(dataToReceive, 0, dataToReceive.Length);

                string clientMessage = ASCIIEncoding.ASCII.GetString(dataToReceive, 0, receiveCount);
                Console.WriteLine("Client:\t{0}", clientMessage);
                counter++;
                if (counter % 10 == 0)
                {
                    stream = new NetworkStream(socket);
                    dataToSend = ASCIIEncoding.ASCII.GetBytes("[WARNING] You have reached " + counter + " messages!");
                    stream.Write(dataToSend, 0, dataToSend.Length);
                }
            }
            Console.ReadKey();
            socket.Close();
            listener.Stop();
        }
    }
}
