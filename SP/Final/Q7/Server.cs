using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP.Final.Q7
{
    public partial class Server : Form
    {
        Dictionary<string, StreamWriter> ClientWriters = new Dictionary<string, StreamWriter>();
        int ClientCount = 0;

        public Server()
        {
            InitializeComponent();
            new Thread(Serve).Start();
        }

        void Serve()
        {
            int myPortNo = 25931;
            string myIp = "127.0.0.1";
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(myIp), myPortNo);

            TcpListener lis = new TcpListener(ep);
            lis.Start();
            while (true)
            {
                Socket socket = lis.AcceptSocket();
                var t = new Thread(() => ClientInstance(socket));
                t.Start();
            }
            lis.Stop();
        }

        void SendMessage(string sender, string msg)
        {
            var toWrite = sender + ": " + msg;
            foreach(var writer in ClientWriters) 
                writer.Value.WriteLine(toWrite);

            listBox.Invoke((MethodInvoker) delegate {
                listBox.Items.Add(toWrite);
            });
        }

        void ClientInstance(Socket socket)
        {
            Stream stream = new NetworkStream(socket);
            StreamWriter writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
            StreamReader reader = new StreamReader(stream);
            string name = "Client " + ClientCount++;
            ClientWriters.Add(name, writer);
            SendMessage("Server", name + " has Connected!");
            while (true) {
                try
                {
                    string message = reader.ReadLine();
                    SendMessage(name, message);
                } catch (Exception)
                {
                    ClientWriters.Remove(name);
                    SendMessage("Server", name + " has Disconnected!");
                    break;
                }
            }
        }
    }
}
