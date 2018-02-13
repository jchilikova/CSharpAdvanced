using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            var treasures = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            long currentCapacity = 0;
            long goldTotal = 0;
            long gemTotal = 0;
            long cashTotal = 0;

            var dictionary = new Dictionary<string, Dictionary<string, long>>();
            var dictionaryGold = new Dictionary<string, long>();

            dictionaryGold.Add("Gold", 0);

            for (int i = 0; i < treasures.Length; i = i + 2)
            {
                var currentTreasure = treasures[i];
                var amount = long.Parse(treasures[i + 1]);
                Regex matchGem = new Regex(@"(gem|Gem)");
                Regex matchCash = new Regex(@"(\w{3})");

                if (currentCapacity > capacity)
                {
                    break;
                }

                if (currentTreasure == "Gold")
                {
                    if (currentCapacity + amount <= capacity)
                    {
                        if (!dictionary.ContainsKey("Gold"))
                        {
                            dictionaryGold["Gold"] = amount;
                            dictionary.Add("Gold", dictionaryGold);
                        }
                        else
                        {
                            dictionary["Gold"]["Gold"] += amount;
                        }

                        currentCapacity += amount;
                        goldTotal += amount;
                    }
                }
                else if (currentTreasure.ToLower().EndsWith("gem") && currentTreasure.Length >= 4)
                {
                    if (currentCapacity + amount <= capacity)
                    {
                        if (gemTotal + amount > goldTotal) continue;

                        if (!dictionary.ContainsKey("Gem"))
                        {
                            dictionary.Add("Gem", new Dictionary<string, long>());
                            dictionary["Gem"].Add(currentTreasure, amount);
                        }
                        else
                        {
                            if (!dictionary["Gem"].ContainsKey(currentTreasure))
                            {
                                dictionary["Gem"].Add(currentTreasure, amount);
                            }
                            else
                            {
                                
                                dictionary["Gem"][currentTreasure] += amount;
                            }
                            
                        }

                        currentCapacity += amount;
                        gemTotal += amount;
                    }
                }
                else if (matchCash.IsMatch(currentTreasure))
                {
                    if (currentCapacity + amount <= capacity)
                    {
                        if (cashTotal + amount > gemTotal) continue;

                        if (!dictionary.ContainsKey("Cash"))
                        {
                            dictionary.Add("Cash", new Dictionary<string, long>());
                            dictionary["Cash"].Add(currentTreasure, amount);
                        }
                        else
                        {
                            if (!dictionary["Cash"].ContainsKey(currentTreasure))
                            {
                                dictionary["Cash"].Add(currentTreasure, amount);
                            }
                            else
                            {
                                dictionary["Cash"][currentTreasure] += amount;
                            }
                        }

                        currentCapacity += amount;
                        cashTotal += amount;
                    }
                }


            }

            foreach (var type in dictionary.OrderByDescending(x=> x.Value.Values.Sum()))
            {
                if (type.Key == "Gold")
                {
                    Console.WriteLine($"<{type.Key}> ${goldTotal}");
                }
                else if (type.Key == "Gem")
                {
                    Console.WriteLine($"<{type.Key}> ${gemTotal}");
                }
                else if (type.Key == "Cash")
                {
                    Console.WriteLine($"<{type.Key}> ${cashTotal}");
                }

                foreach (var item in type.Value.OrderByDescending(x=> x.Key).ThenBy(x=> x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }

        }
    }
}

