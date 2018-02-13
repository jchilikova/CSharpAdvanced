using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToArray();

            var rowsInput = line[0];
            var colsInput = line[1];

            long[,] matrix = new long[rowsInput, colsInput];

            for (int row = 0; row < rowsInput; row++)
            {
                var matrixInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                for (int cols = 0; cols < colsInput; cols++)
                {
                    matrix[row, cols] = matrixInput[cols];
                }
            }

            var listMaxSum = new List<long>();
            long maxSum = int.MinValue;
            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    var listElements = new List<long>();
                    listElements.Add(matrix[rows, cols]);
                    listElements.Add(matrix[rows, cols + 1]);
                    listElements.Add(matrix[rows, cols + 2]);
                    listElements.Add(matrix[rows + 1, cols]);
                    listElements.Add(matrix[rows + 1, cols + 1]);
                    listElements.Add(matrix[rows + 1, cols + 2]);
                    listElements.Add(matrix[rows + 2, cols]);
                    listElements.Add(matrix[rows + 2, cols + 1]);
                    listElements.Add(matrix[rows + 2, cols + 2]);

                    long currentSum = listElements.Sum();

                    if (currentSum > maxSum)
                    {
                        listMaxSum.Clear();
                        maxSum = currentSum;
                        listMaxSum = listElements;

                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int i = 0; i < 9; i=i+3)
            {
                Console.WriteLine($"{listMaxSum[i]} {listMaxSum[i+1]} {listMaxSum[i+2]}");
            }
        }
    }
}
