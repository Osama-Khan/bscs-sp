using System;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace SP.Assignments
{
    class Week7
    {
        const string depsXmlPath = "../../Assignments/Data/Departments.xml";
        const string empsXmlPath = "../../Assignments/Data/Employees.xml";

        public static void main(string[] args)
        {
            // Data table for departments
            var dtDepartments = new DataTable();
            var cId = new DataColumn("Id", Type.GetType("System.Int32"));
            var cDepName = new DataColumn("DName", Type.GetType("System.String"));

            dtDepartments.Columns.Add(cId);
            dtDepartments.Columns.Add(cDepName);

            dtDepartments.Rows.Add(new object[] { 100, "Marketing" });
            dtDepartments.Rows.Add(new object[] { 101, "HR" });
            dtDepartments.Rows.Add(new object[] { 102, "Accounts" });
            dtDepartments.Rows.Add(new object[] { 103, "QA" });

            // Data table for employees
            var dtEmployees = new DataTable();
            var cName = new DataColumn("Name", Type.GetType("System.String"));
            var cGender = new DataColumn("Gender", Type.GetType("System.Char"));
            var cDob = new DataColumn("Dob", Type.GetType("System.DateTime"));
            var cSalary = new DataColumn("Salary", Type.GetType("System.Int32"));
            var cCity = new DataColumn("City", Type.GetType("System.String"));
            var cDeptId = new DataColumn("DeptId", Type.GetType("System.Int32"));
            dtEmployees.Columns.Add(cName);
            dtEmployees.Columns.Add(cGender);
            dtEmployees.Columns.Add(cDob);
            dtEmployees.Columns.Add(cSalary);
            dtEmployees.Columns.Add(cCity);
            dtEmployees.Columns.Add(cDeptId);

            dtEmployees.Rows.Add(new object[] { "Qasim", 'M', Convert.ToDateTime("25-Nov-1998"), 45000, "Rawalpindi", 100 });
            dtEmployees.Rows.Add(new object[] { "Fatima", 'F', Convert.ToDateTime("12-10-1995"), 35000, "Lahore", 101 });
            dtEmployees.Rows.Add(new object[] { "Nasir", 'M', Convert.ToDateTime("09-Jan-1993"), 85000, "Rawalpindi", 101 });
            dtEmployees.Rows.Add(new object[] { "Manzoor", 'M', Convert.ToDateTime("15-Sep-1990"), 35000, "Islamabad", 102 });
            dtEmployees.Rows.Add(new object[] { "Khalid", 'M', Convert.ToDateTime("01-02-2001"), 25000, "Lahore", 101 });
            dtEmployees.Rows.Add(new object[] { "Ayesha", 'F', Convert.ToDateTime("10-09-1992"), 60000, "Rawalpindi", 101 });
            dtEmployees.Rows.Add(new object[] { "Ahmed", 'M', Convert.ToDateTime("10-09-1997"), 30000, "Islamabad", 102 });
            dtEmployees.Rows.Add(new object[] { "Sana", 'F', Convert.ToDateTime("09-02-2002"), 47000, "Rawalpindi", 100 });
            dtEmployees.Rows.Add(new object[] { "Zulfiqar", 'M', Convert.ToDateTime("17-06-1995"), 34000, "Islamabad", 102 });
            dtEmployees.Rows.Add(new object[] { "Zaheer", 'M', Convert.ToDateTime("10-02-1999"), 18000, "Lahore", 0 });

            /// Q1. Apply both methods of Cross join on two DataTables
            var q1a = dtEmployees.AsEnumerable().SelectMany(
                e => dtDepartments.AsEnumerable(),
                (e, d) => new { e, d });
            foreach (var v in q1a)
            {
                Console.WriteLine("{0}, {1}", v.e.Field<string>("Name"), v.d.Field<string>("DName"));
            }

            var q1b = dtEmployees.AsEnumerable().Join(
                dtDepartments.AsEnumerable(),
                e => true,
                d => true,
                (e, d) => new { e, d });
            foreach (var v in q1b)
            {
                Console.WriteLine("{0}, {1}", v.e.Field<string>("Name"), v.d.Field<string>("DName"));
            }

            /// Q2. For LINQ to XML you need to apply GroupJoin, Left Outer Join and Cross Join
            var depsXml = XElement.Load(depsXmlPath);
            var deps = depsXml.Elements("Department");
            var empsXml = XElement.Load(empsXmlPath);
            var emps = empsXml.Elements("Employee");

            // Group Join
            deps.GroupJoin(emps, d => d.Attribute("Id").Value, e => e.Element("DeptId").Value,
                (d, e) => new {d, e});
            // Left Outer Join
            deps.GroupJoin(emps, d => d.Attribute("Id").Value, e => e.Element("DeptId").Value, (d, e) => new { d, e })
                .SelectMany(v => v.e.DefaultIfEmpty(), (de, em) => new {de, em});
            // Cross Join
            deps.Join(emps, d => true, e => true, (e, d) => new { e, d });

            /// Q3. 
            /// a) GroupBy on Department Name and print department name along with Highest Salary Employee Details
            var depXemp = deps.Join(emps, d => d.Attribute("Id").Value, e => e.Element("DeptId").Value, (d, e) => new { d, e });
            var q3a = depXemp.GroupBy(dxe => dxe.d.Element("Name").Value);
            foreach(var v in q3a)
            {
                var highest = v.Max(dxe => dxe.e.Element("Salary").Value);
                var emp = v.Where(dxe => dxe.e.Element("Salary").Value == highest).First().e;
                Console.WriteLine("Department: {0}", v.Key);
                Console.WriteLine("Highest Paid Employee Detail: ");
                Console.WriteLine("Name: {0}, Salary: {1}", emp.Element("Name").Value, emp.Element("Salary").Value);
            }

            /// b) Join Department,Employee and Print result
            var q3b = deps.Join(emps, d => d.Attribute("Id").Value, e => e.Element("DeptId").Value, (d, e) => new { d, e });
            foreach (var v in q3b)
            {
                Console.WriteLine("{0} works in {1}", v.e.Element("Name").Value, v.d.Element("Name").Value);
            }

        }
    }
}
