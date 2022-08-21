namespace CompositePattern
{

    using System.Text;


    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => this.gifts.Add(gift);

        public IReadOnlyCollection<GiftBase> Gifts => this.gifts;

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (GiftBase gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }   

            return totalPrice + this.Price;
        }


        public void Remove(GiftBase gift) => this.gifts.Remove(gift);

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
           //result.AppendLine(base.ToString());
            result.AppendLine($"Basket: {this.Name} | Price: {this.Price:F2} with product {this.gifts.Count} products");

            foreach (GiftBase gift in Gifts)
            {
                result.AppendLine(gift.ToString().TrimEnd());
            }


            return result.ToString().TrimEnd();
        }
    }
}
