namespace _06_ExceptionNamespaces
{
     partial class Test
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
    partial class Test
    {
        public int MyProperty11 { get; set; }
        public int MyProperty13 { get; set; }
        public int MyProperty21 { get; set; }
    }
    internal class Program
    {
        static void Test()
        {
            Console.WriteLine("Hello");
        }
        static void Main(string[] args)
        {
           
            Test();
            //https://github.com/IliushynOlena/Exceptions
            //https://github.com/IliushynOlena/c_charp_namespaces 
            Console.WriteLine("Hello, World!");
        }
    }
}
