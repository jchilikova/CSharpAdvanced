using System;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Action<string[]> action = arr => Console.WriteLine(string.Join(Environment.NewLine, arr));
            action(input);
        }
    }
}
