namespace Chainblock.Models
{
    using System;

    using Models.Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;


        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Id can not be 0 or negative number!");
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this.from;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Sender can not be null or empty!");
                }

                this.from = value;
            }
        }

        public string To
        {
            get => this.to;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Recieve can not be null or empty!");
                }

                this.to = value;
            }
        }

        public decimal Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The Amount can not be negative!");
                }

                this.amount = value;
            }
        }
    }
}
