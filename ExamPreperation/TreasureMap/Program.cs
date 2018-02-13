using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"((?<hash>#)|!)[^!#]*?(?<![A-Za-z0-9])(?<street>[A-Za-z]{4})(?![A-Za-z0-9])[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?((?(hash)#)|!)";
            var number = int.Parse(Console.ReadLine());
            List<string> instructions = new List<string>();

            for (int i = 0; i < number; i++)
            {
                instructions.Add(Console.ReadLine());
            }

            foreach (var instruction in instructions)
            {
                MatchCollection matches = Regex.Matches(instruction, pattern);

                if (matches.Count == 0) continue;
                if (matches.Count == 1)
                {
                    var street = matches[0].Groups["street"].Value;
                    var numberStreet = matches[0].Groups["number"].Value;
                    var password = matches[0].Groups["password"].Value;
                    Console.WriteLine($"Go to str. {street} {numberStreet}. Secret pass: {password}.");
                }
                else if (matches.Count == 2)
                {
                    var street = matches[1].Groups["street"].Value;
                    var numberStreet = matches[1].Groups["number"].Value;
                    var password = matches[1].Groups["password"].Value;
                    Console.WriteLine($"Go to str. {street} {numberStreet}. Secret pass: {password}.");
                }
                else if (matches.Count % 2 == 1)
                {
                    int index = ((matches.Count - 1) / 2);
                    var street = matches[index].Groups["street"].Value;
                    var numberStreet = matches[index].Groups["number"].Value;
                    var password = matches[index].Groups["password"].Value;
                    Console.WriteLine($"Go to str. {street} {numberStreet}. Secret pass: {password}.");
                }
                else if (matches.Count % 2 == 0)
                {
                    int index = matches.Count /2 ;
                    var street = matches[index].Groups["street"].Value;
                    var numberStreet = matches[index].Groups["number"].Value;
                    var password = matches[index].Groups["password"].Value;
                    Console.WriteLine($"Go to str. {street} {numberStreet}. Secret pass: {password}.");
                }

            }


        }
    }
}
