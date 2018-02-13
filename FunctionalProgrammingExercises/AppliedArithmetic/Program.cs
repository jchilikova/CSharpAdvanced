using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var input = Console.ReadLine().ToLower().Trim();

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = ForEach(numbers, n => n + 1);
                        break;
                    case "multiply":
                        numbers = ForEach(numbers, n => n * 1);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, n => n - 1);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
                input = Console.ReadLine().ToLower().Trim();
            }


        }
        public static IEnumerable<int> ForEach(IEnumerable<int> collection, Func<int, int> func)
        {
            return collection.Select(n => func(n));
        }
    }

}
