using System.Runtime.Serialization.Formatters.Binary;

namespace _19_02_BinarySerializer
{
    internal class Program
    {
        //: двійковому форматi
        // форматі XML 
        //форматі JSON
        [Serializable]
        public class Passport
        {
            public int Number { get; set; }
            public Passport()
            {
                Number = 9999999;
            }
            public override string ToString()
            {
                return Number.ToString();
            }
        }
        [Serializable]
        public class Person
        {
            public Passport Passport { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            int _identNumber;
            [NonSerialized]
            const string Planet = "Earth";

            public Person(int number)
            {

                _identNumber = number;
                Passport = new Passport();
            }
            public override string ToString()
            {
                return $"Name : {Name}, Age: {Age}, Identification number : {_identNumber}, Planet: {Planet}" +
                    $"Passport {Passport}";
            }
        }
        static void Main(string[] args)
        {
            //Person person = new Person(123456)
            //{
            //    Name = "Jack",
            //    Age = 15
            //};
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (Stream st = File.Create("test.bin"))
            //{
            //    formatter.Serialize(st, person);

            //}
            //Console.WriteLine(" BinaryFormatter is OK");


            //Person p = null;
            //using (Stream fsStream = File.OpenRead("test.bin"))
            //{
            //    p = (Person)formatter.Deserialize(fsStream);

            //}
            //Console.WriteLine(p);
            List<Person> persons = new List<Person>()
            {
              new Person(123654){ Name="Jack", Age = 15},
              new Person(123654){ Name="Tom", Age = 12},
              new Person(123654){ Name="Bill", Age = 35},
              new Person(123654){ Name="John", Age = 47}
            };
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (Stream fstream = File.Create("Persons.bin"))
                {
                    formatter.Serialize(fstream, persons);
                }
                Console.WriteLine("BinaryFormatter is OK!!!");


                List<Person> newPersons = null;
                using (Stream fstream = File.OpenRead("Persons.bin"))
                {
                    newPersons = (List<Person>)formatter.Deserialize(fstream);
                }
                foreach (var item in newPersons)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
