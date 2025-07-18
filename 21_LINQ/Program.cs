namespace _21_LINQ
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return "Product " + Name + " : " + Category;
        }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //C# - LINQ Language Integrated Query (LINQ)
            // інтерфейс IEnumerable.
            #region Select
            // Существует несколько разновидностей LINQ:
            /*
                LINQ to Objects:        применяется для работы с массивами и коллекциями    
                LINQ to Entities:       используется при обращении к базам данных через 
                                        технологию Entity Framework
                LINQ to Sql:            технология доступа к данным в MS SQL Server
                LINQ to XML:            применяется при работе с файлами XML
                LINQ to DataSet:        применяется при работе с объектом DataSet
                Parallel LINQ (PLINQ):  используется для выполнения параллельной запросов    
            */
            /*
             Синтаксис запиту
             res = from elem in sourse
                   select elem;             
             */
            int[] arr = { 5, 7, 14, 21, -32, 56, -89, 58, -74 };
            //List<int> list = new List<int>() { 5, 7, 14, 21, 32, 56, 89, 58, 74 };

            //var query = from i in arr select i;
            //int[] query = from i in arr select i;
            //Console.WriteLine("--------Copy array ------");
            IEnumerable<int> query = from i in arr select i * -1;
            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("--------Original array ------");
            arr[0] = 100;

            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            /*

            Синтаксис методу

             /*Синтаксис методу */
            // Список используемых методов расширения LINQ
            /*
                Select: определяет проекцию выбранных значений

                Where: определяет фильтр выборки

                OrderBy: упорядочивает элементы по возрастанию

                OrderByDescending: упорядочивает элементы по убыванию

                ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

                ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию

                Join: соединяет две коллекции по определенному признаку

                GroupBy: группирует элементы по ключу

                ToLookup: группирует элементы по ключу, при этом все элементы 
                          добавляются в словарь

                GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу

                Reverse: располагает элементы в обратном порядке

                All: определяет, все ли элементы коллекции удовлятворяют определенному условию

                Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию

                Contains: определяет, содержит ли коллекция определенный элемент

                Distinct: удаляет дублирующиеся элементы из коллекции

                Except: возвращает разность двух коллекцию, то есть те элементы, которые содератся только в одной коллекции

                Union: объединяет две однородные коллекции

                Intersect: возвращает пересечение двух коллекций, то есть те элементы, 
                           которые встречаются в обоих коллекциях

                Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию

                Sum: подсчитывает сумму числовых значений в коллекции

                Average: подсчитывает cреднее значение числовых значений в коллекции

                Min: находит минимальное значение

                Max: находит максимальное значение

                Take: выбирает определенное количество элементов

                Skip: пропускает определенное количество элементов

                TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно

                SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы

                Concat: объединяет две коллекции

                Zip: объединяет две коллекции в соответствии с определенным условием

                First: выбирает первый элемент коллекции

                FirstOrDefault: выбирает первый элемент коллекции или 
                                возвращает значение по умолчанию

                Single: выбирает единственный элемент коллекции, если коллекция содердит больше или меньше одного элемента, то генерируется исключение

                SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию

                ElementAt: выбирает элемент последовательности по определенному индексу

                ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона

                Last: выбирает последний элемент коллекции

                LastOrDefault: выбирает последний элемент коллекции 
                       или возвращает значение по умолчанию
             */

            //query = arr.Select(SelectInt);
            //query = arr.Select(delegate(int i) { return i * -1; });
            query = arr.Select(i=> i * -1);
            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion
            #region Where
            int[] arrInt = { 15, 7, 8, 9, 12, 14, 78, 95, 36, 15 };

            query = from i in arrInt
                    where i%2 == 0
                    select i * -1;

            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            query = arrInt.Where(i=> i%2 == 0).Select(i=>i * -1);
            foreach (int i in query)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Фільтрація слів по кількості символів
            string[] words = { "jello", "faee", "tyytik", "erte",
                "qwe", "bvnv", "fhjfhj" };

            var result = from word in words
                         where word.Length == 4
                         select word;
            //var result2 = words.Where(word => word.Length == 4).Select(word=>word);
            var result2 = words.Where(word => word.Length == 4);

            foreach (var item in result2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            #endregion
            #region Order By
            int[] arrOrder = { 15, 7, 8, 9, 12, 14, 78, 95, 36, 15 };
            query = from i in arrOrder
                    where i%2 == 0
                    orderby i descending //ascending(default)
                    select i;

            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            query = arrOrder.Where(i => i % 2 == 0).OrderBy(i => i);
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            query = arrOrder.Where(i => i % 2 == 0).OrderByDescending(i => i);
            foreach (var item in query)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            #endregion
            #region Group by
            int[] arrGroup = { 5, 34, 65, 12, 94, 42, 365, 15 };

            IEnumerable<IGrouping<int,int>> QUERY = from i in arrGroup
                        where i > 10
                        group i by i % 10;

            foreach (IGrouping<int, int> item in QUERY)
            {
                Console.Write(item.Key + " - ");
                foreach (var elem in item)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }

            //QUERY = arrGroup.Where(i=> i> 10).GroupBy(i => i%10).Select(i=>i);
            QUERY = arrGroup.Where(i=> i> 10).GroupBy(i => i%10).OrderBy(g=>g.Key);
  
            foreach (IGrouping<int, int> item in QUERY)
            {
                Console.Write(item.Key + " - ");
                foreach (var elem in item)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }
            Product[] products = {
                new Product(){ Name = "Apple", Category ="Food"},
                new Product(){ Name = "Phone", Category ="Tech"},
                new Product(){ Name = "Laptop", Category ="Tech"},
                new Product(){ Name = "Banana", Category ="Food"},
                new Product(){ Name = "Pelmen", Category ="Food"}
            };

            var res = products.GroupBy(p => p.Category);
            foreach (IGrouping<string, Product> item in res)
            {
                Console.Write(item.Key + " - ");
                foreach (Product elem in item)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Agregation function
            // Count-------------------- -
            //int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            //int size = (from i in numbers
            //            where i % 2 == 0 && i > 10
            //            select i).Count();
            //Console.WriteLine(size);

            //size = numbers.Where(i => i % 2 == 0 && i > 10).Count();
            //size = numbers.Count(i => i % 2 == 0 && i > 10);
            //Console.WriteLine(size);

            // Sum, Min, Max, Average ---------------------------
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            int sum1 = numbers.Sum();
            int sum2 = users.Sum(u=>u.Age);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            int min1 = numbers.Min();
            //string min2 = users.Min(u=>u.Name); // минимальный возраст
            int min2 = users.Min(u=>u.Age); // минимальный возраст
            Console.WriteLine(min1);
            Console.WriteLine(min2);
            int max1 = numbers.Max();
            int max2 = users.Max(u=>u.Age); // максимальный возраст
            Console.WriteLine(max1);
            Console.WriteLine(max2);
            double avr1 = numbers.Average();
            double avr2 = users.Average(u=>u.Age); //средний возраст
            Console.WriteLine(avr1);
            Console.WriteLine(avr2);


            #endregion

            #region MyRegion
            string[] soft = { "Blue", "Grey", "Yellow", "Cyan", "Grey", "Yellow" };
            string[] hard = { "Yellow", "Magenta", "White", "Blue" };

            IEnumerable<string> result3;

            // Except -----------------------        
            // знаходимо різницю між двома колекціями
            //чим колекція hard відрізняється від soft
            //result3 = soft.Except(hard);           
            //result3 = hard.Except(soft);
            // Intersect ---------------------------
            // отримуємо елементи колекції А, які присутні в колекції В (без дублікатів)
            //result3 = soft.Intersect(hard);           

            // Union ---------------------------
            // з'єднує елементи двох колекцій (без дублікатів)
            //result3 = soft.Union(hard);


            // Concat -------------
            // з'єднує елементи двох колекцій
            //result3 = soft.Concat(hard);

            // Distinct ----------------
            // видаляє дублікати
            result3 = soft.Distinct();

            foreach (string s in result3)
                Console.WriteLine(s);
            #endregion
            Dictionary<string, List<string>> dic= new Dictionary<string, List<string>>();
            dic.Add("Cat", new List<string> { "Кіт" });
        }
        static int SelectInt(int i) 
        {
            return i*-1;
        }
    }
}
