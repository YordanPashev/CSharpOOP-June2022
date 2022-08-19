namespace INStock.Models.Porducts
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using INStock.Models.Contracts;

    public class ProductStock : IProductStock
    {

        private List<IProduct> products;

        public ProductStock(List<IProduct> products)
        {
            this.products = products;
        }

        public IProduct this[int index] => this.products.ToList()[index];

        IProduct IProductStock.this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Count => products.Count();

        public void Add(IProduct product) => this.products.Add(product);

        public bool Remove(IProduct product) => this.products.Remove(product);

        public bool Contains(IProduct product) =>
            this.products.Any(p => p == product);

        public IProduct Find(int index)
        {
            if (index < 0 || index >= products.Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            return this.products.ToList()[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
            => this.products.Where(p => p.Price == (decimal)price);

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => this.products.Where(p => p.Quantity == quantity);

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            IList <IProduct> productsInRange = new List<IProduct>();
            decimal low = (decimal)lo;
            decimal high = (decimal)hi;
            foreach (IProduct product in products.OrderByDescending(p => p.Price))
            {
                if (product.Price >= low && product.Price <= high)
                {
                    productsInRange.Add(product);
                }
            }

            return productsInRange;
        }

        public IProduct FindByLabel(string label)
            => this.products.FirstOrDefault(p => p.Label == label) ??
            throw new ArgumentException("No such product is in stock!");

        public IProduct FindMostExpensiveProduct()
        {
            return this.products.OrderByDescending(p => p.Price).ToList()[0];
        }

        public ICollection<IProduct> GetEnumerator() => this.products;

        IEnumerator IEnumerable.GetEnumerator()
            => throw new System.NotImplementedException();

        IEnumerator<IProduct> IEnumerable<IProduct>.GetEnumerator() 
            => throw new System.NotImplementedException();
    }
}
