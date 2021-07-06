using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP.Final
{
    class Account
    {
        // ... other functionality
        public string Name;
        public float balance;
        public Mutex mutex = new Mutex();

        public Account(string name, float balance)
        {
            Name = name;
            this.balance = balance;
        }
    }

    class Bank
    {
        // ... other functionality
        public void Transfer(Account from, Account to)
        {
            Console.WriteLine("Acquiring From Lock for {0}", from.Name);
            if (from.mutex.WaitOne(10000))
            {
                Thread.Sleep(100);
                Console.WriteLine("Acquiring To Lock for {0}", to.Name);
                if (to.mutex.WaitOne(10000))
                {
                    Thread.Sleep(5000); // Doing Transfer
                    Console.WriteLine("Releasing From Lock for {0}", from.Name);
                    from.mutex.ReleaseMutex();
                    Console.WriteLine("Releasing To Lock for {0}", to.Name);
                    to.mutex.ReleaseMutex();
                }
                else
                {
                    Console.WriteLine("Deadlock occured for account {0} as destination", from.Name);
                    Thread.CurrentThread.Abort();
                }
            }
            else
            {
                Console.WriteLine("Deadlock occured for account {0} as source", from.Name);
                Thread.CurrentThread.Abort();
            }
        }
    }
    class Q5
    {
        public static void main(string[] args)
        {
            Bank BankA = new Bank();
            Bank BankB = new Bank();
            Account Account1 = new Account("Account 1", 10000);
            Account Account2 = new Account("Account 2", 20000);
            Console.WriteLine("Running 1 to 2 Transfer");
            new Thread(() => BankA.Transfer(Account1, Account2)).Start();
            Console.WriteLine("Running 2 to 1 Transfer");
            new Thread(() => BankB.Transfer(Account2, Account1)).Start();
        }
    }
}
