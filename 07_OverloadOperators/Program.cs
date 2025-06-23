
namespace _07_OverloadOperators
{
    class Point_3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point_3D() : this(0, 0,0) { }
        public Point_3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"X: {X}. Y : {Y}. Z : {Z} ";
        }
    }
        class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(): this(0, 0) { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X: {X}. Y : {Y} " ;
        }

        public override bool Equals(object? obj)
        {
            
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //public static return_type operator [symbol](parameters)
        //{
        //   code......
        //}
        #region Унарні оператори (-)  ++ --
        public static Point operator -(Point point)
        {
            Point res = new Point
            {
                X = -point.X,
                Y = -point.Y
            };
            return res;
        }
        //public static Point operator -(Point point)
        //{
        //    point.X *= -1;
        //    point.Y *= -1;         

        //    return point;
        //}
        public static Point operator ++(Point point)
        {
            point.X++;
            point.Y++;
            return point ;
        }
        public static Point operator --(Point point)
        {
            point.X--;
            point.Y--;
            return point;
        }
        #endregion
        #region Бінарні оператори + - * /
        public static Point operator +(Point p1, Point p2)
        {

            //------------ 1 ---------------
            //Point res = new Point();
            //res.X = p1.X + p2.X;
            //res.Y = p1.Y + p2.Y;
            //// ---------------- 2 ---------------
            //Point res = new Point(p1.X+ p2.X, p1.Y+ p2.Y);  

            // ----------- 3 -----------------
            Point res = new Point {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            
            return res;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };

            return res;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return res;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };

            return res;
        }
        #endregion
        //< > <= >= == !=
        #region Оператори рівності  == !=
        public static bool operator ==(Point p1, Point p2)
        {
            //return p1.X == p2.X && p1.Y == p2.Y; 
            return p1.Equals(p2);
        }
        //in pair
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        #endregion
        #region Оператори порівняння  < > <= >=
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X + p1.Y < p2.X+ p2.Y;
        }
        //in pair
        public static bool operator >(Point p1, Point p2)
        {
            return p1.X + p1.Y > p2.X + p2.Y;
        }
        public static bool operator <=(Point p1, Point p2)
        {
            return p1.X + p1.Y <= p2.X + p2.Y;
        }
        //in pair
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        #endregion
        #region true/false operators
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0;
        }
        public static bool operator false(Point p)
        {
            return p.X == 0 && p.Y == 0;
        }
        #endregion
        #region Overload types
        public static explicit operator int(Point p)
        {
            return p.X + p.Y ;
        }
        public static implicit operator double(Point p)
        {
            return p.X * p.Y;
        }
        public static explicit operator Point_3D(Point p)
        {
            return new Point_3D(p.X, p.Y, 100);
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //operators + - * / ++ -- < > <= >=
            Point p1 = new Point(5,7);

            Point p2 = new Point(2,4);
            if(p1)
            {
                Console.WriteLine("True");
            }
            else
                Console.WriteLine("False");

            int a = 5;//int ---> int
            double b = 6.4;//double ----> double

            b = a;//int ----> double 5.000000000 implicit
            a = (int) b;//double ---> int  5 explicit

            a = (int)p1;//Point ----> int
            Console.WriteLine(a);
            b = p1;
            Console.WriteLine(b);
            Point_3D point_3D =(Point_3D) p1;
            Console.WriteLine(point_3D);
          
            int x = 7, y = 6;
            Console.WriteLine(x+y);
            ///Console.WriteLine(p1+p2);
            Console.WriteLine($"Point 1 (-) {-p1}");
            Console.WriteLine($"Point 1 (++) {p1++}");
            Console.WriteLine($"Point 1 (++) {++p1}");
            Console.WriteLine($"Point 1 (--) {--p1}");
            Console.WriteLine($"Point 1 (--) {p1--}");

            Console.WriteLine($"Point 1  {p1}");
            Console.WriteLine($"Point 2  {p2}");
            Point res = p1 + p2;
            Console.WriteLine("Res : " + res);
            res = p1 - p2;
            Console.WriteLine("Res : " + res);
            res = p1 * p2;
            Console.WriteLine("Res : " + res);
            res = p1 / p2;
            Console.WriteLine("Res : " + res);

            object obj = new object();

            if(obj.Equals("Hello"))
            {
                Console.WriteLine("True");
            }
            else { Console.WriteLine("False"); }

            string str = "Hello";
            string str2 = "Hello";

            if (str.Equals(str2))
            {
                Console.WriteLine("True");
            }
            else { Console.WriteLine("False"); }

            //if (p1.Equals(p2))
            //{
            //    Console.WriteLine("True point");
            //}
            //else { Console.WriteLine("False point"); }
            if (p1 == p2)
            {
                Console.WriteLine("True point is equals");
            }
            else { Console.WriteLine("False point is not equals"); }
            if (p1 > p2)
            {
                Console.WriteLine("p1 > p2");
            }
            else { Console.WriteLine("p1 < p2"); }
        }
    }
}
