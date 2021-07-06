using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Mid
{
    class Q5
    {
        Dictionary<string, BankAccount> data = new Dictionary<string, BankAccount>();

        class BankAccount
        {
            public string name { get; set; }
            public int amount { get; set; }
        }

        void OpenAccount(string Key, BankAccount val)
        {
            data.Add(Key, val);
        }

        BankAccount GetDetail(string num)
        {
            try
            {
                return data[num];
            } 
            catch (Exception)
            {
                return null;
            }
        }

        void Transfer(string from, string to, int amount)
        {
            try
            {
                if (data[from].amount >= amount)
                {
                    data[from].amount -= amount;
                    data[to].amount += amount;
                    Console.WriteLine("Transaction successful!");
                }
                else
                {
                    Console.WriteLine("Not enough balance!");
                }
            } catch (Exception)
            {
                Console.WriteLine("Invalid Account!");
            }
        }

        // Driver function
        public static void main(string[] args)
        {    
            var q5 = new Q5();
            q5.OpenAccount("101", new BankAccount() { amount = 3000, name = "Ali" });
            q5.OpenAccount("102", new BankAccount() { amount = 5500, name = "Bilal" });
            Console.WriteLine(q5.GetDetail("102").name);
            q5.Transfer("101", "102", 6000);
            q5.Transfer("101", "102", 3000);
            Console.WriteLine(q5.GetDetail("101").amount);
            Console.WriteLine(q5.GetDetail("102").amount);
        }
    }
}
