using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> act = str => Console.WriteLine(string.Join("\n", names.Where(x => x.Length <= number)));
            act(names);
        }


    }
}
