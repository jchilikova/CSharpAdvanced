using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Stack<int> stackElements = new Stack<int>();
            Stack<int> maxElementStack = new Stack<int>();

            maxElementStack.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        var element = command[1];
                        stackElements.Push(element);

                        if (element >= maxElementStack.Peek() )
                        {
                            maxElementStack.Push(element);
                        }
                        break;

                    case 2:
                        var poppedElement = stackElements.Pop();
                        if (maxElementStack.Peek() == poppedElement)
                        {
                            maxElementStack.Pop();
                        }
                        break;

                    case 3:
                        int maxElement = maxElementStack.Peek();
                        Console.WriteLine(maxElement);
                        break;
                }
            }

        }
    }
}
