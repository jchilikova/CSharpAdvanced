using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;

namespace JediDreams
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var result = FindMethods(number);
            PrintMethods(result);
        }

        private static Stack<Method> FindMethods(int number)
        {
            var methods = new Stack<Method>();
            var patternMethod = @"static\s+.*\s+([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
            var patternInvokedMethod = @"([a-zA-Z]*[A-Z][a-zA-Z]*)\s*\(";
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Trim();

                var matchMethod = Regex.Match(input, patternMethod);
                var matchListMethods = Regex.Matches(input, patternInvokedMethod);
                if (matchMethod.Success)
                {
                    methods.Push(new Method
                    {
                        Name = matchMethod.Groups[1].Value,
                        CalledMethods = new Queue<string>()
                    });
                }
                else
                {
                    foreach (Match match in matchListMethods)
                    {
                        methods.Peek().CalledMethods.Enqueue(match.Groups[1].Value);
                    }
                }
            }

            return methods;
        }

        private static void PrintMethods(Stack<Method> methods)
        {
            foreach (var item in methods.OrderByDescending(x => x.CalledMethods.Count).ThenBy(x => x.Name))
            {
                if (item.CalledMethods.Count == 0)
                {
                    Console.Write($"{item.Name} -> None");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write($"{item.Name} -> {item.CalledMethods.Count} -> ");
                    Console.WriteLine(string.Join(", ", item.CalledMethods.OrderBy(x => x)));
                }

            }
        }
    }

    public class Method
    {
        public string Name { get; set; }

        public Queue<string> CalledMethods { get; set; }
    }
}
