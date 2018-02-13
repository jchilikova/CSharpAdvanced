using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}).Select(int.Parse).ToArray();

            Func<int[], int> minValue = numbers => numbers.Min();
            Console.WriteLine(minValue(input));
        }
    }
}
