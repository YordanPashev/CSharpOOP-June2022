using System;

namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new InvalidOperationException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }

            catch (InvalidOperationException)
            { 
                Console.WriteLine("Invalid number.");
            }

            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
