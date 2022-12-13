using System;

namespace ConsoleApp1
{
    public class Person
        {
        public string Name;
        public int Age;

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void print()
        {

        }

        }
    public class Student: Person
    {
        public int Year;
        public float Gpa;
        public Student(string name, int age,int year,float gpa) :base(name,age)
        {
            Year = year;
            Gpa = gpa;

        }
        public override void print()
        {
            Console.WriteLine("my name is" + Name+", my age is" +Age+" and my gpa is "+Gpa);
        }
    }
    public class Datebase
    {
        private int _currentInndex;
        public Person[] people = new Person[50];
        public void AddStudent(Student student)
        {
            people[_currentInndex++] = student;
        }
        public void Addstaff(Staff staff)
        {
            people[_currentInndex++] = staff;
        }
        public void PrintAll()
        {
            foreach( var item in people)
            {
                item?.print();
            }
        }
    }
    public class Staff :Person
    {
        public double Salary;
        public int joinYear;
        public Staff(string name,int age,double salary,int joinyear): base(name,age)
        {
            Salary = salary;
            joinYear = joinyear;
        }
        public override void print()
        {
            Console.WriteLine("my name is"+Name+", my age is"+Age+"and my salary is"+Salary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Datebase();
           
            while (true) {
                Console.WriteLine("select an option : 1-student   2-staff   3-printAll");
                var x = Convert.ToInt32(Console.ReadLine());
                switch (x) {
                    case 1:
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Age: ");
                        var age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year: ");
                        var year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Gpa: ");
                        var gpa = Convert.ToInt32(Console.ReadLine());
                        var student = new Student(name, age, year, gpa);
                        database.AddStudent(student);
                        break;
                    case 2:
                        Console.Write("Name: ");
                        var Name = Console.ReadLine();
                        Console.Write("Age: ");
                        var Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Slary: ");
                        var salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("JoinYear: ");
                        var joinyear = Convert.ToInt32(Console.ReadLine());
                        var staff = new Staff(Name, Age, salary, joinyear);
                        database.Addstaff(staff);
                        break;

                    case 3:
                        database.PrintAll();
                        break;
                    default:
                        return;

                }





            }
        }
    }
}
