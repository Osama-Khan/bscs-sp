using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.AsstLabs
{
    class Lab12
    {

        public static void main(string[] args)
        {
            var dtEmployee = new DataTable();
            var cols = new DataColumn[] {
                new DataColumn("Name", Type.GetType("System.String")),
                new DataColumn("Gender", Type.GetType("System.Char")),
                new DataColumn("DOB", Type.GetType("System.String")),
                new DataColumn("Salary", Type.GetType("System.Int32")),
                new DataColumn("Department", Type.GetType("System.String")),
                };
            dtEmployee.Columns.AddRange(cols);
            dtEmployee.Rows.Add(new object[] { "Ali", 'M', "29-11-1990", 20000, "CS" });
            dtEmployee.Rows.Add(new object[] {"Junaid", 'M', "29-11-1993", 21000, "Finance"});
            dtEmployee.Rows.Add(new object[] {"Ayesha", 'F', "11-01-1996", 19000, "CS"});
            dtEmployee.Rows.Add(new object[] {"Sohaib", 'M', "11-01-1996", 27000, "IT"});
            dtEmployee.Rows.Add(new object[] {"Sajid", 'M', "11-01-1996", 24000, "Finance"});
            dtEmployee.Rows.Add(new object[] {"Sehrish", 'F', "11-01-1996", 34000, "CS"});
            dtEmployee.Rows.Add(new object[] {"Saima", 'F', "11-01-1996", 40000, "CS"});
            dtEmployee.Rows.Add(new object[] {"Kaleem", 'M', "11-01-1996", 14000, "Finance"});
            dtEmployee.Rows.Add(new object[] {"Omar", 'M', "11-01-1996", 15000, "CS"});
            dtEmployee.Rows.Add(new object[] {"Suleman", 'M', "11-01-1996", 30000, "IT"});

            Console.WriteLine("\n---Employees with Salaries Greater than 20k---");
            var q1 = dtEmployee.AsEnumerable().Where((e) => e.Field<int>("Salary") > 20000);
            foreach(var emp in q1)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", emp["Name"], emp["Gender"], emp["DOB"], emp["Salary"], emp["Department"]);
            }

            Console.WriteLine("\n---Names of Male Employees---");
            var q2 = dtEmployee.AsEnumerable().Where((e) => e.Field<int>("Salary") > 20000).Select((e) => e.Field<string>("Name"));
            foreach (var emp in q2)
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("\n---Employees Ordered By Salaries---");
            var q3 = dtEmployee.AsEnumerable().OrderBy((e) => e.Field<int>("Salary"));
            foreach (var emp in q3)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", emp["Name"], emp["Gender"], emp["DOB"], emp["Salary"], emp["Department"]);
            }

            Console.WriteLine("\n---Employees Grouped By Department---");
            var q4 = dtEmployee.AsEnumerable().GroupBy((e) => e["Department"]);
            foreach (var data in q4)
            {
                Console.WriteLine("Department: {0}", data.Key);
                foreach (var emp in data)
                {
                    Console.WriteLine("{0},{1},{2},{3},{4}", emp["Name"], emp["Gender"], emp["DOB"], emp["Salary"], emp["Department"]);
                }
            }

            Console.WriteLine("\n---Sum of All Salaries---");
            var q5 = dtEmployee.AsEnumerable().Sum((e) => e.Field<int>("Salary"));
            Console.WriteLine("Sum = {0}", q5);

            Console.WriteLine("\n---Top 2 Employees---");
            var q6 = dtEmployee.AsEnumerable().Take(2);
            Console.WriteLine("Sum = {0}", q5);
        }
    }
}