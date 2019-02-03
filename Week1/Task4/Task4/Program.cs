using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;                                   // input an array size
            bool isInt = int.TryParse(Console.ReadLine(), out n);   // check the line from console is integer or not, if yes, assign to variable 'n'

            string[,] arr = new string[n, n];  // create a 2d array
            for (int i = 0; i < n; i++)    // go through array with a cycle
            {
                for (int j = 0; j <= i; j++)  // array's second dimension
                {
                    arr[i, j] = "[*]";      // assign to '[*]'  array's elements
                    Console.Write(arr[i, j]);    // output the array's elements
                }
                Console.Write("\n");     // go to the new line
            }
            Console.ReadKey();    // hold on the console until any key is pressed
        }
    }
}
