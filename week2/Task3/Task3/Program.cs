using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static void PrintSp(int lvl)               // create a function which will print a space(" ") on every step
        {
            for (int i = 0; i < lvl; i++)          // use a cycle 'for', that print the space(" ")
            {
                Console.Write(" ");
            }
        }

        static void Direction(DirectoryInfo d, int lvl)     // create a function which will return a directory
        {
            FileInfo[] ff = d.GetFiles();                   // create an array of files

            foreach (FileInfo file in ff)                    // use a cycle 'foreach' that go through all files 
            {
                PrintSp(lvl);                               // firstly, print the space(" ")

                Console.WriteLine(file.Name);               // then, output a file name
            }

            DirectoryInfo[] directories = d.GetDirectories();    // create an array of directories

            foreach (DirectoryInfo dir in directories)           // use a cycle 'foreach'
            {
                PrintSp(lvl);                                   // print the space(" ")

                Console.WriteLine(dir.Name);                    // output a name of directory

                Direction(dir, lvl + 1);                        // call the next time a function with lvl+1 
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo pth = new DirectoryInfo("/Program Files/WindowsPowerShell");    // create directory with path 
            Direction(pth, 0);                                         // call a function with level (lvl = 0)

            Console.ReadKey();                                         // hold on a console until any key is pressed
        }
    }
}
