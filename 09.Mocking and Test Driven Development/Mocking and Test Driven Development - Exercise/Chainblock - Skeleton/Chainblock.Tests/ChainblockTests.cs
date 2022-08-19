namespace Chainblock.Tests
{

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Chainblock.Models;
    using Chainblock.Models.Contracts;

    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
        }


        [Test]
        public void Test_Constructor_Mus_Create_New_Chainblock()
        {
            Assert.That(chainblock != null && chainblock.Count == 0,
                        "The constructor does not create a new Chainblock");
        }


        [Test]
        public void Test_Add_Method_Must_Add_New_Transaction_To_the_Colletion()
        {
            Type type = typeof(Chainblock);

            FieldInfo[] privateFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            Assert.IsTrue(privateFields.Any(fi => fi.FieldType == typeof(ICollection<ITransaction>)),
                          "There is no collection for storing transactions.");
        }


        [Test]
        public void Test_Constructor_Must_Create_New_Chainblock_With_Colletion_Of_Transaction()
        {

            Type type = typeof(Chainblock);

            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));

            object actualFieldValue = collectionField?.GetValue(chainblock);
            int expectedCount = 0;
            int actualCount = chainblock.Count;

            Assert.That(actualFieldValue != null && chainblock.Count == expectedCount,
                "Must throw error because the Collection of type Transaction is null");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Pavkata", 6)]
        public void Test_ContainsTransaction_Method_Must_False
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            bool expectedResult = false;

            bool actualResult = chainblock.Contains(transaction);

            Assert.That(actualResult == expectedResult,
                "Must return false becasue the transaction does not exist in the collection");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_ContainsTransaction_Method_Must_True
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            chainblock.Add(transaction);
            bool expectedResult = true;

            bool actualResult = chainblock.Contains(transaction);

            Assert.That(actualResult == expectedResult,
                  "Must return true becasue the transaction does exist in the collection");

        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_Add_Method_Must_Add_New_Transaction_To_The_Colletion
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            int expectedRCount = 1;
            chainblock.Add(transaction);

            Assert.IsTrue(chainblock.Count == expectedRCount,
                $"There must be {expectedRCount} element in the collection");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_Add_Method_Must_Throw_Error
           (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            ITransaction sameTransaction = new Transaction(id, status, from, to, amount);

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.Add(transaction),
                "Must throw error because there is already exact same transaction in the Chaiblock.");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Pavkata", 6)]
        public void Test_ContainsId_Method_Must_False
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            bool expectedResult = false;

            bool actualResult = chainblock.Contains(transaction.Id);

            Assert.That(actualResult == expectedResult,
                "Must return false becasue the transaction does not exist in the collection");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_ContainsId_Method_Must_True
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            chainblock.Add(transaction);
            bool expectedResult = true;

            bool actualResult = chainblock.Contains(transaction.Id);

            Assert.That(actualResult == expectedResult,
                  "Must return true becasue the transaction does exist in the collection");

        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Cinche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_GetById_Method_Reutn_Chosen_Transation
           (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            ITransaction expectedResult = transaction;
            chainblock.Add(transaction);

            ITransaction actualResult = chainblock.GetById(transaction.Id);
            Assert.IsTrue(actualResult == expectedResult,
                $"There must be {expectedResult} transaction in the collection");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_GetById_Method_Must_Throw_Error
           (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Transaction transaction = new Transaction(id, status, from, to, amount);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(transaction.Id),
                "Must Throw Error no such a transaction.");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Aborted, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_ChangeTransactionStatus_Method_Must_Change_The_Status_Of_The_Chosen_Transaction
            (int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Transaction transaction = new Transaction(id, status, from, to, amount);
            chainblock.Add(transaction);
            TransactionStatus newTransStatus = TransactionStatus.Successfull;
            chainblock.ChangeTransactionStatus(id, newTransStatus);

            TransactionStatus expectedTranStatus = newTransStatus;
            TransactionStatus actualTransStatus = chainblock.GetById(id).Status;

            Assert.That(expectedTranStatus == actualTransStatus,
                        $"The TransactionStatus must be {expectedTranStatus} transactions.");
        }


        [Test]
        public void Test_ChangeTransactionStatus_Method_Must_Throw_Error()
        {
            int id = 5;
            TransactionStatus newTransStatus = TransactionStatus.Successfull;

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(id, newTransStatus),
                "Must throw error because there is no transaction with the given Id in the Chainblock");
        }


        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50)]
        [TestCase(55123, TransactionStatus.Unauthorized, "Bacho Kolio", "Nencho Ivan", 6)]
        public void Test_Remove_Method_Must_Remove_Transaction_From_The_Colletion
            (int id, TransactionStatus status, string from, string to, decimal amount)

        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(chainblock.Count == 0 && chainblock.Contains(transaction.Id) == false,
                "There must no transactions in the collection");
        }


        [Test]
        public void Test_Remove_Method_Must_Throw_Error()
        {
            int id = 12315;

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(id),
                "Must throw error because there is no transaction with such an Id int the Chainblock.");
        }


        [Test]
        public void Test_ChangeTransactionStatus_Method_Return_Transaction_With_The_Given_Status()
        {
            int id = 5;
            TransactionStatus newTransStatus = TransactionStatus.Successfull;

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(id, newTransStatus),
                "Must throw error because there is no transaction with the given Id in the Chainblock");
        }

        
        [TestCase(1, TransactionStatus.Failed, "Gancho", "Lelq Ginche", 22.50, 
                  55123, "Bacho Kolio", "Nencho Ivan", 6)]
        [TestCase(11234, TransactionStatus.Successfull, "Penka", "Lelq Ginche", 22.50,
                  543, "Bacho Kolio", "Bako Ivan", 6)]
        public void Test_GetByTransactionStatus_Method_Must_Return_Chosen_transaction
            (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
            int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);

            int expectedTransCount = 2;
            decimal expectedAmountFirstTrans = amountOne;
            decimal expectedAmountSecondTrans = amountTwo;

            List<ITransaction> resultTransactions = chainblock.GetByTransactionStatus(status).ToList();

            Assert.AreEqual(resultTransactions.Count(), expectedTransCount,
                $"There must be {expectedTransCount} elements in the result collection");
            Assert.That(resultTransactions[0].Amount == expectedAmountFirstTrans && 
                        resultTransactions[1].Amount == expectedAmountSecondTrans,
                "The collection does not cointains the seeking transactions.");
        }


        [Test]
        public void Test_GetByTransactionStatus_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed),
                "Must throw error because there is no transaction with the given status in the Chainblock.");
        }


        [TestCase(1, TransactionStatus.Successfull, "Gancho", "Lelq Ginche", 22.50,
                  55123, "Bacho Kolio", "Nencho Ivan", 6)]
        [TestCase(11234, TransactionStatus.Unauthorized, "Penka", "Lelq Ginche", 22.50,
                  543, "Ivanka", "Bako Ivan", 6)]
        public void Test_GetAllSendersWithTransactionStatus_Method_Must_Return_List_Of_Senders
            (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
            int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(4123123, TransactionStatus.Failed, fromTwo, toTwo, 0.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);

            int expectedTransCount = 2;
            string expectedAmountFirstTSender = fromOne;
            string expectedAmountSecondSender = fromTwo;

            List<string> listOfSenders = chainblock.GetAllSendersWithTransactionStatus(status).ToList();

            Assert.AreEqual(listOfSenders.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction in the result collection");
            Assert.That(listOfSenders[0] == expectedAmountFirstTSender &&
                        listOfSenders[1] == expectedAmountSecondSender,
                "The collection does not cointains the seeking transactions.");
        }


        [Test]
        public void Test_GetAllSendersWithTransactionStatus_Method_Must_Throw_Error()
        {
            ITransaction transaction= new Transaction(4123123, TransactionStatus.Successfull, "Pepa", "Dimitrihcko", 0.15m);
            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed),
                "Must throw error because there is no transaction with the given status in the Chainblock.");
        }


        [TestCase(1, TransactionStatus.Aborted, "Gancho", "Lelq Ginche", 22.50,
                  55123, "Bacho Kolio", "Nencho Ivan", 6)]
        [TestCase(11234, TransactionStatus.Unauthorized, "Penka", "Lelq Ginche", 22.50,
                  543, "Ivanka", "Bako Ivan", 6)]
        public void Test_GetAllReceiversWithTransactionStatus_Method_Must_Return_List_Of_Receivers
           (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
           int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(4123123, TransactionStatus.Failed, fromTwo, toTwo, 0.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);

            int expectedTransCount = 2;
            string expectedAmountFirstTSender = toOne;
            string expectedAmountSecondSender = toTwo;

            List<string> listOfSenders = chainblock.GetAllReceiversWithTransactionStatus(status).ToList();

            Assert.AreEqual(listOfSenders.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction in the result collection");
            Assert.That(listOfSenders[0] == expectedAmountFirstTSender &&
                        listOfSenders[1] == expectedAmountSecondSender,
                "The collection does not cointains the seeking transactions.");
        }


        [Test]
        public void Test_GetAllReceiversWithTransactionStatus_Method_Must_Throw_Error()
        {
            ITransaction transaction = new Transaction(4123123, TransactionStatus.Successfull, "Pepa", "Dimitrihcko", 0.15m);
            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed),
                "Must throw error because there is no transaction with the given status in the Chainblock.");
        }


        [TestCase(1, TransactionStatus.Aborted, "Gancho", "Lelq Ginche", 6642,
                  55123, "Bacho Kolio", "Nencho Ivan", 6642)]
        [TestCase(1, TransactionStatus.Unauthorized, "Penka", "Lelq Ginche", 123.50,
                  543, "Ivanka", "Bako Ivan", 123.50)]
        public void Test_GetAllOrderedByAmountDescendingThenById_Method_Must_Return_Transactions
           (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
           int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            int idThree = 4123123;
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(idThree, TransactionStatus.Failed, fromTwo, toTwo, 111123123.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);

            int expectedTransCount = 3;
            int expectedAmountFirstTSender = idThree;
            int expectedAmountSecondTSender = idOne;
            int expectedAmountThirdSender = idTwo;

            List<ITransaction> orderedTransactions = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.AreEqual(orderedTransactions.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactions[0].Id == expectedAmountFirstTSender &&
                        orderedTransactions[1].Id == expectedAmountSecondTSender &&
                        orderedTransactions[2].Id == expectedAmountThirdSender,
                "The method does not return right values.");
        }


        [Test]
        public void Test_GetAllOrderedByAmountDescendingThenById_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllOrderedByAmountDescendingThenById(),
                "Must throw error because there is no transaction in the Chainblock.");
        }


        [TestCase(1, TransactionStatus.Aborted, "Lelq Ginche", "Ganq Balkanski", 6642,
                 55123, "Lelq Ginche", "Bacho Rosen", 62.55)]
        [TestCase(int.MaxValue, TransactionStatus.Unauthorized, "Lelq Ginche", "Pena", 52.30,
                 543, "Lelq Ginche", "Kyna", 12.70)]
        public void Test_GetBySenderOrderedByAmountDescending_Method_Must_Return_List_Of_Senders
          (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
          int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            int idThree = 4123123;
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(idThree, TransactionStatus.Failed, "Shureq Acho", toTwo, 1123.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);

            int expectedTransCount = 2;
            int expectedAmountFirstTSender = idOne;
            int expectedAmountSecondTSender = idTwo;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetBySenderOrderedByAmountDescending("Lelq Ginche").ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountFirstTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountSecondTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetBySenderOrderedByAmountDescending_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Bako Ivan"),
                "Must throw error because there is no transaction with the given sender in the Chainblock.");
        }


        [TestCase(33, TransactionStatus.Aborted, "Lelq Ginche", "Malyk Gancho", 52.30,
                 1, "Bulq Ivana", "Malyk Gancho", 52.30)]
        [TestCase(1231311, TransactionStatus.Unauthorized, "Lelq Ginche", "Malyk Gancho", 52.30,
                 4, "Kyncho", "Malyk Gancho", 52.30)]
        public void Test_GetByReceiverOrderedByAmountThenById_Method_Must_Return_List_Of_Senders
          (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
          int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            int idThree = 412;
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(idThree, TransactionStatus.Failed, "Shureq Acho", "Petko Bratovcheda", 1123.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);

            int expectedTransCount = 2;
            int expectedAmountFirstTSender = idTwo;
            int expectedAmountSecondTSender = idOne;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetByReceiverOrderedByAmountThenById("Malyk Gancho").ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountFirstTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountSecondTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetByReceiverOrderedByAmountThenById_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Bako Ivan"),
                "Must throw error because there is no transaction with the given receiver in the Chainblock.");
        }


        [TestCase(33, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 52.30,
                 1, "Bulq Ivana", "Malyk Gancho", 2.50)]
        [TestCase(1231311, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 52.30,
                 4, "Kyncho", "Malyk Gancho", 12.70)]
        public void Test_GetByTransactionStatusAndMaximumAmount_Method_Must_Return_List_Of_Transactions
          (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
          int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            int idThree = 412;
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(idThree, TransactionStatus.Successfull, "Shureq Acho", "Petko Bratovcheda", 1123.15m);
            ITransaction transactionFour = new Transaction(23, TransactionStatus.Aborted, "Shureq Acho", "Baba Penka", 11.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            int expectedTransCount = 2;
            int expectedAmountFirstTSender = idOne;
            int expectedAmountSecondTSender = idTwo;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 52.30).ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountFirstTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountSecondTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetByTransactionStatusAndMaximumAmount_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 52.30),
                "Must throw error because there is no transaction with the given paramas in the Chainblock.");
        }

        
        [TestCase(33, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 52.31,
                 1, "Lelq Ginche", "Minka", 1212.30)]
        [TestCase(1231311, TransactionStatus.Successfull, "Lelq Ginche", "Muncho", 723.44,
                 4, "Lelq Ginche", "Petq", 5222.30)]
        public void Test_GetBySenderAndMinimumAmountDescending_Method_Must_Return_List_Of_Transactions
          (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
          int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(412, TransactionStatus.Successfull, "Shureq Acho", "Petko Bratovcheda", 1.10m);
            ITransaction transactionFour = new Transaction(23, TransactionStatus.Aborted, "Shureq Acho", "Baba Penka", 11.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            int expectedTransCount = 2;
            int expectedAmountFirstTSender = idTwo;
            int expectedAmountSecondTSender = idOne;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetBySenderAndMinimumAmountDescending("Lelq Ginche", 52.30).ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountFirstTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountSecondTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetBySenderAndMinimumAmountDescending_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Pena", 52.30),
                "Must throw error because there is no transaction with the given paramas in the Chainblock.");
        }


        [TestCase(33, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 52.31,
                1, "Bulq Ivana", "Malyk Gancho", 1212.30)]
        [TestCase(1231311, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 723.44,
                4, "Kyncho", "Malyk Gancho", 723.44)]
        public void Test_GetByReceiverAndAmountRange_Method_Must_Return_List_Of_Transactions
         (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
         int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(412, TransactionStatus.Successfull, "Shureq Acho", "Petko Bratovcheda", 1.10m);
            ITransaction transactionFour = new Transaction(23, TransactionStatus.Aborted, "Shureq Acho", "Baba Penka", 11.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            int expectedTransCount = 2;
            int expectedAmountFirstTSender = idTwo;
            int expectedAmountSecondTSender = idOne;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetByReceiverAndAmountRange("Malyk Gancho", 52.30, 6000).ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountFirstTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountSecondTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetByReceiverAndAmountRange_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Pena", 1.30, 2000),
                "Must throw error because there is no transaction with the given paramas in the Chainblock.");
        }

        
        [TestCase(33, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 5223323.31,
                1, "Bulq Ivana", "Malyk Gancho", 1212.30)]
        [TestCase(1231311, TransactionStatus.Successfull, "Lelq Ginche", "Malyk Gancho", 7231123.44,
                4, "Kyncho", "Malyk Gancho", 723.44)]
        public void Test_GetAllInAmountRange_Method_Must_Return_List_Of_Transactions
         (int idOne, TransactionStatus status, string fromOne, string toOne, decimal amountOne,
         int idTwo, string fromTwo, string toTwo, decimal amountTwo)
        {
            ITransaction transactionOne = new Transaction(idOne, status, fromOne, toOne, amountOne);
            ITransaction transactionTwo = new Transaction(idTwo, status, fromTwo, toTwo, amountTwo);
            ITransaction transactionThree = new Transaction(412, TransactionStatus.Successfull, "Shureq Acho", "Petko Bratovcheda", 1.10m);
            ITransaction transactionFour = new Transaction(23, TransactionStatus.Aborted, "Shureq Acho", "Baba Penka", 11.15m);

            chainblock.Add(transactionOne);
            chainblock.Add(transactionTwo);
            chainblock.Add(transactionThree);
            chainblock.Add(transactionFour);

            int expectedTransCount = 3;
            int expectedAmountSecondTSender = transactionTwo.Id;
            int expectedAmountThirdTSender = transactionThree.Id;
            int expectedAmountFourthTSender = transactionFour.Id;

            List<ITransaction> orderedTransactionsBySender = chainblock.GetAllInAmountRange(1.09, 6000).ToList();

            Assert.AreEqual(orderedTransactionsBySender.Count(), expectedTransCount,
                $"There must be {expectedTransCount} transaction it the result collection");
            Assert.That(orderedTransactionsBySender[0].Id == expectedAmountSecondTSender &&
                        orderedTransactionsBySender[1].Id == expectedAmountThirdTSender &&
                        orderedTransactionsBySender[2].Id == expectedAmountFourthTSender,
                "The method does not return right transactions.");
        }


        [Test]
        public void Test_GetAllInAmountRange_Method_Must_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllInAmountRange(1.30, 2000),
                "Must throw error because there is no transaction within the given range in the Chainblock.");
        }
    }
}
