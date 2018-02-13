using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            int[] queueElements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueInput = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queueInput.Enqueue(queueElements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queueInput.Dequeue();
            }

            if (queueInput.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (queueInput.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queueInput.Min());
            }


        }
    }
}
