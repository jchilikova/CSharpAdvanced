using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueuesExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Trim().Split().ToArray();

            var stackNumbers = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stackNumbers.Push(int.Parse(numbers[i]));
            }

            int stackCount = stackNumbers.Count;
            for (int i = 0; i < stackCount; i++)
            {
                int currentNumber = stackNumbers.Pop();
                Console.Write(currentNumber + " ");

            }
            Console.WriteLine();
        }
    }
}
