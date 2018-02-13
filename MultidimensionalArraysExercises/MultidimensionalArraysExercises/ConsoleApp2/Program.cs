namespace _10.The_Heigan_Dance
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int min = 0;
        private static int max = 14;
        private static int playerPositionRow = 7;
        private static int playerPositionCol = 7;

        public static void Main()
        {
            double dmgToHeigan = double.Parse(Console.ReadLine());

            var playerHealth = 18500;
            var heiganHealth = 3000000d;

            const int cloudDmg = 3500;
            const int eruptionDmg = 6000;

            var hasCloud = false;
            string causeOfDeath = "";

            while (true)
            {
                heiganHealth -= dmgToHeigan;

                if (hasCloud)
                {
                    playerHealth -= cloudDmg;
                    hasCloud = false;
                    causeOfDeath = "Plague Cloud";
                }

                string[] spell = Console.ReadLine().Split();
                string spellName = spell[0];
                var rowHit = int.Parse(spell[1]);
                var colHit = int.Parse(spell[2]);

                int[,] damageArea = GetDamageArea(rowHit, colHit);
            }




        }

        private static int[,] GetDamageArea(int rowHit, int colHit)
        {
            int[,] damageArea = new int[2,3];

            for (int i = rowHit -1; i < rowHit+1; i++)
            {
                damageArea[0,]
            }
        }

        private static bool isWall(int moveCell)
        {
            return moveCell < 0 || moveCell >= 15;
        }

        private static bool isInDamageArea(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                    && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
        }
    }
}