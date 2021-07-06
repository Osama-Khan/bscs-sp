using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SP.AsstLabs
{
    class Lab4
    {
        static Lab4()
        {
            Hashtable ht = new Hashtable();
            ht.Add("Name", "Ali");
            ht.Clear();
            ht.ContainsKey("Name");
            ht.ContainsValue("Ali");
            SortedList st = new SortedList();
            st.Add("Name", "Ali");
            st.Clear();
            st.ContainsKey("Name");
            st.ContainsValue("Ali");
            if (st.Count > 0)
            {
                st.GetByIndex(0);
                st.GetKey(0);
            }
            Console.ReadKey();
        }
    }
}
