using System;
using System.Linq;

namespace CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToList();

            long max = 1;
          

            for (int steps = 1; steps < numbers.Count; steps++)
            {
                for (int numberIndex = 0; numberIndex < numbers.Count; numberIndex++)
                {
                    long currentMax = 1;
                    var currentNumberIndex = numberIndex;
                    var indexNextNumber = numberIndex + steps;

                    if (indexNextNumber > numbers.Count - 1)
                    {
                        indexNextNumber = (indexNextNumber - numbers.Count);
                    }

                    while (numbers[currentNumberIndex] < numbers[indexNextNumber])
                    {
                        currentMax++;

                        currentNumberIndex = indexNextNumber;
                        indexNextNumber = currentNumberIndex + steps;
                        if (indexNextNumber > numbers.Count - 1)
                        {
                            indexNextNumber = (indexNextNumber - numbers.Count);
                        }
                    }


                    if (currentMax > max)
                    {
                        max = currentMax;
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
