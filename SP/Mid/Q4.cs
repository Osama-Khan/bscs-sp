using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SP.Mid.Q4;

namespace SP.Mid
{
    class Q4 // Should be named "Main" as per question requirement
    {
        public delegate void ReceiveInformer(string type, int oldQ, int newQ, int code);
        public delegate void IssueInformer(string msg, string type, int qty, int code);

        public static void main(string[] args)
        {
            var rad = new AmmunitionDetail();
            rad.code = 301315;
            rad.qty = 3000;
            rad.type = "9mm";
            rad.Receive(100, new LocalHQ().GetInformer());

            var iad = new AmmunitionDetail();
            iad.code = 301489;
            iad.qty = 950;
            iad.type = "5.56mm";
            iad.Issue("Issuing Ammo for 5.56", new GeneralHQ().GetInformer());
        }
    }

    class AmmunitionDetail
    {
        public string type { get; set; }
        public int qty { get; set; }
        public int code { get; set; }

        public void Receive(int amt, ReceiveInformer del)
        {
            del(type, qty, qty + amt, code);
        }

        public void Issue(string msg, IssueInformer del)
        {
            del(msg, type, qty, code);
        }
    }

    class LocalHQ
    {
        public ReceiveInformer GetInformer()
        {
            return AmmunitionInformer;
        }

        void AmmunitionInformer(string type, int oldqty, int newqty, int code)
        {
            Console.WriteLine("\n------Received Ammunition------");
            Console.WriteLine("Type: {0}, Old Quantity: {1}, New Quantity: {2}, Code: {3}", type, oldqty, newqty, code);
        }
    }

    class GeneralHQ
    {
        public IssueInformer GetInformer()
        {
            return AmmunitionInformer;
        }

        void AmmunitionInformer(string msg, string type, int qty, int code)
        {
            Console.WriteLine("\n------Issued Ammunition------");
            Console.WriteLine("Message: {0}, Type: {1}, Quantity: {2}, Code: {3}", msg, type, qty, code);
        }
    }
}
