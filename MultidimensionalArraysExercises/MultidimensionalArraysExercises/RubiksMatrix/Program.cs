using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static int rows;
        private static int cols;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            rows = dimensions[0];
            cols = dimensions[1];

            matrix = new int[rows, cols];

            int number = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[rows, cols] = number;
                    number++;
                }
            }

            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                ParseCommand();
            }

            RearrangeMatrix();
        }

        public static void RearrangeMatrix()
        {
            int expected = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == expected)
                    {
                        Console.WriteLine("No swap required");
                        expected++;
                        continue;
                    }

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            if (matrix[r, c] == expected)
                            {
                                int temp = matrix[row, col];
                                matrix[row, col] = matrix[r, c];
                                matrix[r, c] = temp;
                                Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                expected++;
                                break;
                            }
                        }
                    }
                    
                }
            }
        }

        public static void ParseCommand()
        {
            string[] commandArgs = Console.ReadLine().Split();
            string command = commandArgs[1];
            int index = int.Parse(commandArgs[0]);
            int rotations = int.Parse(commandArgs[2]);

            switch (command)
            {
                case "up":
                    MoveColumn(index, rows - rotations);
                    break;
                case "down":
                    MoveColumn(index, rotations);
                    break;
                case "left":
                    MoveRow(index, cols - rotations);
                    break;
                case "right":
                    MoveRow(index, rotations);
                    break;
            }
        }

        public static void MoveRow(int index, int rotations)
        {
            rotations %= cols;

            int[] temp = new int[cols];

            for (int i = 0; i < cols; i++)
            {
                int replacementIndex = i + rotations;

                replacementIndex %= cols;

                temp[replacementIndex] = matrix[index, i];
            }

            for (int i = 0; i < cols; i++)
            {
                matrix[index, i] = temp[i];
            }
        }

        public static void MoveColumn(int index, int rotations)
        {
            rotations %= rows;

            int[] temp = new int[rows];

            for (int i = 0; i < cols; i++)
            {
                int replacementIndex = i + rotations;

                replacementIndex %= rows;

                temp[replacementIndex] = matrix[index, i];
            }

            for (int i = 0; i < cols; i++)
            {
                matrix[i, index] = temp[i];
            }
        }
    }
}
