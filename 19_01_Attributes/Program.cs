using System.Reflection;

namespace _19_01_Attributes
{
    [AttributeUsage(AttributeTargets.Method| AttributeTargets.Class | 
        AttributeTargets.Constructor)]
    class CoderAttribute: Attribute
    {
        public string Name { get; set; } = "Olena";
        public DateTime Date { get; set; } = DateTime.Now;
        public CoderAttribute() { }
        public CoderAttribute(string name, string data)
        {
            try
            {
                Name = name;
                Date = Convert.ToDateTime(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public override string ToString()
        {
            return $"{Name} : {Date}";
        }

    }

    [Obsolete, Serializable]
    [CoderAttribute]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        [Coder]
        public Employee() { }

        [Coder("Artem","2025-07-14")]
        public void InceaseSalary(double salary) {
            Salary += salary;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Console.WriteLine(employee);

            Console.WriteLine("Attributes of class Employee");
            foreach (var item in typeof(Employee).GetCustomAttributes(true))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Attributesof members of class Employee");
            foreach (MemberInfo item in typeof(Employee).GetMembers())
            {
                Console.WriteLine("\t" + item);
                foreach (var attr in item.GetCustomAttributes(true))
                {
                    Console.WriteLine("\t\t" + attr);
                }
            }
            
        }
    }
}
