namespace _09_Interfaces
{
    abstract class MyClass
    {
        //public abstract void Print();
    }
    //interface IWorker
    //{
    //    //private int a; //error
    //    //public 
    //    string Work(); 
    //    bool IsWorker {  get; }

    //    event EventHandler Worked;       
    //}
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public override string ToString()
        {
            return $"Fullmane : {FirstName}  {LastName}." +
                $" Birthdate {Birthdate.ToLongDateString()}";
        }
    }
    class Employee:Human
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPosition : {Position}." +
                $" Salary : {Salary}";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> ListOfWorker { get; set; }
        void Organize();
        void Control();
        void MakeBudgect();
    }
    class Director : Employee, IManager//implement / realize
    {
        public List<IWorkable> ListOfWorker { get; set; }
        public void Control()
        {
            Console.WriteLine("I control work..");
        }

        public void MakeBudgect()
        {
            Console.WriteLine("I count money..");
        }

        public void Organize()
        {
            Console.WriteLine("I organize work....");
        }
    }
    class Seller : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "I am selling product";
        }
    }
    class Cashier : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "I getting pay for product";
        }
    }
    class Administrator : Employee, IWorkable, IManager
    {
        public bool IsWorking =>true;

        public List<IWorkable> ListOfWorker { get; set; }
        public void Control()
        {
            Console.WriteLine("Xaxaxaxaaxax. I am a boss!!!");
        }

        public void MakeBudgect()
        {
            Console.WriteLine("I have a lot of money!!!");
        }

        public void Organize()
        {
            Console.WriteLine("You must listen to me!!!!");
        }

        public string Work()
        {
            return "I can do my work(((((";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Director director = new Director()
            IManager director = new Director()
            { 
                 FirstName = "Oleg",
                 LastName = "Oliunuk",
                 Birthdate = new DateTime(1967, 5,14),
                 Position = "Director",
                 Salary = 8000
            };
            Console.WriteLine(director);
            //director.Salary = 55555;
            Console.WriteLine(director);
            if(director is Director)
                (director as Director)!.Salary = 40000;
            Console.WriteLine(director);

            director.ListOfWorker = new List<IWorkable>()
            {
                new Cashier
                {
                     FirstName = "Olga",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(2000, 5,14),
                     Position = "Cashier",
                     Salary = 9000
                },
                  new Seller
                {
                     FirstName = "Misha",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(1995, 5,14),
                     Position = "Seller",
                     Salary = 9000
                },
            };
            foreach (var empl in director.ListOfWorker)
            {
                Console.WriteLine(empl);
            }

            //Seller seller = new Seller
            IWorkable seller = new Seller
            {
                FirstName = "Misha",
                LastName = "Ivanchuk",
                Birthdate = new DateTime(1995, 5, 14),
                Position = "Seller",
                Salary = 9000
            };
            //seller.Salary = 100000000;
            Console.WriteLine(seller);
            
            //Multiple interface
            Administrator admin = new Administrator();

            IManager manager = admin;
            manager.Control();

            IWorkable workable = admin;
            workable.Work();

            /////////////
            /////https://github.com/IliushynOlena/cs_interfaces

        }
    }
}
