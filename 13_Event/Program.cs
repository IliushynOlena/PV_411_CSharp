namespace _13_Event
{
    public delegate void FinishAction();

    public delegate void ExamDelegate(string t);
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Student {LastName} {FirstName} pass the exam {task}");
        }
    }
    public class Teacher
    {
        public event Action TestEvent;
        //As auto property
        //public event ExamDelegate ExamEvent;

        //As full property
        private ExamDelegate examEvent;
        public event ExamDelegate ExamEvent
        {
            add { 
                examEvent += value;
                Console.WriteLine(value.Method.Name + " wass added");
            }
            remove
            {
                examEvent -= value;
                Console.WriteLine(value.Method.Name + " wass removed");
            }
        }
        public void StartAction()
        {
            TestEvent();
        }
        public void CreateExam(string theme)
        {
           
            //create task
            //some code 

            //call all students 
            examEvent?.Invoke(theme);
        }
    }
    internal class Program
    {
        static void HardWork(FinishAction action)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i + 1} started ");
                Thread.Sleep(500);
                Console.WriteLine($"Operation {i + 1} ended ");
            }
            //some message
            action.Invoke();
        }
        static void Action1()
        {
            Console.WriteLine("Excellent");
        }
        static void Action2()
        {
            Console.WriteLine("Good");
        }
        static void Main(string[] args)
        {
            //HardWork(Action1);
            //HardWork(Action2);
            //HardWork(delegate () { Console.WriteLine("Very Bad"); });

            List<Student> students = new List<Student>() {
                new Student()
                {
                     FirstName = " Olga",
                      LastName = "Oliunuk",
                       Birthdate = new DateTime(2000,12,4)
                },
                 new Student()
                {
                     FirstName = " Petro",
                      LastName = "Oliunuk",
                       Birthdate = new DateTime(2003,12,4)
                },
                  new Student()
                {
                     FirstName = " Mukola",
                      LastName = "Oliunuk",
                       Birthdate = new DateTime(2002,12,4)
                },
                   new Student()
                {
                     FirstName = " Ira",
                      LastName = "Oliunuk",
                       Birthdate = new DateTime(2001,12,4)
                },
                    new Student()
                {
                     FirstName = " Nikita",
                      LastName = "Oliunuk",
                       Birthdate = new DateTime(2000,12,4)
                }
            };

            Teacher teacher = new Teacher();

            foreach (var item in students)
            {
                teacher.ExamEvent += new ExamDelegate(item.PassExam);
            }
            teacher.ExamEvent -= students[students.Count - 1].PassExam;
            //teacher.ExamEvent = null;
            teacher.CreateExam("Exam OOP C++ tomorrow at 18 o'clock");

            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent += Console.Clear;
            teacher.TestEvent -= Console.Clear;
            teacher.TestEvent += Console.WriteLine;
            teacher.TestEvent += delegate () { Console.BackgroundColor = ConsoleColor.Green; };
            teacher.TestEvent -= delegate () { Console.BackgroundColor = ConsoleColor.Green; };
            teacher.TestEvent += ()=> Console.Beep(500,500);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent -= Teacher_TestEvent;

            teacher.StartAction();  
                 
        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto-created method by pressing TAB!!!");
        }
    }
}       
