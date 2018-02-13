using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue= new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pump);

            }

            for (int i = 0; i < n - 1; i++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int j = 0; j < n; j++)
                {
                    var currentPump = queue.Dequeue();
                    queue.Enqueue(currentPump);
                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];
                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        i += j;
                        isSolution = false;
                        break;

                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(i);
                    Environment.Exit(0);
                }

            }

            

        }
    }
}
