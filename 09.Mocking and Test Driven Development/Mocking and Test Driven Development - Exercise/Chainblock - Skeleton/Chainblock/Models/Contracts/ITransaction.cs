namespace Chainblock.Models.Contracts
{
    public interface ITransaction
    {
        int Id { get; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        decimal Amount { get; set; }
    }
}