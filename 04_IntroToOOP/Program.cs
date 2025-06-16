namespace _04_IntroToOOP
{
    struct NewPoint
    {
        public int X;
        public int Y;
        public void Print()
        {
            Console.WriteLine($"X : {X}, Y : {Y}");
        }

    }
    partial class Point : Object
    {
        //private (default for fields)
        //public
        //protected
        //internal
        //protected  internal

        //private int number;//private
        //private string name;
        //private const float PI = 3.14f;
        //private readonly int id ;
        //public Point()
        //{
        //    id = 0;
        //    this.id = 0;
        //}
        //void setId(int id)
        //{
        //    this.id = id;
        //}
     

        private static int count;
        static Point()
        {
            count = 0;
        }
        public Point(): this(0, 0) { }
       
        public Point(int xCoord, int yCoord)
        {
            //setX(xCoord);    
            //setY(yCoord);
            XCoord = xCoord;
            YCoord = yCoord;
            Color = "Red";
        }
      
        public void Print()
        {
            //Console.SetCursorPosition(xCoord, yCoord); Console.WriteLine("*");
            Console.WriteLine($"X : {xCoord}, Y : {yCoord}");
        }

        public override string ToString()
        {
            return $"X : {xCoord}, Y : {yCoord}";
        }

    }
    class DerivedClass: Point //public
    {

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Point @class = new Point();
            Point p = new Point(-10,4);  
            p.Print();
            Console.WriteLine(p.ToString());
            //x=100;
            p.setX(100);
            Console.WriteLine(p.getX());
            p.XCoord = 150;//setter value = 150;
            Console.WriteLine(p.XCoord);
            p.YCoord = -10;
            Console.WriteLine(p.YCoord);

            p.Name = "2D Point";
            Console.WriteLine(p.Name);

            //p.Color = "Red";
            Console.WriteLine(p.Color);
            p.MovePoint(15, 15);
            Console.WriteLine(p);

            Point[] points = new Point[5];
            points[0] = p;
            points[1] = new Point(47,25);


        }
    }
}



