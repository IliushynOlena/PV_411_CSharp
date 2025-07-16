using System.Text.RegularExpressions;

namespace _20_RegularExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example 1
            //  System.Text.RegularExpressions 
            /*
                СПЕЦ. СИМВОЛИ
                \d - Визначає символи цифр. 
                \D - Визначає любий символ, який не є цифрою. 
                \w - Визначає любий символ цифри, букви або нижнє підкреслення. 
                \W - Визначає любий символ, який не є цифрою, буквою або 
                     нижнім підкресленням.. 
                \s - Визначає любий недрукований символ, 
                     включаючи пробіл. (таб і перехід на новий рядок)
                \S - Визначає любий символ, крім символів табуляции, 
                     нового рядка и повернення каретки.
                .  - Визначає любий символ крім символа нового рядка.  
                \. - Визначає символ крапки.

            */
            /*
            string pattern = @"\d";
            Regex regex = new Regex(pattern);
            bool flag = true;
            while (flag)
            {
                string str = Console.ReadKey().KeyChar.ToString();
                if(str == " ")flag = false;

                bool success = regex.IsMatch(str);
                Console.WriteLine(success ? $" match is found {pattern} " :
                   $" match is not found {pattern} ");
            }
            */
            #endregion
            #region Example 2
            /*
                КВАНТИФИКАТОРЫ
                ^ - з початку рядка. 
                $ - з кінця рядка. 
                * - нуль і більше входжень підшаблону в сторці.  
                + - одне і більше  входжень підшаблону в сторці.  
                ? - нуль чи одне  входження підшаблону в сторці.    
             */
            /*
            string pattern2 = @"\D+";
            Regex regex2 = new Regex(pattern2);
            var array = new[] { "test", "123", "test123test", "123test", "test123" };
            foreach (string str2 in array)
            {
                Console.WriteLine(
                    regex2.IsMatch(str2) ? $" match is found {str2} -  {pattern2} " :
                    $"match is not found {str2} - {pattern2} ");

                Console.WriteLine(new string('-', 50));
            }

            pattern2 = "^[A-Z][a-z]*$";
            regex2 = new Regex(pattern2);

            while (true)
            {
                Console.WriteLine("Enter string : ");
                string input_str = Console.ReadLine()!;
                if (input_str == "exit") break;


                Console.WriteLine(
                     regex2.IsMatch(input_str) ? $" match is found {input_str} -  {pattern2} " :
                     $"match is not found {input_str} - {pattern2} ");

                Console.WriteLine(new string('-', 50));
            }

            */
            #endregion
            #region Example 3
            string pattern = @"";

            //pattern = @"\d+";
            //pattern = @"\D+";
            //pattern = @"^\d+";
            //pattern = @"\d+$";
            pattern = @"^\d+$";
            var regex = new Regex(pattern);
            var arr = new[] { "test", "123", "test123test", "123test", "test123" };

            foreach (string item in arr)
            {
                Console.WriteLine(regex.IsMatch(item) ? $" String \"{pattern}\" matched" :
                    $" String \"{pattern}\"  NOT mached");

            }


            #endregion
            #region Example 4
            string value = "4 - 5 AND 5 y 578";


            Match m = Regex.Match(value, @"\d");
            if (m.Success) 
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }
            m = m.NextMatch();
            if (m.Success)
            {
                Console.WriteLine(m.Index);
                Console.WriteLine(m.Value);
            }

            Match m1 = Regex.Match("123 Axx-1-xxy \n Axyx-2xyyxy", @"A.*y");
            if (m1.Success)
            {
                Console.WriteLine(m1.Value);
                Console.WriteLine(m1.Index);
                Console.WriteLine(m1.Length);
            }
            m1 = m1.NextMatch();
            if (m1.Success)
            {
                Console.WriteLine(m1.Value);
                Console.WriteLine(m1.Index);
                Console.WriteLine(m1.Length);
            }

            #endregion
            #region Example 5
            string value1 = "saidsaid said shed shed see sprear spread super";
             MatchCollection coll =  Regex.Matches(value1, @"s\w+d");

            foreach (Match match in coll)
            {
                Console.WriteLine($"Index = {match.Index}. Value : {match.Value}");
            }


            string inputString = "Don't replace Dot Net replaced Net Net dots";

            string output = Regex.Replace(inputString, "N.t", "NET");
            Console.WriteLine(output);

            #endregion

        }
    }
}
