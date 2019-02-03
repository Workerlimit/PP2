using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string id;
        public string name;
        public int year;

        public Student(string id, string name)   // create a constructor with two parametres
        {
            this.id = id;                        // use "this", because name of parametre and string are same
            this.name = name;
        }
        void incYear()                           // increment year
        {
            this.year++;
        }

        public string getId()               // create a method which return the id
        {
            return this.id;
        }

        public string getName()            // create a method which return the name
        {
            return this.name;
        }

        public int getYear()               // create a method which return the year
        {
            return this.year;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student("18BD110337", "Alice");      // assign id and name to student
            st.year = 1;                                          // student's year is start from '1'
            Console.WriteLine(st.getId() + " " + st.getName() + " " + st.getYear());       // output to the console student's info
            Console.ReadKey();                 // hold on the console until any key is pressed
        }
    }
}