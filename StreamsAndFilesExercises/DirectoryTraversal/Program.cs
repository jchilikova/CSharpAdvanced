using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);
            var dictionaryFiles = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extention = fileInfo.Extension;
              //  long size = fileInfo.Length;

                if (!dictionaryFiles.ContainsKey(extention))
                {
                    dictionaryFiles[extention] = new List<FileInfo>();
                }

                dictionaryFiles[extention].Add(fileInfo);
            }

            dictionaryFiles = dictionaryFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x=> x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in dictionaryFiles)
                {
                    string extention = pair.Key;
                    writer.WriteLine(extention);
                    var fileInfos = pair.Value.OrderByDescending(fi => fi.Length);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:F3}kb");
                    }


                }
            }
        }
    }
}
