using System.Text;

namespace _16_01_DirectoriesFiles
{

    internal class Program
    {
        static void Example1()
        {
            //Process.Start("notepad.exe", @"C:\Users\ТимощукВладиславВале\Desktop\bla.txt");

            //DriveInfo[] drives = DriveInfo.GetDrives();
            //for (int i = 0; i < drives.Length; i++)
            //{
            //    Console.WriteLine($"[{i+1}] drive: {drives[i].Name}");
            //}
            //int drive = int.Parse(Console.ReadLine()) - 1;

            //@"C:\Users\Vlad\Desktop"
            //string path = drives[drive].Name; //Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            do
            {
                Console.Clear();
                DirectoryInfo dir = new DirectoryInfo(path);

                Console.WriteLine("Directory: \t{0}", dir.FullName);
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);
                Console.WriteLine("Extension: {0}", dir.Extension);
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);
                Console.WriteLine("LastWriteTime: {0}", dir.LastWriteTime);
                Console.WriteLine("Name: {0}", dir.Name);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Directories ----------------------");
                foreach (var d in dir.GetDirectories())
                {

                    Console.WriteLine($"Directory: {d.Name,20}  time:  " +
                        $"{d.CreationTime,20} atr: {d.Attributes,20}");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Files --------------------------");
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"File: {file.Name,20}  time:  {file.CreationTime,20} " +
                        $"atr: {file.Attributes,20}");
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(path + @"\");
                string next = Console.ReadLine();
                Console.ResetColor();

                string nextPath = Path.Combine(path, next);

                Console.WriteLine("1 - Delete\n" +
                                  "2 - Rename\n" +
                                  "3 - Create\n" +
                                  "* - Open");

                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.D1: Directory.Delete(nextPath); break;
                    case ConsoleKey.D2:
                        {
                            Console.Write("Enter a new folder name:");
                            string newName = Console.ReadLine();
                            Directory.Move(nextPath, Path.Combine(path, newName));
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Directory.CreateDirectory(nextPath);
                            break;
                        }
                    default:
                        path = nextPath;
                        break;
                }

            } while (true);

        }
        static void Example2()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}\n" +
                    $"Type: {drive.DriveType}");

                if (drive.IsReady)
                    Console.WriteLine($"Total size: {drive.TotalSize}\n" +
                        $"Total free size: {drive.TotalFreeSpace}\n" +
                        $"Format size: {drive.DriveFormat}");
            }
            Console.ReadKey();
        }
        static void Example3()
        {
            string param = @"C:\Users\helen\Desktop\textFile.txt";
            string paramD = @"C:\Users\helen\Desktop\Test";

            Directory.CreateDirectory(paramD);
            var file = new FileInfo(param);
            //file.Create();
            var directory = new DirectoryInfo(paramD);
            try
            {

                //file.Delete();
                directory.Delete(true);
                Console.WriteLine("File deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
        static void Example4()
        {
            string path = @"C:\Windows\notepad.exe";
            //OpenFileDialog dialog = new OpenFileDialog();
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{ path = dialog.FileName; }
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                Console.WriteLine("FileName   : {0}", file.Name);
                Console.WriteLine("Ext        : {0}", file.Extension);
                Console.WriteLine("Path       : {0}", file.FullName);
                Console.WriteLine("Dir        : {0}", file.Directory);
                Console.WriteLine("Size(MB)   : {0}", ToMegabytes(file.Length));
                Console.WriteLine("Last Access: {0}", file.LastAccessTime);
            }
            else
            {
                Console.WriteLine("File not existed.");
            }
            Console.ReadKey();
        }
        static double ToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        static void WriteFile(FileInfo f)
        {

            using (FileStream fs = f.Open(FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                Console.WriteLine("\nEnter the data to write to the file:");
                string writeText = Console.ReadLine();
                byte[] writeBytes = Encoding.Default.GetBytes(writeText);
                fs.Write(writeBytes, 0, writeBytes.Length);
                Console.WriteLine("\nData recorded!\n");
            }
        }
        static string ReadFile(FileInfo f)
        {
            using (FileStream fs = f.OpenRead())
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                return Encoding.Default.GetString(readBytes);
            }
        }
        static void Example5()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Test");
            if (!dir.Exists) // если каталог не существует
            {
                dir.Create(); // создаем каталог
            }

            Console.WriteLine($"Last access time to the directory:{dir.LastAccessTime}");

            // создаем подкаталог
            DirectoryInfo dir1 = dir.CreateSubdirectory("Subdir1");

            Console.WriteLine($"Full path to the directory:\n{dir1.FullName}");

            FileInfo fInfo = new FileInfo(dir1 + @"\Test.bin");
            WriteFile(fInfo);

            Console.WriteLine(ReadFile(fInfo));

            Console.WriteLine($"\n\tOnly files with the extension '.bin':");
            FileInfo[] files = dir1.GetFiles("*.bin");
            foreach (FileInfo f in files)
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine();
        }
        static void Example6()
        {

            string path = @"D:\Test";
            if (Directory.Exists(path))
            {
                Console.WriteLine($"Date and time of catalog creation: {Directory.GetCreationTime(path)}");

                Console.WriteLine($"\nSubdirectories in the specified directory: ");
                foreach (string item in Directory.GetDirectories(path))
                {
                    Console.WriteLine($"\t{item}");
                }

                Console.WriteLine($"\nLogical devices of this computer: ");
                foreach (string item in Directory.GetLogicalDrives())
                {
                    Console.WriteLine($"\t{item}");
                }

                // удаляем каталог, все подкаталоги и файлы
                Directory.Delete(path, true);

            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"\nSpecified directory does not exist.\n");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}