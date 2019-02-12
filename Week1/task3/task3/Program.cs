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
            bool isInt = int.TryParse(Console.ReadLine(), out n); // check the array size is integer or not, if yes, assign to variable 'n'

            if(!isInt)                    // if the line from console is not integer, then quit the program
            {
                return;
            }

            string[] a = Console.ReadLine().Split();  // 1. read the line from console, 2. create an array from the input line by splitting by space

            string[] answ = new string[n * 2];        // create a new array of strings, which length more 2 times than the first array
            
            for(int i = 0; i < n; i++)      // go through the array
            {
                answ[2 * i] = answ [2 * i + 1] = a[i];   // answ[0] = answ[1] = a[0]
            }
            
            foreach(string i in answ)    // use a cycle 'foreach'
            {
                Console.Write(i + " ");   // output array's element with space(" ")
            }
            Console.ReadKey(); // hold on the console until any key is pressed
        }
    }
}
