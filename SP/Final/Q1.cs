using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Final
{
    class Country
    {
        public string Continent { get; set; }
        public int Cases { get; set; }

        public Country(string Continent, int Cases)
        {
            this.Continent = Continent;
            this.Cases = Cases;
        }
    }

    class Q1
    {
        Dictionary<string, Country> Covid = new Dictionary<string, Country>();

        void AddCountry(string name, Country country)
        {
            Covid.Add(name, country);
        }

        void AddCases()
        {
            Console.Write("Enter Country Name: ");
            string name = Console.ReadLine();
            if (Covid.ContainsKey(name))
            {
                Console.Write("Enter cases to add to {0}: ", name);
                int cases = int.Parse(Console.ReadLine());
                Covid[name].Cases += cases;
            } else
            {
                Console.WriteLine("Country does not exist!");
            }
        }

        List<string> CovidFree()
        {
            var list = new List<string>();
            foreach(var c in Covid)
            {
                if (c.Value.Cases == 0)
                {
                    list.Add(c.Key);
                }
            }
            return list;
        }

        public static void main(string[] args)
        {
            var q = new Q1();
            q.AddCountry("Pakistan", new Country("Asia", 3000));
            q.AddCountry("India", new Country("Asia", 64440));
            q.AddCountry("Texas", new Country("America", 0));
            q.AddCountry("France", new Country("Europe", 100));
            foreach (var a in q.CovidFree())
            {
                Console.WriteLine(a);
            }
            q.AddCases();
            q.AddCases();
            foreach (var a in q.CovidFree())
            {
                Console.WriteLine(a);
            }
        }
    }
}
