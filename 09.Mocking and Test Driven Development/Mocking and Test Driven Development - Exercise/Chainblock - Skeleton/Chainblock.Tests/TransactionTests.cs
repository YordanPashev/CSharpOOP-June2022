namespace Chainblock.Tests
{

    using System;

    using NUnit.Framework;

    using Chainblock.Models;
    using Chainblock.Models.Contracts;

    [TestFixture]
    public class TransactionTests
    {
        [TestCase(1, TransactionStatus.Failed, "Bako Ivan", "Gancho", 22.50)]
        [TestCase(int.MaxValue, TransactionStatus.Successfull, "Dimitrichko", "Pena", 7.75)]
        [TestCase(1243125, TransactionStatus.Unauthorized, "Bulq Maria", "Bacho Kolio", 6)]
        public void Test_Constructor_Must_Create_New_Transaction_With_Give_Values
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            Assert.That(transaction != null && transaction.Id == id &&
                        transaction.Status == status && transaction.From == from &&
                        transaction.To == to && transaction.Amount == amount,
                        "The constructor does not create a new transaction with given values.");
        }

        [TestCase(-1, TransactionStatus.Failed, "Bako Ivan", "Gancho", 22.50)]
        [TestCase(int.MinValue, TransactionStatus.Successfull, "Dimitrichko", "Pena", 7.75)]
        [TestCase(0, TransactionStatus.Unauthorized, "Bulq Maria", "Bacho Kolio", 6)]
        public void Test_Id_Must_Throw_Error_Zero_Or_NegativeNumber
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Assert.Throws<ArgumentException>(() => new Transaction(id, status, from, to, amount),
                        "The Id can not be 0 or negative number.");
        }

        [TestCase(1, TransactionStatus.Failed, "", "Gancho", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, null, "Bacho Kolio", 6)]
        public void Test_Sender_Must_Throw_Error_Null_Or_Empty
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Assert.Throws<ArgumentNullException>(() => new Transaction(id, status, from, to, amount),
                        "The Sender can not be null or empty");
        }

        [TestCase(1, TransactionStatus.Failed, "Gancho", null, 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "", 6)]
        public void Test_Receiver_Must_Throw_Error_Null_Or_Empty
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Assert.Throws<ArgumentNullException>(() => new Transaction(id, status, from, to, amount),
                        "The Receiver can not be null or empty");
        }

        [TestCase(1, TransactionStatus.Failed, "Bako Ivan", "Gancho", int.MinValue)]
        [TestCase(int.MaxValue, TransactionStatus.Successfull, "Dimitrichko", "Pena", -1)]
        [TestCase(12312456, TransactionStatus.Unauthorized, "Bulq Maria", "Bacho Kolio", -1231245)]
        public void Test_Amount_Must_Throw_Error_Zero_Or_NegativeNumber
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Assert.Throws<InvalidOperationException>(() => new Transaction(id, status, from, to, amount),
                        "The Amount can not be 0 or negative number.");
        }
    }
}
