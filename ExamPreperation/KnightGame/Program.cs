using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace KnightGame
{
    class Program
    {
        public static char[,] matrix;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var index = 0;
            var max = 0;

            matrix = new char[number, number];

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Trim();
                foreach (var item in input)
                {
                    matrix[i, index] = (item);
                    index++;
                }

                index = 0;
            }

            int positionRow = 0;
            int positionCol = 0;

            int knightTaken = 0;

            while (true)
            {
                for (int row = 0; row < number; row++)
                {
                    for (int col = 0; col < number; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            var currentCount = 0;
                            //two left one down
                            if (IsInRange(row + 1, col - 2))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //two right one down
                            if (IsInRange(row + 1, col + 2))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //one left two down
                            if (IsInRange(row + 2, col - 1))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //one right two down
                            if (IsInRange(row + 2, col + 1))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //two left one up
                            if (IsInRange(row - 1, col - 2))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currentCount++;
                                }

                            }
                            //two right one up
                            if (IsInRange(row - 1, col + 2))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //one left two up
                            if (IsInRange(row - 2, col - 1))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currentCount++;
                                }
                            }
                            //one right two up
                            if (IsInRange(row - 2, col + 1))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    currentCount++;
                                }
                            }

                            if (currentCount <= max) continue;
                            max = currentCount;
                            positionCol = col;
                            positionRow = row;

                        }
                    }

                }

                if (max > 0)
                {
                    matrix[positionRow, positionCol] = '0';
                    max = 0;
                    knightTaken++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightTaken);

        }

        public static bool IsInRange(int dim1, int dim2)
        {
            if (dim1 >= matrix.GetLength(0) || dim2 >= matrix.GetLength(1) || dim1 < 0 || dim2 < 0)
            {
                return false;
            }

            return true;
        }
    }
}
