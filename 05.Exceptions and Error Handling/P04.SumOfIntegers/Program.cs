using System;
using System.Numerics;

namespace P04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(" ");
            BigInteger bigInt = new BigInteger();
            int sum = 0;

            foreach (string element in elements)
            {
                try
                {
                    if (BigInteger.TryParse(element, out bigInt))
                    {
                        if (bigInt > int.MaxValue || bigInt < int.MinValue)
                        {
                            throw new OverflowException($"The element '{element}' is out of range!");
                        }

                        else
                        {
                            sum += int.Parse(element);
                        }
                    }

                    else
                    {
                        throw new FormatException($"The element '{element}' is in wrong format!");
                    }
                }

                catch (OverflowException overFlowEx)
                {
                    Console.WriteLine(overFlowEx.Message);
                }

                catch(FormatException formatEx) 
                {
                    Console.WriteLine(formatEx.Message);
                }

                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
