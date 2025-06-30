using System.Collections;

namespace _10_StandartInterface
{
    class StudentCard : ICloneable
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Student Card : {Number} . Series : {Series}";
        }
    }
    class Student : IComparable, ICloneable
    {
        public string FirstName { get; set; }//0x111 ---> 0x111
        public string LastName { get; set; }//0x222 ----> 0x222
        public DateTime Birthdate { get; set; }//2000.02.03  ---> 2000.02.03
        public StudentCard StudentCard { get; set; }//0x333 ----> 0x333

        public object Clone()
        {
            //поверхневе копіювання
            Student temp =(Student) this.MemberwiseClone();
            //глибоке копіювання
            //temp.StudentCard = new StudentCard() {
            // Number = this.StudentCard.Number,
            //Series = this.StudentCard.Series};
            temp.StudentCard =  (StudentCard)this.StudentCard.Clone();
            return temp;  
        }

        public int CompareTo(object? obj)
        {
            return FirstName.CompareTo((obj as Student)!.FirstName);
        }
       
        public override string ToString()
        {
            return $"Fullname : {FirstName} {LastName}. Birthdate : {
                Birthdate.ToLongDateString()}. {StudentCard}";
        }
    }
    class Group : IEnumerable
    {
        Student[] students;
        public Group()
        {
            students = [
               new Student
                {
                     FirstName = "Ivan",
                     LastName = "Popchuk",
                     Birthdate = new DateTime(2000,12,7),
                     StudentCard = new StudentCard { Number = 123456, Series = "AAA" }
                },
                 new Student
                {
                     FirstName = "Olga",
                     LastName = "Oliunuk",
                     Birthdate = new DateTime(2005,12,7),
                     StudentCard = new StudentCard { Number = 111111, Series = "BB" }
                },
                  new Student
                {
                     FirstName = "Mukola",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(1999,8,17),
                     StudentCard = new StudentCard { Number = 222222, Series = "CC" }
                },
                   new Student
                {
                     FirstName = "Mira",
                     LastName = "Polishuk",
                     Birthdate = new DateTime(2002,12,7),
                     StudentCard = new StudentCard { Number = 333333, Series = "DD" }
                },
                    new Student
                {
                     FirstName = "Yura",
                     LastName = "Popchuk",
                     Birthdate = new DateTime(2001,12,7),
                     StudentCard = new StudentCard { Number = 444444, Series = "FF" }
                }
           ];
        }

        public IEnumerator GetEnumerator()
        {
           return students.GetEnumerator(); 
        }

        public void Print()
        {
            //students == Array - GetEnumerator()
            foreach (var st in students)
            {
                Console.WriteLine(st);
            }
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students,comparer);
        }
        
    }
    class LastNameComparer : IComparer<Student>
    {
        //public int Compare(object? x, object? y)
        //{
        //   if( x is Student && y is Student )
        //    {
        //        return (x as Student)!.LastName.CompareTo( (y as Student)!.LastName);
        //    }
        //   throw new NotImplementedException(); 
        //}
        public int Compare(Student? x, Student? y)
        {
            return x!.LastName.CompareTo(y!.LastName);
        }
    }
    class BirthdateComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x!.Birthdate.CompareTo(y!.Birthdate);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Group group = new Group();
            for (int i = 0; i < args.Length; i++) { }
            //Smart pointer
            foreach (var st in group)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("------------- Sort by First Name ----------");
            group.Sort();
            foreach (var st in group)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("------------- Sort by Last Name ----------");
            group.Sort(new LastNameComparer());
            foreach (var st in group)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("------------- Sort by Birthdate ----------");
            group.Sort(new BirthdateComparer());
            foreach (var st in group)
            {
                Console.WriteLine(st);
            }
            */
            Student student = new Student
            {
                FirstName = "Ivan",
                LastName = "Popchuk",
                Birthdate = new DateTime(2000, 12, 7),
                StudentCard = new StudentCard { Number = 123456, Series = "AAA" }
            };

            Student copy = (student.Clone() as Student)!;//0x111 ----> 0x111
            Console.WriteLine(student);
            Console.WriteLine(copy);
            copy.FirstName = "Oleg";
            copy.StudentCard.Number = 999999999;

            Console.WriteLine(student);
            Console.WriteLine(copy);


        }
    }
}
