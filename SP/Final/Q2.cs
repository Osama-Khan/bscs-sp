using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Final
{

    class MyArrayList : ArrayList
    {
        public override void Remove(object obj)
        {
            base.RemoveAt(this.LastIndexOf(obj));
        }

        public List<int> GetInts()
        {
            var list = new List<int>();
            foreach (object o in this)
                if (o.GetType() == typeof(int))
                    list.Add(int.Parse(o.ToString()));
            return list;
        }

        public int GetCountOf(object value)
        {
            var count = 0;
            foreach(object o in this)
                if (o.Equals(value)) count++;
            return count;
        }
    }

    class Q2
    {
        public static void main(string[] args)
        {
            var t = new MyArrayList {
                2,
                3,
                1,
                3,
                1,
                24,
                "Hello",
                "OK",
                "Hello"
            };
            var v = t.GetInts();
            var c = t.GetCountOf(1);
            var c2 = t.GetCountOf(2);
            var c3 = t.GetCountOf("Hello");
            var c4 = t.GetCountOf("OK");
            var c5 = t.GetCountOf("111");
            var c6 = t.GetCountOf("1");
            t.Remove(1);
            t.Remove("Hello");
        }
    }
}
