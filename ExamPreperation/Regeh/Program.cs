using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";
            string input = Console.ReadLine();
            var list = new List<int>();
            MatchCollection match = Regex.Matches(input, pattern);
            if (match.Count == 0)
            {
                Console.WriteLine();
                return;
            }
            foreach (Match m in match)
            {
                list.Add(int.Parse(m.Groups[1].Value));
                list.Add(int.Parse(m.Groups[2].Value));
            }

            var index = 1;
            var currentSum = list.Take(index).Sum();
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                
                if (currentSum < input.Length)
                {
                    if (i == currentSum)
                    {
                        index++;
                        strBuilder.Append(input[i]);
                        currentSum = list.Take(index).Sum();
                        
                    }
                }
                else
                {
                    currentSum = currentSum - input.Length + 1;
                    i = currentSum;
                    strBuilder.Append(input[i]);

                }

            }



            Console.WriteLine(strBuilder);

        }
    }
}
