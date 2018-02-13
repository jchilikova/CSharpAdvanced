using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var beginNumber = input[0];
            var endNumber = input[1];
            var type = Console.ReadLine().ToLower();
            Predicate<int> isOddOrEven;
            var listNumbers = new List<int>();

            switch (type)
            {
                case "odd":
                    isOddOrEven = n => n % 2 != 0;
                    break;
                case "even":
                    isOddOrEven = n => n % 2 == 0;
                    break;
                    default:
                        isOddOrEven = null;
                       break;

            }

            for (int i = beginNumber; i <= endNumber; i++)
            {

                if (isOddOrEven(i))
                {
                    listNumbers.Add(i);
                }

            }

            Console.WriteLine(string.Join(" ", listNumbers));
        }
    }
}
