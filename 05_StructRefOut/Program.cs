namespace _05_StructRefOut
{
    partial struct MyStruct
    {
        public int X { get; set; }
    }
    partial struct MyStruct
    {
        public int Y { get; set; }
    }
    class Point : Object
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"X : {X}. Y : {Y}";
        }
    }
    struct Time
    {
        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }
    }
   
    internal class Program
    {
        static void MethodWithParams(string name,params int[] marks)
        {
            Console.WriteLine("------- " + name + " -------------");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(marks[i] + " ");
            }
            Console.WriteLine();
        }
        static void Modify(ref int num,ref string str,ref Point p)
        {
            num += 1;
            str += "!!!";
            p.X++;
            p.Y++;
        }
        static void GetCurrentTime(out int hour,out  int minute, out int second)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
            //return hour + minute + second;
            //return hour , minute, second;
        }
        static void Main(string[] args)
        {

            Point p = new Point();//new - create dynamic memory 
            
            Time time = new Time();//new - invoke default constructor

            Point p1;

            Time time1;
            int a;
            //Out
            //int h , m , s;
            //// Console.WriteLine($"{h}:{m}:{s}");
            // GetCurrentTime(out h,out m,out s);
            // Console.WriteLine($"{h}:{m}:{s}");


            //Ref --- reference  ( ref == & )
            //int num = 10;
            //string str = "Hello academy";
            //Point point = new Point() {  X = 5, Y = 10};
            //Console.WriteLine($"Num : {num}");
            //Console.WriteLine($"Str : {str}");
            //Console.WriteLine($"Point : {point}");
            //Modify(ref num,ref  str,ref point);
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine($"Num : {num}");
            //Console.WriteLine($"Str : {str}");
            //Console.WriteLine($"Point : {point.ToString()}");

            //Params
            //int[] marks = new int[] { 11, 12, 10, 8, 5, 6, 9 };
            //MethodWithParams("Olga", marks);
            //MethodWithParams("Petro", new int[] {7,7,7,7,7,7,7});
            //MethodWithParams("Oleg", [7,7,7,7,7,7,7]);

            //MethodWithParams("Mira", 10,10,10,10,10,11,8,8,8,8,8);


            //Point p = new Point();
            //p.X = 10;
            //p.Y = 20;
            //Console.WriteLine($"X : {p.X}, Y : {p.Y}");

            //_3D_Object.Point point = new _3D_Object.Point();
            //point.X = 100;
            //point.Y = 200;
            //point.Z = 300;
            //Console.WriteLine($"X : {point.X}, Y : {point.Y}, Z : {point.Z}");
        }
    }
}
namespace _3D_Object
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }


}

