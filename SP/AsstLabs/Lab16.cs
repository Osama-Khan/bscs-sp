using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.AsstLabs
{
    delegate void CalculateDelegate(float x, float y);
    class Calculator
    {
        public event CalculateDelegate OnAdd;
        public event CalculateDelegate OnSubtract;
        public event CalculateDelegate OnMultiply;
        public event CalculateDelegate OnDivide;

        public void Add(float x, float y)
        {
            OnAdd?.Invoke(x, y);
        }

        public void Subtract(float x, float y)
        {
            OnSubtract?.Invoke(x, y);
        }

        public void Multiply(float x, float y)
        {
            OnMultiply?.Invoke(x, y);
        }

        public void Divide(float x, float y)
        {
            OnDivide?.Invoke(x, y);
        }
    }

    class Lab16
    {
        public static void main(string[] args)
        {
            var calculator = new Calculator();
            calculator.OnAdd += (x, y) => Console.WriteLine("Add result: {0}", (x + y));
            calculator.OnSubtract += (x, y) => Console.WriteLine("Subract result: {0}", (x - y));
            calculator.OnMultiply += (x, y) => Console.WriteLine("Multiply result: {0}", (x * y));
            calculator.OnDivide += (x, y) => Console.WriteLine("Divide result: {0}", (x / y));

            string op;
            do
            {
                Console.Write("Enter operator +, -, / or *: ");
                op = Console.ReadLine();
                Console.Write("Enter number 1: ");
                var n1 = float.Parse(Console.ReadLine());
                Console.Write("Enter number 2: ");
                var n2 = float.Parse(Console.ReadLine());
                switch (op)
                {
                    case "+":
                        calculator.Add(n1, n2);
                        break;
                    case "-":
                        calculator.Subtract(n1, n2);
                        break;
                    case "*":
                        calculator.Multiply(n1, n2);
                        break;
                    case "/":
                        calculator.Divide(n1, n2);
                        break;
                    default:
                        Console.WriteLine("Invalid operator, breaking.");
                        break;
                }
            } while ("+-/*".Contains(op));
        }
    }
}
