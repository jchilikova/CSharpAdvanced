using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicArtillery
{
    class Program
    {
        private static Queue<char> bunkerQueue;
        private static Queue<int> weaponQueue;
        static void Main(string[] args)
        {
            var max = int.Parse(Console.ReadLine());
            var bunkerCapacity = max;
            var input = Console.ReadLine();
            bunkerQueue = new Queue<char>();
            weaponQueue = new Queue<int>();
            bool isWeaponContained = false;

            while (input != "Bunker Revision")
            {
                var line = input.Split().ToArray();
                int currentWeapon = 0;
                char bunker;
                foreach (var item in line)
                {
                    if (char.IsLetter(item[0]))
                    {
                        bunker = item[0];
                        bunkerQueue.Enqueue(bunker);
                    }
                    else if (int.TryParse(item, out currentWeapon))
                    {
                        while (bunkerQueue.Count > 1)
                        {
                            if (bunkerCapacity >= currentWeapon)
                            {
                                weaponQueue.Enqueue(currentWeapon);
                                bunkerCapacity -= currentWeapon;
                                isWeaponContained = true;
                                break;
                            }


                            if (weaponQueue.Count == 0)
                            {
                                Console.WriteLine($"{bunkerQueue.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.Write($"{bunkerQueue.Peek()} -> ");
                                Console.WriteLine(string.Join(", ", weaponQueue));
                            }

                            bunkerQueue.Dequeue();
                            weaponQueue.Clear();
                            bunkerCapacity = max;
                        }

                        if (!isWeaponContained && bunkerQueue.Count == 1)
                        {
                            if (max >= currentWeapon)
                            {
                                if (bunkerCapacity < currentWeapon)
                                {
                                    while (bunkerCapacity < currentWeapon)
                                    {
                                        var removedWeapon = weaponQueue.Dequeue();
                                        bunkerCapacity += removedWeapon;
                                    }
                                }
                                weaponQueue.Enqueue(currentWeapon);
                                bunkerCapacity -= currentWeapon;
                            }
                            

                        }

                    }
                }


                input = Console.ReadLine();
            }

         

        }

        private static void FillBunkerAndWeapons(string[] line)
        {
           
        }
    }

}
