using System;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split().ToArray();
            var rows = int.Parse(rowsAndCols[0]);
            var cols = int.Parse(rowsAndCols[1]);
            var matrix = new int[rows, cols];
            var index = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = index;
                    index++;
                }
            }

            long sum = 0;
            var input = Console.ReadLine();
            while (input != "Let the Force be with you")
            {
                var inputIvo = input.Split().Select(int.Parse).ToArray();
                var inputEvil = Console.ReadLine().Split().Select(int.Parse).ToArray();

                // int ivoRows = inputIvo[0] < 0 ? 0 : inputIvo[0] - 1;
                // int ivoCols = inputIvo[1] < 0 ? 0 : inputIvo[1] - 1;
                // int evilRows = inputEvil[0] < 0 ? 0 : inputEvil[0] - 1;
                // int evilCols = inputEvil[1] < 0 ? 0 : inputEvil[1] - 1;

                int ivoRows = inputIvo[0];
                int ivoCols = inputIvo[1];

                int evilRows = inputEvil[0];
                int evilCols = inputEvil[1];



                while (evilRows >= 0 && evilCols >= 0)
                {
                    if (IsInMatrix(matrix, evilRows, evilCols))
                    {

                        matrix[evilRows, evilCols] = 0;

                    }
                    evilCols--;
                    evilRows--;
                }
                while (ivoRows >= 0 && ivoCols <= cols)
                {
                    if (IsInMatrix(matrix, ivoRows, ivoCols))
                    {

                        sum += matrix[ivoRows, ivoCols];

                    }
                    ivoRows--;
                    ivoCols++;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static bool IsInMatrix(int[,] matrix, int rows, int cols)
        {
            return rows >= 0 && rows < matrix.GetLength(0) && cols >= 0 && cols < matrix.GetLength(1);
        }
    }
}
