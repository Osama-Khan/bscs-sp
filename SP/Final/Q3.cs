using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Final
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    delegate void InformFailureDelegate(int id, string subject, int marks);

    class ExaminationData
    {
        int StudentID;
        string SubjectName;
        int Marks;

        public void EnterMarks(InformFailureDelegate inform)
        {
            Console.Write("Enter Student ID: ");
            StudentID = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Name: ");
            SubjectName = Console.ReadLine();
            Console.Write("Enter Marks: ");
            Marks = int.Parse(Console.ReadLine());
            if (Marks < 40)
            {
                inform(StudentID, SubjectName, Marks);
            }
        }
    }

    class StudentData
    {
        List<Student> Students;

        public void InformFailure(int id, string subjname, int marks)
        {
            Console.WriteLine("Student#{0} has failed in {1} with {2} marks!", id, subjname, marks);
        }
    }

    class Exam
    {
        public void Main(string[] args)
        {
            ExaminationData data = new ExaminationData();
            StudentData std = new StudentData();
            data.EnterMarks(std.InformFailure);
        }
    }

    class Q3
    {
        public static void main(string[] args)
        {
            new Exam().Main(args);
        }
    }
}
