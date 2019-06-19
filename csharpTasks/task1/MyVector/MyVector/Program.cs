using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(1, 2);
            Vector b = new Vector(3, 4);

            a.Add(b);

            Console.WriteLine(a.ToString());
            Console.ReadKey();

        }
    }
}
