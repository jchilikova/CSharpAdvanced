using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();

            var stackString = new Stack<string>();
            stackString.Push("");

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        stackString.Push(builder.ToString());
                        builder.Append(input[1]);
                        break;

                    case 2:
                        stackString.Push(builder.ToString());
                        int length = int.Parse(input[1]);
                        int startIndex = builder.Length - length;
                        
                        builder.Remove(startIndex, length);
                        break;

                    case 3:
                        var element = builder.ToString().ElementAt(int.Parse(input[1]) - 1);
                        Console.WriteLine(element);
                        break;

                    case 4:
                        builder.Clear();
                        builder.Append(stackString.Pop());
                        break;
                }
            }
        }
    }
}
