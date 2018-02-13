using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var pattern = @"^#(?<name>[A-Za-z]+):\s*@(?<city>[A-Za-z]+)\s*(?<hour>([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9])$";
            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    continue;
                }
                var city = match.Groups["city"].Value;
                var name = match.Groups["name"].Value;
                var hour = match.Groups["hour"].Value;

                if (!dictionary.ContainsKey(city))
                {
                    dictionary.Add(city, new Dictionary<string, List<string>>());
                    if (!dictionary[city].ContainsKey(name))
                    {
                        dictionary[city].Add(name, new List<string>());
                        dictionary[city][name].Add(hour);
                    }
                    else
                    {
                        dictionary[city][name].Add(hour);
                    }
                }
                else
                {
                    if (!dictionary[city].ContainsKey(name))
                    {
                        dictionary[city].Add(name, new List<string>());
                        dictionary[city][name].Add(hour);
                    }
                    else
                    {
                        dictionary[city][name].Add(hour);
                    }
                }
            }

            var citiesWanted = Console.ReadLine().Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x).ToArray();
            
            foreach (var city in citiesWanted)
            {
                foreach (var item in dictionary.OrderBy(x => x.Key))
                {
                    var index = 1;
                    if (item.Key == city)
                    {
                        Console.WriteLine(city+":");
                        foreach (var name in item.Value.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{index}. {name.Key} -> {string.Join(", ", name.Value.OrderBy(x => x))}");
                            index++;
                        }
                    }

                    
                }
            }
            
        }
    }
}
