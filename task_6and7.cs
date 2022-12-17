using System;

namespace ConsoleApp1
{
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void print()
        {
            Console.WriteLine("my name is " + Name + ", my age is " + Age);
        }

    }
    public class Student : Person
    {
        // Use Getter/Setter methods
        private int Year;
        public int get_Year()
        {
            return Year;
        }
        public void set_Year(int new_year)
        {
            if (new_year > 5 || new_year < 0)
            {
                throw new ArgumentOutOfRangeException(" invalid year");

            }
            Year = new_year;
        }
        /////   Using Properties
        private float _Gpa;
        public float Gpa
        {
            get { return _Gpa; }
            set {

                if (value > 4 || value < 0)
                {
                    throw new ArgumentOutOfRangeException(" invalid GPA");

                }
                _Gpa = value;


            }
        }
        public Student(string name, int age, int year, float gpa) : base(name, age)
        {

            if ( year > 5 || year<0)
            {
                throw new ArgumentOutOfRangeException(" invalid year");

            }
            if (gpa > 4 || gpa < 0)
            {
                throw new ArgumentOutOfRangeException(" invalid GPA");

            }

            Year = year;
            _Gpa = gpa;
          

        }
       
        public override void print()
        {
            Console.WriteLine("my name is " + Name + ", my age is " + Age +" ,year is "+Year+ " and my gpa is " + Gpa);
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
        public void Addperson(Person person)
        {
            people[_currentInndex++] = person;
        }
        public void PrintAll()
        {
            foreach (var item in people)
            {
                item?.print();
            }
        }
    }
    public class Staff : Person
    {
        //// Use Getter/Setter methods
        private double Salary;
        public double get_salary()
        {
            return Salary;
        }
        public void set_salary(double new_salary)
        {
            if (new_salary > 120000 || new_salary < 0)
            {
                throw new ArgumentOutOfRangeException(" invalid Salary");

            }
            Salary = new_salary;
        }
        /////   Using Properties
        private int _joinYear;
        public int JoinYear
        {
            get
            {
                return _joinYear;
            }
            set
            {
                if (Age < 21)
                {
                    throw new ArgumentOutOfRangeException(" invalid join year");

                }
                _joinYear = value;
            }
        }
        public Staff(string name, int age, double salary, int joinyear) : base(name, age)
        {
            if (salary > 120000 || salary < 0)
            {
                throw new ArgumentOutOfRangeException(" invalid Salary");

            }
            if (age <21)
            {
                throw new ArgumentOutOfRangeException(" invalid join age");

            }
            Salary = salary;
            _joinYear = joinyear;
        }
        public override void print()
        {
            Console.WriteLine("my name is " + Name + ", my age is " + Age + "and my salary is " + Salary+"join year is  "+_joinYear);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Datebase();

            while (true)
            {
                Console.WriteLine("select an option to add : 1-student   2-staff   3-person   4-printAll");
                var x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
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
                        Console.Write("Name: ");
                        var Nam = Console.ReadLine();
                        Console.Write("Age: ");
                        var Agee = Convert.ToInt32(Console.ReadLine());
                        var person = new Person(Nam, Agee);
                        database.Addperson(person);
                        break;
                    case 4:
                        database.PrintAll();
                        break;
                    default:
                        return;

                }





            }
        }
    }
}