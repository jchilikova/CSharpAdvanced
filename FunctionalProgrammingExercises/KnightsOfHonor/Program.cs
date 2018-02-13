using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var sir = "Sir ";
            Action<string[]> action = arr => Console.WriteLine(string.Join(Environment.NewLine, arr.Select(x => sir + x)));
            action(input);
        }
    }
}
