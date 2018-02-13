using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                var index = 0;

                string line = streamReader.ReadLine();

                while (line != null)
                {
                    if (index % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                   
                    line = streamReader.ReadLine();
                    index++;
                }
            }
        }
    }
}
