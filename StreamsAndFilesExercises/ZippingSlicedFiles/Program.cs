using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ZippingSlicedFiles
{



    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "video.mp4";
            string destination = "";
            int parts = 5;
            var files = new List<string>
            {
                "Part-0.mp4.gz",
                "Part-1.mp4.gz",
                "Part-2.mp4.gz",
                "Part-3.mp4.gz",
                "Part-4.mp4.gz"
            };
            Zip(sourceFile, destination, parts);

            Unzip(files, destination);
        }

        public static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";



                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create),
                        CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void Unzip(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].IndexOf('.') + 1, 3);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string asembledFile = $"{destinationDirectory}AssembledZip.{extension}.gz";

            using (GZipStream writer =
                new GZipStream(new FileStream(asembledFile, FileMode.Create), CompressionLevel.Optimal))
            {
                byte[] buffer = new byte[bufferSize];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }

        }
    }
}
