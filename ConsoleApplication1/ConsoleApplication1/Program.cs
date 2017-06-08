using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var fac = Factorial(10000000);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static double Factorial(double value)
        {
            for (var i = 0; i < value; i++)
            {
                var arr = new object[100];
                var a = value * value;
            }

            return 1;
        }


    }
}
