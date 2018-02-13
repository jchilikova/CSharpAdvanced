using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int number = int.Parse(Console.ReadLine());

            Func<IEnumerable<int>, IEnumerable<int>> func = ar => ar.Reverse().Where(x => !(x % number == 0));
            Console.WriteLine(string.Join(" ", func(arr)));
        }
    }
}
