using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            int[][] matrix = new int[rows][];

            int number = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[dimensions[1]];

                for (int j = 0; j < matrix[i].Length; j++)
                {



                    matrix[i][j] = number;
                    number++;
                }
            }


            var command = Console.ReadLine().Trim();

            while (command != "Nuke it from orbit")
            {
                var commandDetails = command
                    .Split()
                    .ToArray();

                var imactRow = int.Parse(commandDetails[0]);
                var imactCol = int.Parse(commandDetails[1]);
                var radius = int.Parse(commandDetails[2]);
                var crntCol = imactRow - radius;
                var crntRow = imactCol - radius;

                if (crntRow < 0)
                {
                    crntRow = 0;
                }

                if (crntCol < 0)
                {
                    crntCol = 0;
                }

                for (int row = crntCol; row <= imactRow + radius; row++)
                {
                    try
                    {
                        matrix[row][imactCol] = -1;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                   

                }


                for (int col = crntRow; col <= imactCol + radius; col++)
                {
                    try
                    {
                        matrix[imactRow][col] = -1;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    

                }


                for (int row = 0; row < matrix.Length; row++)
                {

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] < 0)
                        {
                            matrix[row] = matrix[row].Where(n => n > 0).ToArray();
                        }
                    }

                    if (matrix[row].Length < 1)
                    {
                        matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                        row--;
                    }


                }
                command = Console.ReadLine().Trim();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

    }
}
