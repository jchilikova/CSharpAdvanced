using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;

namespace DangerousFloor
{
    class Program
    {
        public static char[,] matrix;
        static void Main(string[] args)
        {
            matrix = new char[8, 8];
            for (int rows = 0; rows < 8; rows++)
            {
                var input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < input.Length; cols++)
                {
                    matrix[rows, cols] = char.Parse(input[cols]);
                }
            }

            Regex pattern = new Regex(@"(?<figure>[A-Za-z])(?<currentRow>\d)(?<currentCol>\d)-(?<finalRow>\d)(?<finalCol>\d)");

            var command = Console.ReadLine().Trim();
            while (command != "END")
            {
                Match match = pattern.Match(command);
                var figure = char.Parse(match.Groups["figure"].Value);
                var currentRow = int.Parse(match.Groups["currentRow"].Value);
                var currentCol = int.Parse(match.Groups["currentCol"].Value);

                var destinationRow = int.Parse(match.Groups["finalRow"].Value);
                var destinationCol = int.Parse(match.Groups["finalCol"].Value);

                if (IsTherePiece(currentRow, currentCol, figure))
                {
                    switch (figure)
                    {
                        case 'K':
                            if (CanKingMove(currentRow, currentCol, destinationRow, destinationCol))
                            {
                                if (IsInside(destinationRow, destinationCol))
                                {
                                    MoveFigure(currentRow, currentCol, destinationRow, destinationCol, figure);
                                }
                                else
                                {
                                    Console.WriteLine("Move go out of board!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case 'R':
                            if (CanRookMove(currentRow, currentCol, destinationRow, destinationCol))
                            {
                                if (IsInside(destinationRow, destinationCol))
                                {
                                    MoveFigure(currentRow, currentCol, destinationRow, destinationCol, figure);
                                }
                                else
                                {
                                    Console.WriteLine("Move go out of board!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case 'B':
                            if (CanBishopMove(currentRow, currentCol, destinationRow, destinationCol))
                            {
                                if (IsInside(destinationRow, destinationCol))
                                {
                                    MoveFigure(currentRow, currentCol, destinationRow, destinationCol, figure);
                                }
                                else
                                {
                                    Console.WriteLine("Move go out of board!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case 'Q':
                            if (CanQueenMove(currentRow, currentCol, destinationRow, destinationCol))
                            {
                                if (IsInside(destinationRow, destinationCol))
                                {
                                    MoveFigure(currentRow, currentCol, destinationRow, destinationCol, figure);
                                }
                                else
                                {
                                    Console.WriteLine("Move go out of board!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }

                            break;
                        case 'P':
                            if (CanPawnMove(currentRow, currentCol, destinationRow, destinationCol))
                            {
                                if (IsInside(destinationRow, destinationCol))
                                {
                                    MoveFigure(currentRow, currentCol, destinationRow, destinationCol, figure);
                                }
                                else
                                {
                                    Console.WriteLine("Move go out of board!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }

                command = Console.ReadLine().Trim();
            }
        }

        public static void MoveFigure(int currentRow, int currentCol, int destinationRow, int destinationCol, char figure)
        {
            matrix[currentRow, currentCol] = 'x';
            matrix[destinationRow, destinationCol] = figure;
        }

        public static bool IsTherePiece(int currentRow, int currentCol, char figure)
        {
            if (matrix[currentRow, currentCol] == figure)
            {
                return true;
            }
            return false;
        }

        public static bool CanKingMove(int currentRow, int currentCol, int destinationRow, int destinationCol)
        {

            int rowDiff = Math.Abs(currentRow - destinationRow);
            int colDiff = Math.Abs(currentCol - destinationCol);
            if (rowDiff > 1 || colDiff > 1)
            {
                return false;
            }
            return true;
        }

        public static bool CanRookMove(int currentRow, int currentCol, int destinationRow, int destinationCol)
        {

            int rowDiff = Math.Abs(currentRow - destinationRow);
            int colDiff = Math.Abs(currentCol - destinationCol);
            if (rowDiff == 0)
            {
                return true;
            }
            else if (colDiff == 0)
            {
                return true;
            }

            return false;
        }

        public static bool CanBishopMove(int currentRow, int currentCol, int destinationRow, int destinationCol)
        {

            int rowsDiference = Math.Abs(currentRow - destinationRow);
            int colsDiference = Math.Abs(currentCol - destinationCol);

            if (rowsDiference == colsDiference)
            {
                return true;
            }

            return false;
        }

        public static bool CanPawnMove(int currentRow, int currentCol, int destinationRow, int destinationCol)
        {

            int rowDiff = currentRow - destinationRow;
            if (rowDiff == 1 && currentCol == destinationCol)
            {
                return true;
            }

            return false;
        }

        public static bool CanQueenMove(int currentRow, int currentCol, int destinationRow, int destinationCol)
        {

            if (CanBishopMove(currentRow, currentCol, destinationRow, destinationCol) || CanRookMove(currentRow, currentCol, destinationRow, destinationCol))
            {
                return true;
            }


            return false;
        }

        public static bool IsInside(int destinationRow, int destinationCol)
        {
            if (destinationCol >= 8 || destinationRow >= 8 || destinationRow < 0 || destinationCol < 0)
            {
                return false;
            }

            return true;
        }
    }
}
