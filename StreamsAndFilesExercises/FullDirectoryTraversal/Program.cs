using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);

            List<FileInfo> filesList = filePaths.Select(path => new FileInfo(path)).ToList();
            var sortedList =
                filesList.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key).ToList();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            using (StreamWriter writer = new StreamWriter(desktopPath + "/report.txt"))
            {
                foreach (var group in sortedList)
                {
                    writer.WriteLine(group.Key);

                    foreach (var y in group)
                    {
                        writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
                    }
                }
            }

        }
    }
}
