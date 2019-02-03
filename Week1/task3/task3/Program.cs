using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;             // input array size variable
            bool isInt = int.TryParse(Console.ReadLine(), out n);   // check the array size is integer or not, if yes, assign to variable 'n'

            if(!isInt)                            // if the line from console is not integer, then quit the program
            {
                return;
            }

            string[] a = Console.ReadLine().Split();      // 1. read the line from console, 2. create an array from the input line by splitting by space

            for (int i = 0; i < n; i++)              // go through the array
            {  
                int x;                               // current input array's element
                isInt = int.TryParse(a[i], out x);    // check the array's element is integer or not, if yes, assign to variable 'x'

                if (isInt)                           // if cuurent element is integer, then
                {
                    for (int j = 0; j < 2; j++)        // with cycle output the array's elements
                    {
                        Console.Write(a[i] + " ");     // output " "(space) after every array's element
                    }
                }
            }
            Console.ReadKey(); // hold on the console until any key is pressed
        }
    }
}
