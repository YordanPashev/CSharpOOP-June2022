namespace CompositePattern
{
    internal class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price) { }

        public override decimal CalculateTotalPrice() => Price;
    }
}
