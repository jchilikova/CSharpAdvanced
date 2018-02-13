using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[,] matrix = new int[number,number];

            for (int row = 0; row < number; row++)
            {
                var line = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                for (int cols = 0; cols < number; cols++)
                {
                    matrix[row, cols] = line[cols];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            int secondaryRows = 0;
            int secondaryCols = matrix.GetLength(1) - 1;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (rows == cols)
                    {
                        sumPrimaryDiagonal += matrix[rows, cols];
                    }

                    if (rows == secondaryRows && cols == secondaryCols)
                    {
                        sumSecondaryDiagonal += matrix[rows, cols];
                        secondaryRows++;
                        secondaryCols--;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));
        }
    }
}
