using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JediCode_X
{
    class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            StringBuilder lines = new StringBuilder();
            var listJedi = new List<string>();
            var listMsg = new List<string>();
            var result = new List<string>();

            for (int i = 0; i < number; i++)
            {
                lines.Append(Console.ReadLine().Trim());
            }

            var pattern1 = Console.ReadLine();
            var pattern2 = Console.ReadLine();
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var patternOneLenght = pattern1.Length;
            var patternTwoLength = pattern2.Length;

            var patternNameLn = $@"{pattern1}([a-zA-z]{{{patternOneLenght}}})(?![a-zA-Z])";
            var patternMsgLn = $@"{pattern2}([a-zA-Z0-9]{{{patternTwoLength}}})(?![a-zA-Z0-9])";

            MatchCollection firstMatches = Regex.Matches(lines.ToString(), patternNameLn);
            MatchCollection secondMatches = Regex.Matches(lines.ToString(), patternMsgLn);

            foreach (Match match in firstMatches)
            {
                listJedi.Add(match.Groups[1].Value);
            }

            foreach (Match match in secondMatches)
            {
                listMsg.Add(match.Groups[1].Value);
            }
            var count = 0;

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] - 1 < listMsg.Count)
                {
                    result.Add($"{listJedi[count++]} - {listMsg[indexes[i] - 1]}");
                }

                if (count >= listJedi.Count) break;
            }
            Console.WriteLine(string.Join("\n", result));
        }

    }
}

