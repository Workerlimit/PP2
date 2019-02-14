using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "forTarget.txt";   // create a string with file's name
            string source = "/Users/Asem/source";   // create a string which specify a path of source folder
            string target = "/Users/Asem/source/target";   // create a string which specify a path of target folder

            string sourcefile = Path.Combine(source, name);    // use Path class to manipulate file and directory paths; create a string which combain a file name of the source folder
            string dest = Path.Combine(target, name);          // create a string which combain a file name of the target folder

            if (!Directory.Exists(target))                      // if a directory of the target folder does not exist, then 
            {
                Directory.CreateDirectory(target);             // creating a new directory 
            }

            File.Copy(sourcefile, dest);                       // copy the file from the source folder to the target folder 
            File.Delete(sourcefile);                           // after copying the file to the target file, delete this file in the source folder

            Console.ReadKey();                                 // hold on the console until any key is pressed  
        }
    }
}
