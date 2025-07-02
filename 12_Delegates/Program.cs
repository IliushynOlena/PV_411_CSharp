namespace _12_Delegates
{
    //class MyDelegate : MulticastDelegate, Delegate
    //{

    //}
  
    public delegate int IntDelegate(double a);


    public delegate void SetStringDelegate(string s);
    public delegate double DoubleDelegate();
    public delegate void VoidDelegate();
    public class SuperClass
    {
        public void Print(string str)
        {
            Console.WriteLine("String : " + str);
        }
        public static double GetCoef()
        {
            return new Random().NextDouble();   
        }
        public double GetNumber()
        {
            return new Random().Next();
        }
        public void DoWork()
        {
            Console.WriteLine("Doing some work");
        }
        public void Test()
        {
            Console.WriteLine("Testing");
        }
    }
    public delegate double CalculatorDelegate(double a, double b);
    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;   
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double Multy(double a, double b)
        {
            return a * b;
        }
        public double Div(double a, double b)
        {
            return a / b;
        }
    }
    public delegate int ChangeDelegate(int a);
    internal class Program
    {
        public static void DoOperation(double a, double b, CalculatorDelegate operation)
        {
            Console.WriteLine(operation.Invoke(a, b));
        }
        public static void ChangeElements(int[]arr, ChangeDelegate operation)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = operation(arr[i]);
            }
        }
        public static int Sqrt(int a)
        {
            return a * a;
        }
        public static int Increment(int a)
        {
            return ++a;
        }
        public static int Decrement(int a)
        {
            return --a;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            foreach (var item in arr) Console.Write(item + " ");
            Console.WriteLine();
            ChangeElements(arr, Sqrt);
            foreach (var item in arr) Console.Write(item + " ");

            Console.WriteLine();
            ChangeElements(arr, Increment);
            foreach (var item in arr) Console.Write(item + " ");

            Console.WriteLine();
            ChangeElements(arr, Decrement);
            foreach (var item in arr) Console.Write(item + " ");
            //anonimus delegate
            Console.WriteLine();
            ChangeElements(arr, delegate (int a) { return a + 10; });
            foreach (var item in arr) Console.Write(item + " ");

            //lambda expresion 
            Console.WriteLine();
            ChangeElements(arr, (v)=> v*100);
            foreach (var item in arr) Console.Write(item + " ");


            /*

            Calculator calculator = new Calculator();
            CalculatorDelegate calcDelegate = calculator.Add;
            calcDelegate += calculator.Sub;
            calcDelegate += calculator.Multy;
            calcDelegate += calculator.Div;
            calcDelegate -= calculator.Div;

            foreach (var item in calcDelegate.GetInvocationList())
            {
                Console.WriteLine(((CalculatorDelegate)item)!.Invoke(100,5));
            }

            DoOperation(100,5, calculator.Add);
            DoOperation(100,5, calculator.Sub);
            DoOperation(100,5, calculator.Multy);
            DoOperation(100,5, calculator.Div);
            */
            //Calculator calculator = new Calculator();
            //double x, y;
            //int key;
            //do
            //{
            //    CalculatorDelegate calcDelegate = null;
            //    Console.WriteLine("Enter first number ");
            //    x = double.Parse(Console.ReadLine()!);
            //    Console.WriteLine("Enter second number ");
            //    y = double.Parse(Console.ReadLine()!);
            //    Console.WriteLine("Add  - 1 ");
            //    Console.WriteLine("Sub  - 2 ");
            //    Console.WriteLine("Mult  - 3 ");
            //    Console.WriteLine("Divide  - 4 ");
            //    Console.WriteLine("Exit  - 0 ");
            //    key = int.Parse(Console.ReadLine()!);
            //    switch (key)
            //    {
            //        case 1:
            //            calcDelegate = new CalculatorDelegate(calculator.Add);
            //            break;
            //        case 2:
            //            calcDelegate = new CalculatorDelegate(calculator.Sub);
            //            break;
            //        case 3:
            //            calcDelegate = calculator.Multy;
            //            break;
            //        case 4:
            //            calcDelegate = calculator.Div;
            //            break;
            //        case 0:
            //            Console.WriteLine("Good  Buy");
            //            break;
            //        default:
            //            Console.WriteLine("Error choice......");
            //            break;
            //    }

            //    Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            //} while (key != 0);




            /*
            SuperClass superClass = new SuperClass();
            //DoubleDelegate doubleDelegate = new DoubleDelegate(SuperClass.GetNumber);
            DoubleDelegate doubleDelegate = superClass.GetNumber;

            Console.WriteLine(superClass.GetNumber()); 
            // Console.WriteLine(doubleDelegate()); 
            Console.WriteLine(doubleDelegate?.Invoke());
            Console.WriteLine(".........................");

            DoubleDelegate[] del = new DoubleDelegate[]
            {
                SuperClass.GetCoef,
                superClass.GetNumber
            };
            Console.WriteLine(del[0].Invoke());
            Console.WriteLine(del[1]()); 

            SetStringDelegate str  = new SetStringDelegate(superClass.Print);
            str.Invoke("Hello acamedy");

            VoidDelegate voidDelegate = superClass.DoWork;
            voidDelegate.Invoke();

            voidDelegate = superClass.Test;
            voidDelegate.Invoke();
            //Multycasting 
            //Delegate.Combine(voidDelegate, superClass.DoWork);
            //voidDelegate += new VoidDelegate(superClass.DoWork);
            voidDelegate += superClass.DoWork;
            voidDelegate += superClass.DoWork;
            voidDelegate += superClass.DoWork;

            foreach (var item in voidDelegate.GetInvocationList())
            {
                (item as VoidDelegate)!.Invoke();
            }
            */
        }
    }
}
