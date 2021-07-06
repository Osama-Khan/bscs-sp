using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  class Employee {
    public string Name {
      get;
      set;
    }
    public string Gender {
      get;
      set;
    }
    public int Salary {
      get;
      set;
    }
    public string Department {
      get;
      set;
    }
    public string City {
      get;
      set;
    }
    public override string ToString() {
      return string.Format("{0},{1},{2},{3},{4}",
        Name,
        Gender,
        Salary,
        Department,
        City);
    }
  }

  static void Main() {
    var employees = new List < Employee > {
      new Employee {
        Name = "Ahmed", Department = "IT", Salary = 70000, Gender = "Male", City = "Rwp"
      },
      new Employee {
        Name = "Aysha", Department = "Marketing", Salary = 55000,
          Gender = "Female", City = "Isb"
      },
      new Employee {
        Name = "Ali", Department = "IT", Salary = 40000, Gender = "Male", City = "Karachi"
      },
      new Employee {
        Name = "Sana", Department = "Admin", Salary = 70000,
          Gender = "Female", City = "Lahore"
      },
      new Employee {
        Name = "Khalid", Department = "IT", Salary = 77000,
          Gender = "Male", City = "Karachi"
      },
      new Employee {
        Name = "Zainab", Department = "Marketing", Salary = 50000,
          Gender = "Female", City = "Faisalabad"
      },
      new Employee {
        Name = "Saman", Department = "Admin", Salary = 35000,
          Gender = "Female", City = "Lahore"
      },
      new Employee {
        Name = "Sohail", Department = "IT", Salary = 90000,
          Gender = "Male", City = "Isb"
      },
      new Employee {
        Name = "Nasir", Department = "Admin", Salary = 25000,
          Gender = "Male", City = "Rwp"
      },
    };


    //Query-1
    Console.WriteLine("select City from employees group by City");
    var query1 = employees.GroupBy(e => e.City);
    foreach(var group in query1) {
      Console.WriteLine("City Name: {0}", group.Key);
    }
    //Query-3
    Console.WriteLine("select City,count(*) from employees group by City");
    var query3 = employees.GroupBy(e => e.City);
    foreach(var group in query3) {
      Console.WriteLine("City  Name: {0}, Total Employees:{1}", group.Key,
        group.Count());
    }

    Console.WriteLine("\n ---- Aggregates grouped by City ---- ");
    var sum = employees.GroupBy(e => e.City);
    foreach (var s in sum) {
        Console.WriteLine("Sum of Salaries of {0} Employees: {1}", s.Key, s.Sum(e => e.Salary));
        Console.WriteLine("Min of Salaries of {0} Employees: {1}", s.Key, s.Min(e => e.Salary));
        Console.WriteLine("Max of Salaries of {0} Employees: {1}", s.Key, s.Max(e => e.Salary));
        Console.WriteLine("Avg of Salaries of {0} Employees: {1}", s.Key, s.Average(e => e.Salary));
    }
    
    
    Console.WriteLine("\n ---- Highest pay grouped by City ---- ");
    var query9Highest = employees.GroupBy(e => e.City);
    foreach(var group in query9Highest) {
      Console.WriteLine("--------------------------");
      Console.WriteLine("City:{0}", group.Key);
      Console.WriteLine("--------------------------");
      var sal = group.Max(e => e.Salary);
      var emp = group.Where(e => e.Salary == sal).First();
      Console.WriteLine(emp);
    }
    
    Console.WriteLine("\n ---- Lowest pay grouped by City ---- ");
    var query9Lowest = employees.GroupBy(e => e.City);
    foreach(var group in query9Lowest) {
      Console.WriteLine("--------------------------");
      Console.WriteLine("City:{0}", group.Key);
      Console.WriteLine("--------------------------");
      var sal = group.Min(e => e.Salary);
      var emp = group.Where(e => e.Salary == sal).First();
      Console.WriteLine(emp);
    }

  }
}