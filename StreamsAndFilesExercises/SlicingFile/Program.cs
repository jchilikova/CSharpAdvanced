﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
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
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4"
            };
            Slice(sourceFile, destination, parts);

            Assemble(files, destination);
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
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

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    using (var writer = new FileStream(currentPart, FileMode.Create))
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

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string asembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writer = new FileStream(asembledFile, FileMode.Create))
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
