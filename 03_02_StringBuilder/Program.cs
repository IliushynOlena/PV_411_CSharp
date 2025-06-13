using System.Text;

namespace _03_02_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello";//5b
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            str += " world";
            Console.WriteLine(str);

            StringBuilder builder = new StringBuilder();
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);

            builder.Append("word");
            builder.Append("word");
            builder.Append("word");
            builder.Append("word");
            builder.Append("word");
            builder.Append("word");
            Console.WriteLine(builder);
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);

            builder.AppendLine("word");
            builder.AppendLine("word");
            builder.AppendLine("word");
            builder.AppendLine("word");
            builder.AppendLine("word");
            builder.AppendLine("word");
            Console.WriteLine(builder);
            Console.WriteLine("Capacity : " + builder.Capacity);
            Console.WriteLine("Length : " + builder.Length);

            //Char.IsUpper()


        }
    }
}
