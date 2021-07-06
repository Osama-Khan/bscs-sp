using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.AsstLabs
{
    class Lab15
    {
        public delegate void NumberDelegate(int number);
        class RandomNumberGeneration
        {
            public event NumberDelegate OnEvenNumber;
            public event NumberDelegate OnOddNumber;
            public event NumberDelegate On1DigitNumber;
            public event NumberDelegate On2DigitNumber;
            public event NumberDelegate On3DigitNumber;
            public void GenerateNumbers()
            {
                Random rd = new Random();
                for (int counter = 1; counter <= 50; counter++)
                {
                    System.Threading.Thread.Sleep(1000);
                    var number = rd.Next(1, 1000);
                    if (number % 2 == 0)
                    {
                        //number is even
                        if (OnEvenNumber != null)
                        {
                            OnEvenNumber.Invoke(number);
                        }
                    }
                    if (number % 2 != 0)
                    {
                        //number is odd
                        if (OnOddNumber != null)
                        {
                            OnOddNumber.Invoke(number);
                        }
                    }
                    if (number >= 1 && number <= 9)
                    {
                        //number is of 1 Digit
                        if (On1DigitNumber != null)
                        {
                            On1DigitNumber.Invoke(number);
                        }
                    }
                    if (number >= 10 && number <= 99)
                    {
                        //number is of 2 Digit
                        if (On2DigitNumber != null)
                        {
                            On2DigitNumber.Invoke(number);
                        }
                    }
                    if (number >= 100 && number <= 999)
                    {
                        //number is of 3 Digit
                        if (On3DigitNumber != null)
                        {
                            On3DigitNumber.Invoke(number);
                        }
                    }
                }
            }
        }

        public static void main(string[] args)
        {
            var rng = new RandomNumberGeneration();
            rng.On1DigitNumber += (n) =>
            {
                Console.WriteLine("Generated 1 digit number: " + n);
            };
            rng.On2DigitNumber += (n) =>
            {
                Console.WriteLine("Generated 2 digit number: " + n);
            };
            rng.On3DigitNumber += (n) =>
            {
                Console.WriteLine("Generated 3 digit number: " + n);
            };
            rng.OnEvenNumber += (n) =>
            {
                Console.WriteLine("Generated even number: " + n);
            };
            rng.OnOddNumber += (n) =>
            {
                Console.WriteLine("Generated odd number: " + n);
            };
            rng.GenerateNumbers();

        }
    }
}
