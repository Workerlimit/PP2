using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class FarManager
    {
        public int cursor;
        public int size;
        public string path;
        public bool ok;
        DirectoryInfo direct = null;
        FileSystemInfo currentFile = null;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            direct = new DirectoryInfo(path);
            size = direct.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Color(FileSystemInfo files, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Magenta;
                currentFile = files;
            }
            else if (files.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            direct = new DirectoryInfo(path);
            FileSystemInfo[] files = direct.GetFileSystemInfos();

            for (int i = 0, k = 0; i < files.Length; i++)
            {
                if (ok == false && files[i].Name[0] == ' ')
                {
                    continue;
                }
                Color(files[i], k);
                int count = i + 1;
                Console.WriteLine(count + ". " + files[i].Name);
                k++;
            }
        }

        public void Up()
        {
            cursor--;
            if (cursor < 0)
            {
                cursor = size - 1;
            }
        }

        public void Down()
        {
            cursor++;
            if (cursor == size)
            {
                cursor = 0;
            }
        }

        public void Delete()
        {
            currentFile.Delete();
        }

        public void N()
        {

            File.Move(currentFile.FullName, Console.ReadLine());
        }

        public void Enter()
        {
            string files = File.ReadAllText(currentFile.FullName);
            Console.WriteLine(files);
        }

        public void CalcSize()
        {
            direct = new DirectoryInfo(path);
            FileSystemInfo[] files = direct.GetFileSystemInfos();
            size = files.Length;

            if (ok == true)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name[0] == '.')
                    {
                        size--;
                    }
                }
            }
        }

        public void Start()
        {
            ConsoleKeyInfo conKey = Console.ReadKey();
            while (conKey.Key != ConsoleKey.Escape)
            {
                CalcSize();
                Show();
                conKey = Console.ReadKey();
                switch (conKey.Key)
                {
                    case ConsoleKey.Delete:
                        Delete();
                        break;

                    case ConsoleKey.UpArrow:
                        Up();
                        break;

                    case ConsoleKey.DownArrow:
                        Down();
                        break;

                    case ConsoleKey.N:
                        N();
                        break;

                    case ConsoleKey.Enter:
                        if (currentFile.GetType() == typeof(DirectoryInfo))
                        {
                            cursor = 0;
                            path = currentFile.FullName;
                        }
                        else
                        {
                            Enter();
                        }
                        break;
                    case ConsoleKey.Backspace:
                        cursor = 0;
                        path = direct.Parent.FullName;
                        break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/programs/FarManager";
            FarManager fr = new FarManager(path);
            fr.Start();
        }
    }
}
