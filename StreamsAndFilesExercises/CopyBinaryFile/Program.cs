using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sourceFile = new FileStream("pic.png", FileMode.Open))
            {
                using (var destinationFile = new FileStream("pic-copy.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var byteCount = sourceFile.Read(buffer, 0, buffer.Length);

                        if (byteCount == 0)
                        {
                            break;
                        }
                        else
                        {
                            destinationFile.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
