using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SP.Labs.Lab14
{

    class ChatServer
    {
        public static void main(string[] args)
        {
            Console.Write("Enter Server Name: ");
            string name = Console.ReadLine();

            string myIP = "127.0.0.1";
            short myPortNo = 17000;

            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse(myIP), myPortNo);
            TcpListener listener = new TcpListener(localEP);
            listener.Start();
            Console.WriteLine("Listener/Server is now ready for communication");
            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Client is connected now");


            IPEndPoint remoteEP = socket.RemoteEndPoint as IPEndPoint;
            Console.WriteLine("Client'IP:{0}, Port:{1}", remoteEP.Address, remoteEP.Port);

            Stream stream = new NetworkStream(socket);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            StreamReader reader = new StreamReader(stream);

            writer.WriteLine(name);
            var clientName = reader.ReadLine();

            do
            {
                Console.Write("{0}: ", name);
                string myMessage = Console.ReadLine();
                writer.WriteLine(myMessage);
                if (myMessage.ToLower() == "stop")
                {
                    Console.WriteLine("You have ended session");
                    break;
                }

                string clientMessage = reader.ReadLine();
                if (clientMessage.ToLower() == "stop")
                {
                    Console.WriteLine("{0} has ended session", clientName);
                    break;
                }
                Console.WriteLine("{0}: {1}", clientName, clientMessage);
            } while (true);

            reader.Close();
            writer.Close();
            socket.Close();
            stream.Close();

            listener.Stop();
        }
    }
}
