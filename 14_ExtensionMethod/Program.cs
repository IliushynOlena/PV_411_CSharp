using System.Runtime.CompilerServices;

namespace _14_ExtensionMethod
{
    static class ExampleExtension
    {
        public static int NumberWords(this string data)
        {
            if(string.IsNullOrEmpty(data)) return 0;

            return data.Split(new char[] {' ',',','.','!','?'}, 
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int NumberLetter(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;

            int count = 0;
            foreach (var letter in data)
            {
                if (letter == s) count++;
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string str = "Lorem Ipsum is simply dummy " +
                "text of the printing and typesetting industry.";
            Console.WriteLine("Count of word : " + str.NumberWords());
            Console.WriteLine("Count of letters : " + str.NumberLetter('o'));
            Console.WriteLine("Count of letters : " + str.NumberLetter('l'));
            Console.WriteLine("Count of letters : " + str.NumberLetter('p'));
        }
    }
}
