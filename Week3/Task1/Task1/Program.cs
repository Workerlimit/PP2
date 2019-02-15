using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class FarManager       // create a new class 
    {

        public int cursor;   // cursor
        public int size;     // size of files and folders in the path
        public string path;  // path to our folder
        public bool ok;      // boolean ok
        DirectoryInfo direct = null;   // a null directory
        FileSystemInfo currentFile = null; // a null current file

        public FarManager()  // create a constructor
        {
            cursor = 0;
        }

        public FarManager(string path)     // create second constructor
        {
            this.path = path;
            cursor = 0;
            direct = new DirectoryInfo(path);
            size = direct.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Color(FileSystemInfo files, int index)    // a method Color
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;       // color will be cyan, if the current cursor on the file or folder
                Console.ForegroundColor = ConsoleColor.Magenta;
                currentFile = files;
            }
            else if (files.GetType() == typeof(DirectoryInfo))   // the folder's color is green 
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;    // the file's color is green
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;    // console's color is black
            Console.Clear();                                 // clear console
            direct = new DirectoryInfo(path);
            FileSystemInfo[] files = direct.GetFileSystemInfos();   // create an array of files and folders

            for (int i = 0, k = 0; i < files.Length; i++)    // go through the array with a cycle
            {
                if (ok == false && files[i].Name[0] == ' ')    // if the file is hidden, 
                { 
                    continue;                                   // we will ignore it  
                }
                Color(files[i], k);
                int count = i + 1;
                Console.WriteLine(count + ". " + files[i].Name);
                k++;
            }
        }

        public void Up()       // create a method up 
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
            while (conKey.Key != ConsoleKey.Escape)     // if enter is pressed, quit the program
            {
                CalcSize();
                Show();
                conKey = Console.ReadKey();
                switch (conKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Up();
                        break;

                    case ConsoleKey.DownArrow:
                        Down();
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

        class Program
        {
            static void Main(string[] args)
            {
                string path = "/programs/FarManager";   // create a string which keep a path
                FarManager fr = new FarManager(path);    //  give the path to the class FarManager
                fr.Start();                            // call a method
            }
        }
    }
}
