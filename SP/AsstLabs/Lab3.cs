using System;
using System.Collections;

namespace SP.AsstLabs
{
    class Lab3
    {
        static Lab3()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(21);
            list.Add(31);
            list.Add(4);
            list.Add(52);
            list.Add(164);
            list.Add("Ali");
            list.Add(22);
            list.Add(67);
            list.Add(99);

            Stack stack = new Stack();
            stack.Push(2);
            stack.Push('A');
            stack.Push(4);
            stack.Push(83);
            stack.Push(21);

            list.InsertRange(2, stack);
            Console.WriteLine("Top value of stack: {0}", stack.Peek());

            Console.ReadKey();
        }
    }
}
