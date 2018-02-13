using System;
using System.Linq;
using System.Linq.Expressions;

namespace TheHeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            double dmgToHeigan = double.Parse(Console.ReadLine());

            var playerHealth = 18500;
            var heiganHealth = 3000000d;
            
            var cloudDmg = 3500;
            var eruptionDmg = 6000;

            string lastSpell = "";
            string currentSpell = "";

            int playerPositionRow = 7;
            int playerPositionCol = 7;

            while (playerHealth> 0)
            {
                var hasMoved = false;

                heiganHealth -= dmgToHeigan;
                
                if (lastSpell == "Cloud")
                {
                    playerHealth -= cloudDmg;
                }

                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    break;
                }

                //new matrix
                string[,] battlefieldMatrix = new string[15, 15];
                battlefieldMatrix[playerPositionRow, playerPositionCol] = "p";

                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var spell = line[0];
                var row = int.Parse(line[1]);
                var col = int.Parse(line[2]);
                var isPlayerDamaged = false;
                currentSpell = spell;

                //damaged cells
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        try
                        {
                            if (battlefieldMatrix[i, j] == "p")
                            {
                                isPlayerDamaged = true;
                            }
                            else
                            {
                                battlefieldMatrix[i, j] = "dmg";
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
               
                //moving the player
                if (isPlayerDamaged)
                {
                    if (CheckIfCellIsInside(playerPositionRow - 1, playerPositionCol) &&
                        battlefieldMatrix[playerPositionRow - 1, playerPositionCol] != "dmg")
                    {
                        playerPositionRow--;
                        hasMoved = true;
                        continue;
                       
                    }
                    if (CheckIfCellIsInside(playerPositionRow, playerPositionCol + 1) &&
                        battlefieldMatrix[playerPositionRow, playerPositionCol + 1] != "dmg")
                    {
                        playerPositionCol++;
                        hasMoved = true;
                        continue;

                    }
                    if (CheckIfCellIsInside(playerPositionRow + 1, playerPositionCol) &&
                        battlefieldMatrix[playerPositionRow + 1, playerPositionCol] != "dmg")
                    {
                        playerPositionRow++;
                        hasMoved = true;
                        continue;

                    }
                    if (CheckIfCellIsInside(playerPositionRow, playerPositionCol - 1) &&
                        battlefieldMatrix[playerPositionRow, playerPositionCol - 1] != "dmg")
                    {
                        playerPositionCol--;
                        hasMoved = true;
                        continue;

                    }
                    //damaging the player
                    if (!hasMoved)
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerHealth -= cloudDmg;
                                lastSpell = spell;
                                break;
                            case "Eruption":
                                playerHealth -= eruptionDmg;
                                break;
                        }
                    }
                }
            }

            if (playerHealth <= 0 && heiganHealth > 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:f2}");
                if (currentSpell == "Cloud")
                {
                    Console.WriteLine("Player: Killed by Plague Cloud");
                }
                else
                {
                    Console.WriteLine("Player: Killed by Eruption");

                }

                Console.WriteLine($"Final position: {playerPositionRow}, {playerPositionCol}");
            }

            else if (heiganHealth <= 0 && playerHealth >0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine("Player: " + playerHealth);
                Console.WriteLine($"Final position: {playerPositionRow}, {playerPositionCol}");
            }

            else if (heiganHealth <= 0 && playerHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if (currentSpell == "Cloud")
                {
                    Console.WriteLine("Player: Killed by Plague Cloud");
                }
                else
                {
                    Console.WriteLine("Player: Killed by Eruption");

                }

                Console.WriteLine($"Final position: {playerPositionRow}, {playerPositionCol}");
            }

        }
        private static bool CheckIfCellIsInside(int escapeRow, int escapeCol)
        {
            int rowCount = 15;
            int colCount = 15;
            if (escapeRow < 0 || escapeRow >= rowCount ||
                escapeCol < 0 || escapeCol >= colCount)
            {
                return false;
            }

            return true;
        }
    }
}