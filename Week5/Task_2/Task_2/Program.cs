using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(93);
            Point p2 = new Point(75);
            Point p3 = new Point(64);

            List<Point> list = new List<Point>() { p1, p2, p3 };
            Point.Serialize(list);
            List<Point> list2 = Point.Deserialize();

            foreach(Point point in list2)
            {
                Console.WriteLine(point);
            }
            Console.ReadKey();
        }
    }
}
