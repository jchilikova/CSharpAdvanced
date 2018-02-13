using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectResources
{
    class Program
    {
        static void Main(string[] args)
        {
            var fieldInput = Console.ReadLine().Split().ToArray();
            var number = int.Parse(Console.ReadLine());
            var maxResources = 0;
            var listResourcesTaken = new List<int>();
            var listResourcesTypes = new List<string>() {"stone", "gold", "food", "wood"};

            for (int i = 0; i < number; i++)
            {
                int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var currentResources = 0;

                var startIndex = indexes[0];
                var step = indexes[1];
                var index = startIndex;

                while (true)
                {
                    if (!listResourcesTaken.Contains(index))
                        listResourcesTaken.Add(index);
                    else
                        break;

                    var resource = fieldInput[index];
                    var resourceAmount = 0;
                    var type = "";

                    if (resource.Contains("_"))
                    {
                        var result = resource.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        type = result[0];
                        resourceAmount = int.Parse(result[1]);
                    }
                    else
                    {
                        type = resource;
                        resourceAmount = 1;
                    }

                    if (listResourcesTypes.Contains(type))
                    {
                        currentResources += resourceAmount;
                    }

                    index += step;

                    if (index >= fieldInput.Length)
                    {
                        index = index % fieldInput.Length;
                    }
                }

                if (currentResources > maxResources)
                {
                    maxResources = currentResources;
                }

                listResourcesTaken.Clear();
            }

            Console.WriteLine(maxResources);
        }
    }
}
