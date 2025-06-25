using System.Data;

namespace _08_01_Inheritance
{
    abstract class Person: Object
    {
        protected string name;
        protected readonly DateTime birthdate;
        public Person()
        {
            name = "No name";
            birthdate = new DateTime();
        }
        public Person(string name, DateTime b)
        {
            this.name = name;
            if (b < DateTime.Now)
            {
                birthdate = b;
            }
            else
                birthdate = new DateTime();
        }
        //public void DoWork() = 0;
        public abstract void DoWork();
        public virtual void Print()
        {
            Console.WriteLine($"Name : {name}.\nBirthdate : {birthdate.ToLongDateString()}");
        }
        public override string ToString()
        {
            return $"Name : {name}.\nBirthdate : {birthdate}";
        }

    }
    //class Name : BaseClass, Interface1, Interface2, Interface3
    class Worker : Person
    {
        private int salary;

        public int Salary
        {
            get { return salary; }
            set 
            {
                //if (value < 8000)
                //    salary = 8000;
                //else
                //    salary = value;

                //this.salary = value < 8000 ? 8000 : value;
                this.salary = value > 8000 ? value : 8000;
          
            }
        }
        public Worker(): base()
        {
            Salary = 0;
        }
        public Worker(string name, DateTime b, int salary) : base(name, b)
        {
            Salary = salary;
        }
        public override void DoWork()
        {
            Console.WriteLine("Doing some work !!!");
        }
        //new - create a new member and stop virtual
        //override - continue virtual 
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Salary : {Salary}");
        }
    }
    //sealed - запакований - ми забороняємо перевизначати метод
    //в наступних наслідниках
    //sealed - запакований - ми забороняємо наслідування
    class Programmer : Worker
    {
        public int CodeLines { get; set; }
        public Programmer():base()
        {
            CodeLines = 0;  
        }
        public Programmer(string name, DateTime b, int salary):base(name,b,salary)
        {
            CodeLines = 0;
        }
        public void WriteLine()
        {
            CodeLines++;
        }
        public sealed override void DoWork()
        {
            Console.WriteLine("Write code C#!!!");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"CodeLines : {CodeLines}");
        }
    }
    class TeamLead :Programmer
    {
        public int ProjectCount { get; set; }
        public TeamLead() : base()
        {
            ProjectCount = 0;
        }
        public TeamLead(string name, DateTime b, int salary) : base(name, b, salary)
        {
            ProjectCount = 0;
        }
        //public override void DoWork()
        //{
        //    Console.WriteLine("Manage team projects!!!");
        //}
    }
   
 
    internal class Program
    {
        static void Print()
        {
            Console.WriteLine("Heloo");
        }
        static void Main(string[] args)
        {
            Print();

            Worker worker = new Worker("Vova",new DateTime(2000,12,5), 5000);
            worker.DoWork();
            worker.Print();

            Person[] persons = new Person[]
            {
                //new Person(),
                worker,
                new Programmer("Artem", new DateTime(1995,5,7),6500),
                new TeamLead("Mukola", new DateTime(1969,6,7), 55000)
            };
            
            foreach (Person person in persons)
            {
                Console.WriteLine("------------ Info -----------");
                person.Print();
            }
            Console.WriteLine("-----------------------------------");
            Programmer? pr = null;
            int a=0;
            try
            {
                ////------------- 1 use cast()
                pr = (Programmer)persons[0];
                pr.DoWork();
                a = int.Parse(Console.ReadLine());  
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            if( pr != null)
                 pr.Print();
            //=====
            pr?.Print();
            Console.WriteLine(a);
            // -------------- 2 use AS-------------
            pr = persons[1] as Programmer; 
            if( pr != null )
            {
                pr.DoWork();
            }
            // -------------- 3 use AS and IS-------------
            if(persons[0] is Programmer)
                pr = persons[0] as Programmer;
           

           

        }
    }
}
