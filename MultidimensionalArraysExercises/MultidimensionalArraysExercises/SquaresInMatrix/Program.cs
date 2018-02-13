using System;
using System.Linq;

namespace SquaresInMatrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var rowsInput = line[0];
            var colsInput = line[1];

            string[,] matrix = new string[rowsInput, colsInput];

            for (int row = 0; row < rowsInput; row++)
            {
                var matrixInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int cols = 0; cols < colsInput; cols++)
                {
                    matrix[row, cols] = matrixInput[cols];
                }
            }

            int counter = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var oneOne = matrix[rows, cols];
                    var oneTwo = matrix[rows, cols + 1];
                    var twoOne = matrix[rows + 1, cols];
                    var twoTwo = matrix[rows + 1, cols + 1];

                    if (oneTwo == oneOne && oneTwo == twoTwo && oneTwo == twoOne)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
