using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int [] days = new int[n];

            var indexPlants = new Stack<int>();
            indexPlants.Push(0);

            for (int i = 0; i < plants.Length; i++)
            {
                int maxDays = 0;
                while (indexPlants.Count > 0 && plants[indexPlants.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexPlants.Pop()]);
                }

                if (indexPlants.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                indexPlants.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
