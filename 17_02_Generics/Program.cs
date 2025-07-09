namespace _17_02_Generics
{
    /*
  * Generics
  *----------------------
     Classes
     Structures
     Collection
     Methods
     Interface
     Delegate
      */
    //template<typename T>

    public delegate int SummaDelegate(int x, int y);
    public delegate float SummaDelegateFloat(float x, float y);
    //Generic delegate
    public delegate Type OperationDelegate<Type>(Type x, Type y);
    public delegate bool MyCompareDelegate<T1, T2>(T1 el1, T2 el2);

    //Generics interface
    //template<typename T >
    interface IMyComparable<T>
    {
        void CompareMyObject(T obj1, T obj2);
    }
    interface IIndexer<T>
    {
        T this[int index] { get; set; }
    }
    class Student : IMyComparable<Student>
    {
        public Student(string n)
        {
            
        }
        public void CompareMyObject(Student obj1, Student obj2)
        {
            throw new NotImplementedException();
        }
    }


    class B : IMyComparable<B>, IIndexer<string>
    {
        string[] lines;
        public string this[int index] { get => lines[index]; set => lines[index] = value; }

        public void CompareMyObject(B obj1, B obj2)
        {
            throw new NotImplementedException();
        }

        //public string this[int index]
        //{
        //    get
        //    {
        //        return lines[index];
        //    }

        //    set { lines[index] = value; }

        //}

    }

    class MyArray<Type>: IIndexer<Type> 
    {
        private Type[] array;//array = null;

        public Type this[int index] { get => array[index]; set => array[index] = value; }

        public MyArray(int size = 10)
        {
            array = new Type[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = default(Type);
                //Type = numeric ---> 0
                //Type = bool ---> false
                //Type = references ---> null
            }
        }
        public void AddElement(Type elem)
        {
            Array.Resize(ref array, array.Length+1);
            array[array.Length-1] = elem;
        }
        public override string ToString()
        {
            string res = "";
            foreach (Type t in array)
            {
                res += t + " ";
            }
            return res;
        }
    }
    class Point<T1, T2>// where T1 : class, IComparable<T1>, new() where T2 : class, 
                       // IComparable<T2>, new()
    {

        // do not allow to use arif and logic operations for generic types: T1, T2
        public T1 X { get; set; }
        public T2 Y { get; set; }

        // Default ctor
        public Point()
        {
            //X = 0;       // error
            //Y = null;    // error

            // -------- Default values:
            // for reference: null
            // numbers: 0
            // boolean: false
            X = default(T1);
            Y = default(T2);

            // with limited new()
            // T1 item = new T1();
            //Student st1;
           // Student st = new Student();
            //Int32 a = new int();
            //int b = new int();  //0
            //bool flag;
           // bool fl = new bool();



            // with interface limit
            //item.CompareTo(X);
        }

        public Point(T1 x, T2 y)
        {
            this.X = x;
            Y = y;

            // typeof - return Type of an element
            if (typeof(T1) == typeof(int))
            {
                Console.WriteLine("T1 is int");
            }
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static float Sub(float a, float b)
        {
            return a - b;
        }
        static bool Compare(double b1, decimal b2)
        {
            return (decimal)b1 == b2;
        }
        // Generic Method ------------------------
        //template<typename T>
        static void ShowObject<T>(T obj)
        {
            //Console.WriteLine(obj);
            Console.WriteLine(obj.ToString());
        }
        static bool CompareHashCode<T1, T2>(T1 obj1, T2 obj2)
        {
            return obj1.GetHashCode() == obj2.GetHashCode();
        }
        static TRes Mult<T1, T2, TRes>(T1 op1, T2 op2)
        {
            TRes result = default(TRes);
            return result;
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            MyCompareDelegate<double, decimal> compare = Compare;
            Console.WriteLine(compare?.Invoke(5.3, 1.2m));

            OperationDelegate<int> operationDelegate = Add;
            Console.WriteLine(operationDelegate.Invoke(5,8));

            OperationDelegate<float> operationDelegate1 = Sub;
            Console.WriteLine(operationDelegate1.Invoke(5, 8));

            MyArray<float> array = new MyArray<float>();
            array.AddElement(3.14f);
            array.AddElement(1.8f);
            array.AddElement(2.9f);
            Console.WriteLine(array);

            MyArray<bool> myArray = new MyArray<bool>();    
            myArray.AddElement(true);
            myArray.AddElement(true);
            myArray.AddElement(true);
            Console.WriteLine(myArray); ;

            Point<int, double>point = new Point<int, double>(5, 6.3);
            Console.WriteLine(point);


            //////////// methods
            short a = 10;
            int b = 120;
            //string a = "Hello";
            //string b = "Hello friend";
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            if (CompareHashCode<short, int>(a, b))
                Console.WriteLine("Hash codes equals!");
            else
                Console.WriteLine("Hash codes not equals!");

            ShowObject<int>(55);
            ShowObject<string>("Hello");
            ShowObject(55);
            ShowObject<Point<int, int>>(new Point<int, int>());

            Mult<int, double, decimal>(5, 1.5);

        }
    }
}
