namespace _15_Dictionary
{
    class Person
    {
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        
            Dictionary<string,string> countries = new Dictionary<string,string>();

            countries.Add("UA", "Ukrane");
            countries.Add("GB", "Great Britain");
            countries.Add("PL", "Poland");
            countries.Add("CH", "China");
            countries.Add("UK", "United Kindom");
            countries.Add("ESP", "Spain");
            countries.Add("USA", "United States");
            //countries.Add("ESP", "Spain");//error

            foreach (KeyValuePair<string,string> country in countries)
            {
                Console.WriteLine($"Key : {country.Key,10} Value : {country.Value,20}");
            }

            string c = countries["UK"];
            Console.WriteLine(c);

            countries["USA"] = "America";
            countries["ID"] = "India";
            countries.Remove("USA");
            foreach (KeyValuePair<string, string> country in countries)
            {
                Console.WriteLine($"Key : {country.Key,10} Value : {country.Value,20}");
            }


            Dictionary<char, Person> people = new Dictionary<char, Person>();
            people.Add('A', new Person() { Name = "Andriy" });
            people.Add('O', new Person() { Name = "Olga" });
            people.Add('M', new Person() { Name = "Muroslava" });
            people.Add('Y', new Person() { Name = "Yura" });

            if(people.ContainsKey('K'))
                people['K'] = new Person() { Name = "Katya" };
            else
                Console.WriteLine("Error key");

            foreach (KeyValuePair<char, Person> p in people)
            {
                Console.WriteLine($"Key : {p.Key,10} Value : {p.Value.Name,20}");
            }

            foreach (char letter in people.Keys)
            {
                Console.WriteLine(letter);
            }


            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }


        }
    }
}
