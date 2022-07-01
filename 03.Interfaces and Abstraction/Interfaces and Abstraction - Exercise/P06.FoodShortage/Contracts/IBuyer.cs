namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }
    }
}
