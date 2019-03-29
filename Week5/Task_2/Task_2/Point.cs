using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task_2
{
    public class Point
    {
        public int point;
        public Point() { }

        public Point(int point)
        {
            this.point = point;
        }

        public string Letter()
        {
            if (point >= 95 && point <= 100)
            {
                return "A";
            }
            if (point >= 90 && point <= 94)
            {
                return "A-";
            }
            if (point >= 85 && point <= 89)
            {
                return "B+";
            }
            if (point >= 80 && point <= 84)
            {
                return "B";
            }
            if (point >= 75 && point <= 79)
            {
                return "B-";
            }
            if (point >= 70 && point <= 74)
            {
                return "C+";
            }
            if (point >= 65 && point <= 69)
            {
                return "C";
            }
            if (point >= 60 && point <= 64)
            {
                return "C-";
            }
            if (point >= 55 && point <= 59)
            {
                return "D+";
            }
            if (point >= 50 && point <= 54)
            { 
                return "D";
            }
            return "F";
        }

        public override string ToString()
        {
            return "The point is " + point + " The letter is " + Letter();
        }

        public static void Serialize(List<Point> m)
        {
            FileStream fs = new FileStream("FileForSerial.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Point>));
            xs.Serialize(fs, m);
            fs.Close();
        }

        public static List<Point> Deserialize()
        {
            FileStream fs = new FileStream("FileForSerial.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Point>));
            List<Point> p = xs.Deserialize(fs) as List<Point>;
            return p;
            fs.Close();
        }
    }
}
