using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            using (var streamReader = new StreamReader("words.txt"))
            {
                using (var streamWriter = new StreamWriter("result.txt"))
                {
                    int index = 1;
                    using (var streamReaderText = new StreamReader("text.txt"))
                    {
                        string[] text = streamReaderText.ReadToEnd().Split(new char[] { ' ', ',', '.', '-', '\r', '\n', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
                        string word = streamReader.ReadLine();

                        while (word != null)
                        {
                            foreach (var wordsInText in text)
                            {

                                if (wordsInText.ToLower() == word)
                                {
                                    if (!dict.ContainsKey(word))
                                    {
                                        dict.Add(word, index);
                                    }
                                    else
                                    {
                                        index++;
                                        dict[word] = index;
                                    }
                                }
                                

                            }

                            index = 1;
                            word = streamReader.ReadLine();
                        }

                        foreach (var item in dict.OrderByDescending(x=> x.Value))
                        {
                            streamWriter.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                }



            }
        }
    }
}
//string line = streamReader.ReadLine();
//
//while (line != null)
//{
//
//                        
//line = streamReader.ReadLine();
//}