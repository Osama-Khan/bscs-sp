using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP.Final.Q7
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            btnConnect.Click += (s, e) => Connect();
        }

        public void Connect()
        {
            btnConnect.Enabled = false;
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 25931);

            Stream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            btnSend.Click += (s, e) =>
            {
                string msg = txtMessage.Text;
                writer.WriteLine(msg);
            };

            new Thread(() =>
            {
                while (true)
                {
                    string remoteMessage = reader.ReadLine();
                    listBox.Items.Add(remoteMessage);
                }
            }).Start();
        }
    }
}
