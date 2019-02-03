using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;   // input array size variable
            bool isInt = int.TryParse(Console.ReadLine(), out n); // 1. read line from console; 2. check if the array size is integer or not, if yes, assign to variable 'n'

            if (!isInt)
            {
                return;                        // if the line from console is not integer number, then we quit the program
            }

            string[] a = Console.ReadLine().Split();        // 1. read next line from console which contains array elements; 2. create an array from the input line by splitting by space

            int[] res = new int[n];       // create an array, which will contain the prime numbers  
            int resCnt = 0;              // a number of the prime numbers

            for (int i = 0; i < n; i++)    // go through input array
            {
                int x;   // current input array's element variable
                isInt = int.TryParse(a[i], out x);    // first, check if current array element is integer or not, if yes, assign it to variable 'x'

                if (isInt && x > 1)                  // if current array element is integer and 'x' is greater than 1, because "1" is not the prime number  
                {
                    bool isPrime = true;              // bool variable to check if 'x' is prime or not
                    for (int j = 2; j <= Math.Sqrt(x); j++)    //start from 2, because the prime number divide to 1 and itself
                    {
                        if (x % j == 0)      // if 'x' divided by 'j' without remainder, then 'x' is not a prime number
                        {
                            isPrime = false;    // so, 'x' is not prime
                            break;              // quit the inner cycle
                        }
                    }

                    if (isPrime)               // if x is a prime number,
                    {
                        res[resCnt++] = x;      // then add x to our resulting array, and increase found prime numbers count
                    }
                }
            }

            if (resCnt > 0)                  // if there are any prime numbers found
            {
                Console.WriteLine(resCnt);   // output the number of prime numbers 
                for (int i = 0; i < resCnt; i++)   // with cycle output the elements of this array 
                {
                    Console.Write(res[i]);
                    if (i < resCnt - 1)           // do not print ' ' (space) after the last array element
                    {
                        Console.Write(' ');
                    }
                }
            }

            Console.ReadKey();             // hold on the console until any key is pressed
            }
        }
}