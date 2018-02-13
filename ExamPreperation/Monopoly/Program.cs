using System;
using System.Data;
using System.Linq;

namespace Monopoly
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static char[,] matrix;
        static int totalMoney;
        static int totalHotels;
        private static bool inJail;
        private static int turns;


        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            totalMoney = 50;
            totalHotels = 0;
            inJail = false;

            rows = dimensions[0];
            cols = dimensions[1];

            matrix = FillMatrix();

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        CheckWhereIsPlayer(row, col);
                        totalMoney += totalHotels * 10;
                        turns++;
                    }
                }
                else if (row % 2 == 1)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        CheckWhereIsPlayer(row, col);
                        totalMoney += totalHotels * 10;
                        turns++;
                    }
                }

            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {totalMoney}");
        }

        public static void CheckWhereIsPlayer(int row, int col)
        {
            switch (matrix[row, col])
            {
                case 'H':
                    totalHotels++;
                    Console.WriteLine($"Bought a hotel for {totalMoney}. Total hotels: {totalHotels}.");
                    totalMoney = 0;
                    break;
                case 'J':
                    inJail = true;
                    Console.WriteLine($"Gone to jail at turn {turns}.");
                    turns += 2;
                    totalMoney += 2 * (totalHotels * 10);
                    break;
                case 'S':
                    var hasToSpend = Math.Min((row + 1) * (col + 1), totalMoney);
                    totalMoney -= hasToSpend;
                    Console.WriteLine($"Spent {hasToSpend} money at the shop.");
                    break;
            }
        }

        public static char[,] FillMatrix()
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }
    }
}
