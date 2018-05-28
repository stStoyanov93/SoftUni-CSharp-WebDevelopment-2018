using System;
using System.Linq;
using System.Threading;

namespace P01_EvenNumbersThread
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var startNumber = inputNumbers[0];
            var endNumber = inputNumbers[1];

            var evenNumbers = new Thread(() => PrintEvenNumbers(startNumber, endNumber));
            evenNumbers.Start();
            evenNumbers.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
