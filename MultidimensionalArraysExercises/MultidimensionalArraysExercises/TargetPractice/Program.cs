using System;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new char[rows, cols];

            var snakeString = Console.ReadLine().ToCharArray();
            var shot = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var imactRow = shot[0];
            var imactCol = shot[1];
            var imactRadius = shot[2];

            var snakeIndex = 0;

            bool isLeft = true;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (isLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snakeString.Length)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row, col] = snakeString[snakeIndex];
                        snakeIndex++;
                    }

                    isLeft = false;
                }

                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (snakeIndex == snakeString.Length)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row, col] = snakeString[snakeIndex];
                        snakeIndex++;
                    }

                    isLeft = true;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int absRow = Math.Abs(row - imactRow);
                    int absCol = Math.Abs(col - imactCol);
                    int absSum = absCol + absRow;

                    if (absSum <= imactRadius)
                    {
                        matrix[row, col] = ' ';
                    }


                }
            }

            var hasChange = true;
            while (hasChange)
            {
                hasChange = false;
                for (int row = 0; row < rows - 1; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        var currentSymbol = matrix[row, col];

                        if (matrix[row + 1, col] == ' ' && matrix[row, col] != ' ')
                        {
                            hasChange = true;
                            matrix[row + 1, col] = currentSymbol;
                            matrix[row, col] = ' ';
                        }
                    }
                }
            }


            for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();
                }

           
        }
    }
}
