using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Action<string[]> action = arr => Console.WriteLine(string.Join("\n", arr));
            action(input);
        }
    }
}
