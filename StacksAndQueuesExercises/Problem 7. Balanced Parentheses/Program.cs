using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            // { } ( ) [ ]
            var input = Console.ReadLine();
            bool isTrue = true;
            Stack<char> symbolsStack = new Stack<char>();

            foreach (var symb in input)
            {
                switch (symb)
                {
                    case '[':
                    case '(':
                    case '{':
                        symbolsStack.Push(symb);
                        break;

                    case ']':
                        if (!symbolsStack.Any())
                        {
                            isTrue = false;
                        }
                        else if (symbolsStack.Pop() != '[')
                        {
                            isTrue = false;
                        }

                        break;
                    case '}':
                        if (!symbolsStack.Any())
                        {
                            isTrue = false;
                        }
                        else if (symbolsStack.Pop() != '{')
                        {
                            isTrue = false;
                        }

                        break;

                    case ')':
                        if (!symbolsStack.Any())
                        {
                            isTrue = false;
                        }
                        else if (symbolsStack.Pop() != '(')
                        {
                            isTrue = false;
                        }

                        break;
                }
            }

            if (isTrue)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
