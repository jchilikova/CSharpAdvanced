using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                using (var streamWriter = new StreamWriter("output.txt"))
                {
                    var lineNumber = 1;
                    string line = streamReader.ReadLine();

                    while (line != null)
                    {

                        streamWriter.WriteLine($"Line: {lineNumber}: {line}");
                        line = streamReader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
//HTTP/1.1 200 OK\nContent-Type:text\n\n