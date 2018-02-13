using System;
using System.Collections.Generic;
using System.Linq;

namespace StringMatrixRotation
{
    class Program
    {
        private static char[,] result;
        static void Main(string[] args)
        {
            var rotation = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var deg = int.Parse(rotation[1]) % 360;
            var list = new List<string>();
            var maxValue = 0;

            var input = Console.ReadLine();
            while (input != "END")
            {
                list.Add(input);

                if (maxValue < input.Length)
                {
                    maxValue = input.Length;
                }

                input = Console.ReadLine();
            }

            char[,] matrix = new char[list.Count, maxValue];
            var counter = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var word = list[counter];
                var length = word.Length;
                var index = 0;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (index == length)
                    {
                        while (index < maxValue)
                        {
                            matrix[row, col] = ' ';
                            index++;
                            col++;
                        }

                        index = 0;
                        break;

                    }
                    else
                    {
                        matrix[row, col] = word[index];
                        index++;
                    }
                }
                counter++;
                index = 0;
            }




            switch (deg)
            {
                case 90:
                    result = Calculate90Degrees(matrix);
                    break;
                case 180:
                    result = Calculate180Degrees(matrix);
                    break;
                case 270:
                    result = Calculate240Degrees(matrix);
                   
                    break;
                case 360:
                    result = matrix;
                    break;
                case 0:
                    result = matrix;
                    break;

            }


            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j]);
                }

                Console.WriteLine();
            }

        }

        static char[,] Calculate90Degrees(char[,] oldMatrix)
        {
            char[,] newMatrix = new char[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = 0; oldColumn < oldMatrix.GetLength(1); oldColumn++)
            {
                newColumn = 0;
                for (int oldRow = oldMatrix.GetLength(0)-1; oldRow >= 0; oldRow--)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            
            return newMatrix;
        }
        static char[,] Calculate180Degrees(char[,] oldMatrix)
        {
            char[,] newMatrix = new char[oldMatrix.GetLength(0), oldMatrix.GetLength(1)];
            int newColumn = 0;
            int newRow = 0;
            for (int row = oldMatrix.GetLength(0) -1; row >=  0; row--)
            {
                newColumn = 0;
                for (int col = oldMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[row, col];
                    newColumn++;
                }

                newRow++;
            }
            return newMatrix;
        }



        static char[,] Calculate240Degrees(char[,] oldMatrix)
        {
            char[,] newMatrix = new char[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

    }
}

