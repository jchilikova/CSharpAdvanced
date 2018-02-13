using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(number);

            int elementIndex = 0;


          

            for (int i = 0; i < 49; i++)
            {
                if (i % 3 == 0)
                {
                    queue.Enqueue(queue.ElementAt(elementIndex) + 1);
                    
                }
                else if (i % 3 == 1)
                {
                    queue.Enqueue(2* queue.ElementAt(elementIndex) + 1);
                }
                else if (i % 3 == 2)
                {
                    queue.Enqueue(queue.ElementAt(elementIndex) + 2);
                    elementIndex++;
                }

                
            }

            Console.WriteLine(String.Join(" ", queue));
        }
    }
}
