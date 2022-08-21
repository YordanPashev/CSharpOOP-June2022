namespace CompositePattern
{
    public abstract class GiftBase
    {
        private string name;
        private decimal price;

        public GiftBase(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get => this.name;
            set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The name can not be null or empty string.");
                }

                this.name = value;
            }
        }

        public decimal Price 
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"The price can not be negative number");
                }

                this.price = value;
            }
        }

        public abstract decimal CalculateTotalPrice();

        public override string ToString()
            => $"{this.Name} | Price: {this.Price:F2}";
    }
}
