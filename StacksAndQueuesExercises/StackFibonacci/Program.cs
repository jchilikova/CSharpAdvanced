using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class Program
    {
        private static long prevNumber;
        private static long nMinusOne;
        private static long nMinusTwo;

        static void Main(string[] args)
        {
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(0);
            fibonacci.Push(1);

            

            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                prevNumber = fibonacci.Peek();
                nMinusOne = fibonacci.Pop();
                nMinusTwo = fibonacci.Pop();
                fibonacci.Push(prevNumber);
                fibonacci.Push(nMinusOne + nMinusTwo);
                
            }

            fibonacci.Pop();
            Console.WriteLine(fibonacci.Peek());
        }
    }
}
