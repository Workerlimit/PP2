using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText("/programs/files/input.txt");   // create a string from file
            string[] arr = s.Split();          // create a new string array, which splitting by space(" ") 
            bool isPrime = true;             // bool variable to check if a number is prime or not
            string primes = string.Empty;    // create an empty array, which will contain prime numbers

            for (int i = 0; i < arr.Length; i++)    // go through input array
            {
                int x;   // current input array's element variable
                bool isInt = int.TryParse(arr[i], out x);    // first, check if current array element is integer or not, if yes, assign it to variable 'x'

                for (int j = 2; j <= Math.Sqrt(x); j++)    //start from 2, because the prime number divide to 1 and itself
                {
                    if (x % j == 0)      // if 'x' divided by 'j' without remainder, then 'x' is not a prime number
                    {
                        isPrime = false;    // so, 'x' is not prime
                        break;              // quit the inner cycle
                    }
                    else
                    {
                        isPrime = true;            // if 'x' divided by 'j' with remainder, then 'x' is a prime number
                    }
                }

                if (isPrime)           // if 'x' is a prime, then add to an array, which firstly was an empty 
                {
                    primes = primes + x + " ";         // add an integer prime numbers with space(" ") 
                }
            }
            File.WriteAllText("/programs/files/prime.txt", primes);    // create a new file with an array of the prime numbers
        }
    }
}
