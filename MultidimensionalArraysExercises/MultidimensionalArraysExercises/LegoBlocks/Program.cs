using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            int[][] secondJaggedArray = new int[n][];


            int secondArrIndex = 0;
            for (int i = 0; i < 2 * n; i++)
            {
                var inputArr = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (i >= n)
                {
                    secondJaggedArray[secondArrIndex] = inputArr;
                    secondArrIndex++;
                }
                else if (i < n)
                {
                    jaggedArray[i] = inputArr;
                }
            }
            ReverseJaggedArray(secondJaggedArray);
            int[][] mergedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var array = jaggedArray[i];
                var array2 = secondJaggedArray[i];
                var result = array.Concat(array2).ToArray();
                mergedArray[i] = result;
            }

            int length = 0;
            int maxLength = mergedArray[0].Length;
            bool equal = false;
            for (int i = 0; i < n; i++)
            {
                equal = false;
                length = mergedArray[i].Length;
                if (length == maxLength)
                {
                    equal = true;
                }
            }

            if (equal)
            {
                for (int row = 0; row < n; row++)
                {
                    Console.Write("[");

                    for (int col = 0; col < mergedArray[row].Length; col++)
                    {
                        if (col == mergedArray[row].Length -1)
                        {
                            Console.Write(mergedArray[row][col]);
                        }
                        else
                        {
                            Console.Write(mergedArray[row][col] + ", ");
                        }
                        

                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += mergedArray[i].Length;
                }
                Console.WriteLine("The total number of cells is: " +sum);
            }
        }

        public static void ReverseJaggedArray(int[][] jaggedArray)
        {
            for (int rowIndex = 0;
                rowIndex <= (jaggedArray.GetUpperBound(0)); rowIndex++)
            {
                for (int colIndex = 0;
                    colIndex <= (jaggedArray[rowIndex].GetUpperBound(0) / 2);
                    colIndex++)
                {
                    int tempHolder = jaggedArray[rowIndex][colIndex];
                    jaggedArray[rowIndex][colIndex] =
                        jaggedArray[rowIndex][jaggedArray[rowIndex].GetUpperBound(0) -
                                           colIndex];
                    jaggedArray[rowIndex][jaggedArray[rowIndex].GetUpperBound(0) -
                                       colIndex] = tempHolder;
                }
            }
        }
    }
}
