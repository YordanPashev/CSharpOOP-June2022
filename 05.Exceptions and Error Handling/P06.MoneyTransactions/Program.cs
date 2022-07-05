using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.MonayTranslation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<int, decimal> bankAccounts = CreateBankAccounts(input);

            string cmd = string.Empty;
            while ((cmd = Console.ReadLine()) != "End")
            {
                ExecuteCmd(cmd, bankAccounts);
            }
        }

        private static void ExecuteCmd(string cmd, Dictionary<int, decimal> bankAccounts)
        {
            string[] cmdArgs = cmd.Split(" ").ToArray();
            string action = cmdArgs[0];
            string secondElement = cmdArgs[1];
            string thirdElement = cmdArgs[2];

            try
            {
                int bankAccountNumber = IntTryParse(secondElement);
                decimal amount = DecimalTryParse(thirdElement);

                if (!bankAccounts.ContainsKey(bankAccountNumber))
                {
                    throw new InvalidOperationException("Invalid account!");
                }

                if (action == "Deposit")
                {
                    bankAccounts[bankAccountNumber] += amount;
                    Console.WriteLine($"Account {bankAccountNumber} has new balance: {bankAccounts[bankAccountNumber]:F2}");
                }

                else if (action == "Withdraw")
                {
                    if (bankAccounts[bankAccountNumber] < amount)
                    {
                        throw new InvalidOperationException("Insufficient balance!");
                    }

                    bankAccounts[bankAccountNumber] -= amount;
                    Console.WriteLine($"Account {bankAccountNumber} has new balance: {bankAccounts[bankAccountNumber]:F2}");
                }

                else
                {
                    throw new InvalidOperationException("Invalid command!");
                }
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine("Enter another command");
            }
            
        }

        private static Dictionary<int, decimal> CreateBankAccounts(string[] input)
        {
            Dictionary<int, decimal> bankAccounts = new Dictionary<int, decimal>();

            foreach (string backAccount in input)
            {
                string[] currAccountInfo = backAccount
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string firstElement = currAccountInfo[0];
                string secondElement = currAccountInfo[1];

                try
                {
                    int bankAccountNumber = IntTryParse(firstElement);
                    decimal balanace = DecimalTryParse(secondElement);

                    bankAccounts.Add(bankAccountNumber, balanace);
                }

                catch (InvalidOperationException invalidOperationEx)
                {
                    Console.WriteLine(invalidOperationEx.Message);
                    continue;
                }
            }

            return bankAccounts;
        }

        private static decimal DecimalTryParse(string balance)
        {
            if (decimal.TryParse(balance, out decimal result))
            {
                return result;
            }

            throw new InvalidOperationException("Invalid command!");
        }

        private static int IntTryParse(string bankAccountNumber)
        {
            if (int.TryParse(bankAccountNumber, out int result))
            {
                return result;
            }

            throw new InvalidOperationException("Invalid command!");
        }
    }
}
