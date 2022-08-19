namespace INStock.Tests
{
    using System;

    using NUnit.Framework;

    using INStock.Models.Porducts;

    [TestFixture]
    public class ProductTests
    {

        [TestCase("Blizalka", 0, 0)]
        [TestCase("Mechki", 1.50, int.MaxValue)]
        public void Test_Constructor(string label, decimal price, int quantity)
        {
            Product product = new Product(label, price, quantity);

            Assert.That(product != null && product.Label == label &&
                        product.Price == price && product.Quantity == quantity,
                        "The constructor does not create a new product with given values.");
        }

        [TestCase("", 1, 0)]
        [TestCase(" ", 12312746, int.MaxValue)]
        [TestCase(null, 5, 12764)]

        public void Test_Label_Must_Throw_Error(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentNullException>(() => new Product(label, price, quantity),
                        "Must throw error because the Label can not be null or white space.");
        }

        [TestCase("Blizalka", -1, 0)]
        [TestCase("Mechki", -12312746, int.MaxValue)]
        public void Test_Price_Must_Throw_Error(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity),
                        "Must throw error because the Price can not be negative");
        }

        [TestCase("Blizalka", 0, -1)]
        [TestCase("Mechki", 1, int.MinValue)]
        public void Test_Quantity_Must_Throw_Error(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity),
                        "Must throw error because the Quantity can not be negative");
        }

        [TestCase("Blizalka", 0, 1)]
        public void Test_Compare_Method_Must_Return_True(string label, decimal price, int quantity)
        {
            Product productOne = new Product(label, price, quantity);
            Product productTwo = new Product(label, price, quantity);

            Assert.That(productOne.CompareTo(productTwo) == 0,
                       "Must return true because the two products are equal.");
        }

        [TestCase("Blizalka", 0, 1)]
        public void Test_Compare_Method_Must_Return_False(string label, decimal price, int quantity)
        {
            Product productOne = new Product(label, price, quantity);
            Product productTwo = new Product("Mekichki", 1.50m, 1);

            Assert.That(productOne.CompareTo(productTwo) != 0,
                       "Must return false because the two products are not equal."););
        }
    }
}