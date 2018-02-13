using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse)
                .ToArray();
            var rowsInput = rowsAndCols[0];
            var colsInput = rowsAndCols[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rowsInput, colsInput];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    var firstLastLetter = alphabet[rows];
                    var middleLetter = alphabet[cols+rows];
                    matrix[rows, cols] = CharCombine(firstLastLetter, middleLetter, firstLastLetter);

                }
            }


            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }

                Console.WriteLine();
            }

        }

        public static string CharCombine(char c0, char c1, char c2)
        {
            // Combine chars into array
            char[] arr = new char[3];
            arr[0] = c0;
            arr[1] = c1;
            arr[2] = c2;
            // Return new string key
            return new string(arr);
        }
    }
}
