using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP.Final
{
    class RWManager
    {
        bool shouldWrite = true;
        int readersCount = 0;
        int value;

        public void Read()
        {
            while (shouldWrite) Thread.Sleep(200);
            lock (this)
            {
                if (shouldWrite) return;
                readersCount++;
                var name = Thread.CurrentThread.Name;
                Console.WriteLine("[READ]\t{0} is reading {1}", name, value);
                Thread.Sleep(100);

                if (readersCount % 3 == 0)
                {
                    shouldWrite = true;
                }

            }
        }

        public void Write()
        {
            while (!shouldWrite) Thread.Sleep(200); // Reads are in progress
            lock (this)
            {
                var name = Thread.CurrentThread.Name;
                Thread.Sleep(new Random().Next(100, 1000));
                value = new Random().Next(20, 100);
                Console.WriteLine("[WRIT]\t{0} Has Written value {1}", name, value);
                shouldWrite = false;
            }
        }
    }
    class Q6
    {
        public static void main(string[] args)
        {
            RWManager rw = new RWManager();

            int writeCount = 0;
            ThreadStart reader = () =>
            {
                while (writeCount < 1500)
                {
                    rw.Read();
                }
            };

            ThreadStart writer = () =>
            {
                while (writeCount < 1500)
                {
                    Console.WriteLine("Writing value # {0}", writeCount++ + 1);
                    rw.Write();
                }
                Console.WriteLine("All Values have been written");
            };
            var A = new Thread(writer);
            var B = new Thread(reader);
            var C = new Thread(reader);
            var D = new Thread(reader);

            A.Name = "A";
            B.Name = "B";
            C.Name = "C";
            D.Name = "D";

            A.Start();
            B.Start();
            C.Start();
            D.Start();
        }
    }
}