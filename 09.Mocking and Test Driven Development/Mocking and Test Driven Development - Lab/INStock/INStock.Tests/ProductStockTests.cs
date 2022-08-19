namespace INStock.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    using INStock.Models.Contracts;
    using INStock.Models.Porducts;
    using System.Text;

    [TestFixture]
    public class ProductStockTests
    {
        [Test]
        public void Test_Constructor()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            Assert.IsNotNull(products);
            Assert.That(products.Count == 3,
                "The constructor does not create a ProductStock with given values.");
        }

        [Test]
        public void Test_Add_Method_Shoud_Add_New_Product()
        {
            ProductStock products = new ProductStock(new List<IProduct>());
            Product product = new Product("Praz", 1.50m, 11);

            products.Add(product);

            Assert.That(products.Count == 1,
                "The Add Method does not add new product to the collection.");
        }

        [Test]
        public void Test_Add_Method_Shoud_Remove_Chosen_Product()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            Product product = new Product("Praz", 1.50m, 11);
            products.Add(product);

            products.Remove(product);

            Assert.That(products.Count == 3,
                "The Remove Method does not remove the chose product.");
        }

        [Test]
        public void Test_Contains_Method_Must_Return_True()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            Product product = new Product("Praz", 1.50m, 11);
            products.Add(product);
            bool expectedResult = true;

            bool actualResult = products.Contains(product);

            Assert.That(actualResult == expectedResult,
               "The result must be true because the product exist in the collection.");
        }

        [Test]
        public void Test_Contains_Method_Must_Return_False()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            Product product = new Product("Praz", 1.50m, 11);
            bool expectedResult = false;

            bool actualResult = products.Contains(product);

            Assert.That(actualResult == expectedResult,
                "The result must be false because the product does not exist in the collection.");
        }

        [Test]
        public void Test_Find_Method_Must_Return_Poruct()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            Product product = new Product("Praz", 1.50m, 11);
            products.Add(product);

            IProduct resultProduct = products.Find(3);

            Assert.AreEqual(product, resultProduct,
                $"The method shoud return product with Label: {product.Label} and Pricec: {product.Price}");
        }

        [Test]
        public void Test_Find_Method_Must_Throw_Error()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Oriz", 3.50m, 11),
                new Product("Bob", 2.50m, 7),
                new Product("Leshta", 2.70m, 1)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);

            Assert.Throws<IndexOutOfRangeException>(() => products.Find(333),
                $"Must throw error because the index is out of range.");
        }

        [Test]
        public void Test_FindAllByPrice_Must_Return_List_Of_Products_With_Given_Price()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Bob", 2.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Label: Oriz, Price: 3.50";

            IEnumerable<IProduct> resultProducts = products.FindAllByPrice(3.50);

            StringBuilder actualResult = new StringBuilder();

            foreach (var product in resultProducts)
            {
                actualResult.AppendLine($"Label: {product.Label}, Price: {product.Price}");
            }

            Assert.That(actualResult.ToString().TrimEnd() == expectedResult,
              $"The Method does not work correctly. Expected Result: {Environment.NewLine} {expectedResult}.");

        }

        [Test]
        public void Test_FindAllByQuantity_Must_Return_List_Of_Products_With_Given_Quantity()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Bob", 2.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Label: Oriz, Price: 3.50" + Environment.NewLine +
                                    $"Label: Praz, Price: 1.50";

            IEnumerable<IProduct> resultProducts = products.FindAllByQuantity(11);

            StringBuilder actualResult = new StringBuilder();

            foreach (var product in resultProducts)
            {
                actualResult.AppendLine($"Label: {product.Label}, Price: {product.Price}");
            }

            Assert.That(actualResult.ToString().TrimEnd() == expectedResult,
                $"The Method does not work correctly. Expected Result: {Environment.NewLine} {expectedResult}.");
        }

        [Test]
        public void Test_FindAllInRange_Must_Return_List_Of_Products_In_Given_Range()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Bob", 2.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Label: Oriz, Price: 3.50" + Environment.NewLine +
                                    $"Label: Bob, Price: 2.50";

            IEnumerable<IProduct> resultProducts = products.FindAllInRange(2.50, 3.50);

            StringBuilder actualResult = new StringBuilder();

            foreach (var product in resultProducts)
            {
                actualResult.AppendLine($"Label: {product.Label}, Price: {product.Price}");
            }
            Assert.That(actualResult.ToString().TrimEnd() == expectedResult,
                $"The Method does not work correctly. Expected Result: {Environment.NewLine} {expectedResult}.");
        }

        [Test]
        public void Test_FindByLabel_Must_Return_Product_With_Given_Label()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Bob", 2.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Oriz";

            IProduct resultProduct = products.FindByLabel("Oriz");

            string actualResult = resultProduct.Label;
            Assert.That(actualResult == expectedResult,
                $"The Method does not work correctly. Expected Result: {expectedResult}.");
        }

        [Test]
        public void Test_FindByLabel_Must_Throw_Error()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Bob", 2.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Oriz";

             Assert.Throws<ArgumentException>(() =>products.FindByLabel("Mekichki"),
                "Must return error because there is no such product is in stock!");
        }

        [Test]
        public void Test_FindMostExpensiveProducts_Must_Return_Product_With_Given_Label()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Tivichki", 5.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };

            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Tivichki -> 5.50";
            IProduct resultProduct = products.FindMostExpensiveProduct();
            string actualResult = $"{resultProduct.Label} -> {resultProduct.Price}";

            Assert.That(actualResult == expectedResult,
                $"The Method does not work correctly. Expected Result: {expectedResult}.");
        }

        [Test]
        public void Test_Indexer_Must_Return_Product_On_Given_Index()
        {
            List<IProduct> listOfInitialProducts = new List<IProduct>
            {
                new Product("Tivichki", 5.50m, 7),
                new Product("Oriz", 3.50m, 11),
                new Product("Leshta", 1.70m, 1),
                new Product("Praz", 1.50m, 11)
            };
            int productIndex = 0;
            ProductStock products = new ProductStock(listOfInitialProducts);
            string expectedResult = $"Tivichki -> 5.50";
            string actualResult = $"{products[productIndex].Label} -> {products[productIndex].Price}";

            Assert.That(actualResult == expectedResult,
                $"The Method does not work correctly. Expected Result: {expectedResult}.");
        }
    }
}
