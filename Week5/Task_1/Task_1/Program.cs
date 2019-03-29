using System;
using System.IO;
using System.Xml.Serialization;

namespace Task__
{
    public class Complex
    {
        public int a, b;

        public Complex() { }

        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override string ToString()
        {
            return a + " + " + b + "i";
        }
        public void Serialization(Complex a)
        {
            FileStream fs = new FileStream("serializationw5.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, a);
            fs.Close();
        }
        public Complex Des()
        {
            FileStream fs = new FileStream("serializationw5.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex C = xs.Deserialize(fs) as Complex;
            fs.Close();
            return C;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = new Complex(3, 4);
            complex.Serialization(complex);
            Complex a = complex.Des();
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

