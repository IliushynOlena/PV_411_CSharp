using System.Text.Json;
using System.Xml.Serialization;

namespace _19_03_XML_JSON_Serialization
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        int _identNumber;

        const string Planet = "Earth";
        //default constructor
        public Person()
        {
            
        }
        public Person(int number)
        {
            _identNumber = number;
        }
        public override string ToString()
        {
            return $"Name : {Name}, Age: {Age}, Identification number : {_identNumber}," +
                $" Planet: {Planet}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Person> persons = new List<Person>()
            //{
            //  new Person(123654){ Name="Jack", Age = 15},
            //  new Person(123654){ Name="Tom", Age = 12},
            //  new Person(123654){ Name="Bill", Age = 35},
            //  new Person(123654){ Name="John", Age = 47}
            //};
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            //try
            //{
            //    using (Stream fs = File.Create("persons.xml"))
            //    {
            //        xmlSerializer.Serialize(fs, persons);
            //    }
            //    Console.WriteLine("XmlSerializer is OK!!!");
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            //List<Person> newPersons = null;
            //using (Stream fstream = File.OpenRead("persons.xml"))
            //{
            //    newPersons = (List<Person>)xmlSerializer.Deserialize(fstream);
            //}
            //foreach (var item in newPersons)
            //{
            //    Console.WriteLine(item);
            //}

            //JSON serialize 

            List<Person> persons = new List<Person>()
            {
              new Person(123654){ Name="Jack", Age = 15},
              new Person(123654){ Name="Tom", Age = 12},
              new Person(123654){ Name="Bill", Age = 35},
              new Person(123654){ Name="John", Age = 47}
            };
            string fileName = "Person.json";
     
            string jsonString = JsonSerializer.Serialize(persons);
            File.WriteAllText(fileName, jsonString);


            List<Person> newPersons = null;
            jsonString = File.ReadAllText(fileName);
            newPersons = JsonSerializer.Deserialize< List<Person>>(jsonString)!;

            foreach (var item in newPersons)
            {
                Console.WriteLine(item);
            }

        }
    }
}
