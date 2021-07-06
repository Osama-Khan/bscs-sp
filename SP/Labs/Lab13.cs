using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP.Labs
{
    /// <summary>
    /// Printer has a Queue where requests are stored to process
    /// </summary>
    class Printer
    {
        readonly object synch = new object();
        //Thread safe
        public void Print(object sender)
        {
            //this and synch have same behavior

            //this means current object.
            //this means p1 or p2 or p3 here in out case
            //   lock (synch) // this will allow only one thread to be entered in this block
            //   {
            Monitor.Enter(this); // OR synch object i.e. Lock
            Console.WriteLine("{0}::Start Printing", sender);
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("{0} is Printing page {1}", sender, i);
                Thread.Sleep(new TimeSpan(0, 0, 1));//1 sec. sleep
            }
            Console.WriteLine("{0}::End Printing", sender);
            Monitor.Exit(this); //i.e. UnLock
                                //    }
        }
    }

    class DataManager
    {
        ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
        List<int> items;
        public DataManager()
        {
            items = new List<int> { 1, 2, 3, 4, 5 };
        }

        /// <summary>
        /// Attempt to read the array 
        /// </summary>
        public void Read()
        {
            rw.EnterReadLock();

            var name = Thread.CurrentThread.Name;
            Console.WriteLine("[READ]\t{0} has started Reading", name);
            foreach (var item in items)
            {
                Console.WriteLine("[READ]\t{0} is reading {1}", name, item);
                Thread.Sleep(200);
            }
            Console.WriteLine("[READ]\t{0} has stopped Reading", name);

            rw.ExitReadLock();
        }


        /// <summary>
        /// Attempt to append a random value to the same array being used in Read function
        /// </summary>
        public void Write()
        {
            if (rw.WaitingReadCount > 0)
            {
                Console.WriteLine(">>> Delaying writes since {0} reads in queue", rw.WaitingReadCount);
                Thread.Sleep(1000);
            }
            rw.EnterWriteLock();
            var name = Thread.CurrentThread.Name;
            Console.WriteLine("[WRIT]\t{0} has started Writing", name);
            //suppose writing takes 2 seconds
            Thread.Sleep(new TimeSpan(0, 0, 1));
            var rnd = new Random();
            int val = rnd.Next(10, 100);
            items.Add(val);
            Console.WriteLine("[WRIT]\t{0} Has Written value {1}", name, val);
            Console.WriteLine("[WRIT]\t{0} has ended Writing", name);
            rw.ExitWriteLock();
        }
    }
    class Lab13
    {
        public static void main(string[] args)
        {
            //second scenario
            DataManager dm1 = new DataManager();

            ThreadStart tr = () =>
            {
                while (true)
                {
                    dm1.Read();
                    Thread.Sleep(100);
                }
            };

            ThreadStart tw = () => {
                while (true)
                {
                    dm1.Write();
                    Thread.Sleep(900);
                }
            };
            var reader1 = new Thread(tr);
            var reader2 = new Thread(tr);

            var writer1 = new Thread(tw);
            var writer2 = new Thread(tw);

            reader1.Name = "R-1";
            reader2.Name = "R-2";
            writer1.Name = "W-1";
            writer2.Name = "W-2";

            writer1.Start();
            reader1.Start();
            writer2.Start();
            reader2.Start();



            //scenario1();

        }

        private static void scenario1()
        {
            //Thread synchronization using lock or Monitor.Enter()

            //now i have two printers
            Printer p1 = new Printer();
            Printer p2 = new Printer();
            Printer p3 = new Printer();

            //T1,T2 will send request to p1 printer
            //T3 will send request to p2 printer

            //suppose there are 3 threads which want to print from Printer p1
            var t1 = new Thread(p1.Print);
            var t2 = new Thread(p1.Print);
            var t3 = new Thread(p1.Print);

            t1.Start("T1");
            t2.Start("T2");
            t3.Start("T3");
        }
    }
}
