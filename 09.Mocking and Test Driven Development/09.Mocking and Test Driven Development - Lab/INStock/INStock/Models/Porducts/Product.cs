namespace INStock.Models.Porducts
{

    using System;
    using System.Diagnostics.CodeAnalysis;

    using INStock.Models.Contracts;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label 
        { 
            get => this.label;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Label cannot be null, empty or white space!");
                }

                this.label = value;
            } 
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price can not be negative number!");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity can not be negative number!");
                }

                this.quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (other.Label == this.Label && other.Price == this.Price)
            {
                return 0;
            }

            return -1;
        }
    }
}
