using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            bool isYoda = false;
            StringBuilder masters = new StringBuilder();
            StringBuilder knights = new StringBuilder();
            StringBuilder padawans = new StringBuilder();
            StringBuilder toshkoSlav = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split().ToList();

                foreach (var jedi in input)
                {

                    switch (jedi[0])
                    {
                        case 'm':
                            masters.Append($"{jedi} ");
                            break;
                        case 'k':
                            knights.Append($"{jedi} ");
                            break;
                        case 'p':
                            padawans.Append($"{jedi} ");
                            break;
                        case 't':
                            toshkoSlav.Append($"{jedi} ");
                            break;
                        case 's':
                            toshkoSlav.Append($"{jedi} ");
                            break;
                        case 'y':
                            isYoda = true;
                            break;

                    }
                }
            }

            Console.WriteLine(isYoda
                ? masters.Append(knights).Append(toshkoSlav).Append(padawans)
                : toshkoSlav.Append(masters).Append(knights).Append(padawans));
        }
    }
}
