using System;
using System.Linq;

namespace P05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int exceptionCounter = 0;

            while (exceptionCounter < 3)
            {
                string[] cmd = Console.ReadLine().Split(" ");
                string action = cmd[0];

                try
                {
                    ExecuteCmd(array, cmd);
                }

                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    exceptionCounter++;
                }

                catch (IndexOutOfRangeException outOfRangeEx)
                {
                    Console.WriteLine(outOfRangeEx.Message);
                    exceptionCounter++;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        private static void ExecuteCmd(int[] array, string[] cmd)
        {
            string action = cmd[0];
            string elementIndex = cmd[1];

            if (action == "Show" && cmd.Length == 2)
            {
                int index = TryParseToInt(elementIndex);
                if (isInRange(index, array))
                {
                    Console.WriteLine(array[index]);
                }
            }

            else
            {
                string start = cmd[1];
                string end = cmd[2];
                int cmdElementTwo = TryParseToInt(start);
                int cmdElementThree = TryParseToInt(end);

                if (action == "Replace")
                {
                    if (isInRange(cmdElementTwo, array))
                    {
                        int index = cmdElementTwo;
                        int value = cmdElementThree;
                        array[index] = value;
                    }
                }

                else if (action == "Print")
                {
                    int startIndex = cmdElementTwo;
                    int endIndex = cmdElementThree;
                    if (isInRange(startIndex, array) && isInRange(endIndex, array))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            if (i == endIndex)
                            {
                                Console.Write(array[i]);
                                Console.WriteLine();
                                break;
                            }

                            Console.Write(array[i] + ", ");
                        }
                    }
                }
            }
        }

        private static bool isInRange(int index, int[] array)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }

            return true;
        }

        public static int TryParseToInt(string elementIndex)
        {
            if (!int.TryParse(elementIndex, out int result))
            {
                throw new FormatException("The variable is not in the correct format!");
            }

            return result;
        }
    }
}
