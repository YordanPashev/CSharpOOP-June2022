using System;
using System.Collections.Generic;

namespace P02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();
            int currDigit = 0;

            while (numbers.Count < 10)
            {
                string input = Console.ReadLine();

                try
                {
                    if (!int.TryParse(input, out int result))
                    {
                        throw new InvalidOperationException();
                    }

                    currDigit = int.Parse(input);

                    if (currDigit <= start || currDigit >= end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    else
                    {
                        start = currDigit;
                        numbers.Add(currDigit);
                    }
                }

                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid Number!");
                    continue;
                }

                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                    continue;
                }
            }

            Console.WriteLine($"{string.Join(", ", numbers)}");
        }
    }
}
