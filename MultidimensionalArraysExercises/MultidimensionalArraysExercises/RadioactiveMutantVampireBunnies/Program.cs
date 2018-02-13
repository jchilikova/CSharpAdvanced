using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        private static int rows;
        private static int cols;
        private static char[,] matrix;

        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            rows = rowsAndCols[0];
            cols = rowsAndCols[1];
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var resultMatrix = new char[rows, cols];
            Array.Copy(matrix, resultMatrix, matrix.Length);
            
            var moves = Console.ReadLine().ToArray();
            bool isDead = false;
            bool isEscaped = false;
            string output = "";

            for (int move = 0; move < moves.Length; move++)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (!matrix[row, col].Equals('P')) continue;
                        switch (moves[move])
                        {
                            case 'U':
                                try
                                {
                                    if (resultMatrix[row - 1, col] == 'B')
                                    {
                                        isDead = true;
                                        output = $"dead: {row - 1} {col}";
                                        resultMatrix[row, col] = '.';

                                    }
                                    else
                                    {
                                        resultMatrix[row - 1, col] = 'P';
                                        resultMatrix[row, col] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    isEscaped = true;
                                    output = $"won: {row} {col}";
                                    resultMatrix[row, col] = '.';
                                }

                                break;
                            case 'D':
                                try
                                {
                                    if (resultMatrix[row + 1, col] == 'B')
                                    {
                                        isDead = true;
                                        output = $"dead: {row + 1} {col}";
                                        resultMatrix[row, col] = '.';

                                    }
                                    else
                                    {
                                        resultMatrix[row + 1, col] = 'P';
                                        resultMatrix[row, col] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    isEscaped = true;
                                    output = $"won: {row} {col}";
                                    resultMatrix[row, col] = '.';
                                }

                                break;
                            case 'L':
                                try
                                {
                                    if (resultMatrix[row, col - 1] == 'B')
                                    {
                                        isDead = true;
                                        output = $"dead: {row} {col - 1}";
                                        resultMatrix[row, col] = '.';

                                    }
                                    else
                                    {
                                        resultMatrix[row, col - 1] = 'P';
                                        resultMatrix[row, col] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    isEscaped = true;
                                    output = $"won: {row} {col}";
                                    resultMatrix[row, col] = '.';
                                }

                                break;
                            case 'R':
                                try
                                {
                                    if (resultMatrix[row, col + 1] == 'B')
                                    {
                                        isDead = true;
                                        output = $"dead: {row} {col + 1}";
                                        resultMatrix[row, col] = '.';

                                    }
                                    else
                                    {
                                        resultMatrix[row, col + 1] = 'P';
                                        resultMatrix[row, col] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    isEscaped = true;
                                    output = $"won: {row} {col}";
                                    resultMatrix[row, col] = '.';
                                }

                                break;
                        }

                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                if (!matrix[i, j].Equals('B'))
                                {
                                    continue;
                                }

                                try
                                {
                                    var element = resultMatrix[i + 1, j];
                                    if (element == 'P')
                                    {
                                        isDead = true;
                                        output = $"dead: {i + 1} {j}";

                                    }

                                    resultMatrix[i + 1, j] = 'B';

                                }
                                catch (Exception)
                                {
                                    //ignored
                                }

                                try
                                {
                                    var element = resultMatrix[i - 1, j];
                                    if (element == 'P')
                                    {
                                        isDead = true;
                                        output = $"dead: {i - 1} {j}";

                                    }

                                    resultMatrix[i - 1, j] = 'B';

                                }
                                catch (Exception)
                                {
                                    //ignored
                                }

                                try
                                {
                                    var element = resultMatrix[i, j - 1];
                                    if (element == 'P')
                                    {
                                        isDead = true;
                                        output = $"dead: {i} {j - 1}";

                                    }

                                    resultMatrix[i, j - 1] = 'B';

                                }
                                catch (Exception)
                                {
                                    //ignored
                                }

                                try
                                {
                                    var element = resultMatrix[i, j + 1];
                                    if (element == 'P')
                                    {
                                        isDead = true;
                                        output = $"dead: {i} {j + 1}";

                                    }

                                    resultMatrix[i, j + 1] = 'B';

                                }
                                catch (Exception)
                                {
                                    //ignored
                                }
                            }
                        }
                    }


                }
                Array.Copy(resultMatrix, matrix, resultMatrix.Length);
                if (!isDead && !isEscaped) continue;
                for (var l = 0; l < rows; l++)
                {
                    for (var m = 0; m < cols; m++)
                    {
                        Console.Write(resultMatrix[l, m]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine(output);
                return;
            }

        }
    }
}
