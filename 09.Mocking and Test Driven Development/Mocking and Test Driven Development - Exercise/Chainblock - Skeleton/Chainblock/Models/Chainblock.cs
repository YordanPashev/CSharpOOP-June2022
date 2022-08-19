namespace Chainblock.Models
{

    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Models.Contracts;

    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;

        public Chainblock()
        {
            transactions = new HashSet<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                this.transactions.Add(tx);
                return;
            }

            throw new InvalidOperationException("The transaction already exist in the collection.");
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus) 
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException("There is no transaction with the given Id.");
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx) => this.transactions.Contains(tx);

        public bool Contains(int id) => this.transactions.Any(t => t.Id == id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                 .Where(t => t.Amount >= (decimal)lo && t.Amount <= (decimal)hi);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("There is no transaction with given sender and the amount bove the minimum allowed.");
            }

            return orderedTransaction;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> orderedTransactions = this.transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (!orderedTransactions.Any())
            {
                throw new InvalidOperationException("There is no transactions to order.");
            }

            return orderedTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> result = this.transactions
               .Where(t => t.Status == status)
               .Select(t => t.To);

            if (!result.Any())
            {
                throw new InvalidOperationException("There is no transaction with the given status.");
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> result = this.transactions
                .Where(t => t.Status == status)
                .Select(t => t.From);

            if (!result.Any())
            {
                throw new InvalidOperationException("There is no transaction with the given status.");
            }

            return result;
        }

        public ITransaction GetById(int id)
            => this.transactions.FirstOrDefault(t => t.Id == id) ??
               throw new InvalidOperationException("There is no transaction with given Id.");

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                 .Where(t => t.To == receiver && t.Amount >= (decimal)lo && t.Amount <= (decimal)hi)
                 .OrderByDescending(t => t.Amount)
                 .ThenBy(t => t.Id);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("There is no transaction with given sender and the amount bove the minimum allowed.");
            }

            return orderedTransaction;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("The receiver does not have a signle transaction.");
            }

            return orderedTransaction;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                .Where(t => t.From == sender && t.Amount > (decimal)amount)
                .OrderByDescending(t => t.Amount);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("There is no transaction with given sender and the amount bove the minimum allowed.");
            }

            return orderedTransaction;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("The sernder does not have a signle transaction.");
            }

            return orderedTransaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = this.transactions
                .OrderByDescending(t => t.Amount)
                .Where(t => t.Status == status);

            if (transactions == null || transactions.Count() == 0)
            {
                throw new InvalidOperationException("There is no transaction with the given status.");
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> orderedTransaction = this.transactions
                .Where(t => t.Status == status && t.Amount <= (decimal)amount)
                .OrderByDescending(t => t.Amount);

            if (!orderedTransaction.Any())
            {
                throw new InvalidOperationException("There is no transaction with given status and the amount less or equal to a maximum allowed.");
            }

            return orderedTransaction;
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException("No such a transaction in the Chainblock.");
            }

            this.transactions.Remove(transaction);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (ITransaction transaction in this.transactions)
            {
                yield return transaction; 
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
