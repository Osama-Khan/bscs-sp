using System;

using System.IO;
using System.Net.Sockets;


namespace SP.Labs.Lab14
{
    class ChatClientMultiple
    {
        public static void main(string[] args)
        {
            //CONNECTION REQUEST TO SERVER
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 25931);

            Console.WriteLine("You are now connected");

            //NOW GET THE CONNECTION SESSION DETAILS, IF CONNECTED
            Stream stream = client.GetStream();

            //NOW TO RECEIVE DATA
            StreamReader reader = new StreamReader(stream);
            //NOW TO SEND DATA  
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            string cName = "";
            do
            {
                Console.Write("Enter the Country Name:");
                cName = Console.ReadLine();
                writer.WriteLine(cName);
                if (cName == "")
                {
                    Console.WriteLine("You ended the session");
                    break;
                }

                string remoteMessage = reader.ReadLine();//reply from server
                Console.WriteLine(remoteMessage);

            } while (true);
        }
    }
}
