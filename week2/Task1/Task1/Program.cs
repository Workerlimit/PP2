using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool isPalin(string text)   // create a boolean method  
        {
            if (text != "" || text != null)      // if a text from a file doesn't empty, then
            {
                for (int i = 0; i < text.Length / 2; i++)  // go through the half of text
                {
                    if (text[i] != text[text.Length - i - 1])   // check to palindrom
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;    // if the text is null or empty
        }

        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:/programs/files/task1.txt"); // create a string which read all text from the file 

            if (isPalin(text))           // if the text is palindrom
            {
                Console.WriteLine("Yes");   // output "yes"
            }
            else                         // else the text is not palindrom
            {
                Console.WriteLine("No");     // output "no"
            }

            Console.ReadKey();       // hold on the console until any key is pressed
        }
    }
}
