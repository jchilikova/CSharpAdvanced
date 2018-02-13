using System;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        private static bool[][] parking;
        private static int columns;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var row = dimensions[0];
            columns = dimensions[1];
            parking = new bool[row][];

            var input = Console.ReadLine();
            while (input != "stop")
            {
                var line = input.Split().Select(int.Parse).ToArray();

                var entryRow = line[0];
                var targetRow = line[1];
                var targetCol = line[2];

                if (IsSpotTaken(targetRow,targetCol))
                {
                    targetCol = TryFindNewSpot(targetRow, targetCol);
                }

                if (targetCol > 0)
                {
                    ParkTheCar(targetRow, targetCol);
                    var distanceTaken = Math.Abs(entryRow - targetRow) + targetCol + 1;
                    Console.WriteLine(distanceTaken);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                input = Console.ReadLine();
            }
        }

        private static void ParkTheCar(int targetRow, int targetCol)
        {
            if (parking[targetRow] == null)
            {
                parking[targetRow] = new bool[columns];
            }

            parking[targetRow][targetCol] = true;
        }

        private static int TryFindNewSpot(int targetRow, int targetCol)
        {
            var parkingCol = 0;
            var distanceMax = 10001;

            for (int cols = 1; cols < columns; cols++)
            {
                if (!parking[targetRow][cols])
                {
                    var distance = Math.Abs(targetCol - cols);

                    if (distance < distanceMax)
                    {
                        distanceMax = distance;
                        parkingCol = cols;
                    }
                }

            }

            return parkingCol;
        }

        private static bool IsSpotTaken(int targetRow, int targetCol)
        {
            return parking[targetRow] != null && parking[targetRow][targetCol];
        }
    }
}
