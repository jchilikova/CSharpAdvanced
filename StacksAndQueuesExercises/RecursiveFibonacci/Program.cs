using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFibonacci
{
    class Program
    {
        private static long[] fibNumbers;

        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            fibNumbers = new long[n];
            var result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        private static long GetFibonacci(long number)
        {
            if (number <= 2)
            {
                return 1;
            }

            if (fibNumbers[number- 1] != 0)
            {
                return fibNumbers[number - 1];
            }
             return fibNumbers[number - 1]  = GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
