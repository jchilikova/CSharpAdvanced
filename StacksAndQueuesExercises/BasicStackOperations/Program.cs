using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Trim().Split().ToArray();

            int n = int.Parse(numbers[0]);
            int s = int.Parse(numbers[1]);
            int x = int.Parse(numbers[2]);

            var stackInput = Console.ReadLine().Trim().Split().ToArray();

            var stackNumbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stackNumbers.Push(int.Parse(stackInput[i]));                
            }

            for (int i = 0; i < s; i++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stackNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stackNumbers.Min());
            }

        }
    }
}
