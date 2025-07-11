using System.Text;

namespace _18_01_WorkWithFile
{

    internal class Program
    {
        static void WriteFile(string path)
        {
            ////1
            //FileStream fs = new FileStream("test.txt", FileMode.Create);
            /////throw ex;
            //fs.Write();
            /////throw ex;
            //fs.Read();
            /////throw ex;
            //fs.Close();

            //2
            //FileStream fs = new FileStream("test.txt", FileMode.Create);
            //try
            //{
            //    ///throw ex;
            //    //fs.Write();
            //    ///throw ex;
            //    //fs.Read();
            //    ///throw ex;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally { fs.Close(); }

            //3
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write,
                 FileShare.Write | FileShare.Read))
            {
                Console.WriteLine("Enter some text : ");
                string writeText = Console.ReadLine();
                byte[] writeBytes = Encoding.Default.GetBytes(writeText);   
                fs.Write(writeBytes, 0, writeBytes.Length);
                Console.WriteLine("Information recorded!!!");


            }//fs.Dispose(fs.Close());
           
        }

        static string ReadFromFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] readArr = new byte[fs.Length];
                fs.Read(readArr, 0, readArr.Length);
                return Encoding.Default.GetString(readArr);

            }//fs.Close()

        }
        static void WriteTextFormat(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                
                sw.Write("Hello!");
                sw.Write("Hello!");
                sw.Write("Hello!");
                sw.Write("Hello!");
                sw.WriteLine("How are you?");
                sw.WriteLine("How are you?");
                sw.WriteLine("How are you?");
            }
        }
        static void ReadTextFormat(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            { 
                //sr.Read();
                //sr.ReadBlock();
                //sr.ReadLine();
                //sr.ReadToEnd();

                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine() + "!!!");
                }
            }
        }
        static void Main(string[] args)
        {

            //string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\FileText.txt";
            //WriteFile(filePath);
            //Console.WriteLine(ReadFromFile(filePath));

            //string path1 = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Stringtext1.txt";
            //WriteTextFormat(path1);
            //ReadTextFormat(path1);

            //FileStream file = null;
            ////file = new FileStream(@"test.txt", FileMode.Create);
            ////file = File.Open(@"test.txt", FileMode.Open, FileAccess.Write, FileShare.Write);                      
            //file = File.Create(@"test1.txt");

            //// 1.
            //var writer = new StreamWriter(file);
            //writer.Write("Hello");
            //writer.WriteLine("\tworld");
            //writer.Close();
            //file?.Close(); // null-conditional operator

            //// 2.
            //writer = File.CreateText(@"test2.txt");
            //writer.WriteLine("Hello");
            //writer.Close();

            //// 3.
            //File.WriteAllText(@"test3.txt", "Hello");
            #region StreamReader and StreamWriter
            /*
             *  string path = @"test.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                   
                    Console.WriteLine(sr.ReadToEnd());
                }

                Console.WriteLine();

                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;                    
                    while ((line = sr.ReadLine()) != null)
                    {                        
                        Console.WriteLine($"<{line}>");
                    }
                }

                Console.WriteLine();
 
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    char[] array = new char[4];
                    sr.Read(array, 0, 4);
                    Console.WriteLine(array);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

              string readPath = @"read.txt";
            string writePath = @"write.txt";
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
                {
                    sw.WriteLine(text);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    sw.WriteLine("Append");
                    sw.Write(454875);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var reader = File.OpenText(@"test.txt");
          

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != null && line.Contains("Andrew"))
                {
                    Console.WriteLine("Found:");
                    Console.WriteLine(line);
                    break;
                }
            }

            reader.Close();
            Console.ReadKey();
             
             
             */
            #endregion

            #region Binary Writer , Binary Reader

            //FileStream file = File.Create(@"info.bin");

            //BinaryWriter writer = new BinaryWriter(file);

            //long number = 100;
            //var bytes = new byte[] { 10, 20, 50, 100 };
            //var ints = new int[] { 10, 20, 50, 100 };
            //string s = "hunger";


            //writer.Write(number);
            //writer.Write(bytes);
            //writer.Write(s);

            //for (int i = 0; i < ints.Length; i++)
            //{
            //    writer.Write(ints[i]);
            //}


            //writer.Close();


            //Console.ReadKey();

            FileStream file = File.Open(@"info.bin", FileMode.Open);

            var reader = new System.IO.BinaryReader(file);


            long number = reader.ReadInt64();
            byte[] bytes = reader.ReadBytes(4);
            string s = reader.ReadString();
            int[] arr = new int[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = reader.ReadInt32();
            }

            reader.Close();

            Console.WriteLine(number);
            foreach (byte b in bytes)
            {
                Console.Write("[{0}]", b);
            }

            Console.WriteLine();
            Console.WriteLine(s);
            foreach (var item in arr)
            {
                Console.WriteLine(item + " ");
            }

            Console.ReadKey();
            #endregion
        }
    }
}
