namespace SmartphoneShop.Tests
{

    using System;

    using NUnit.Framework;

    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase("Nokia 3310", 100)]
        [TestCase("Huwaei P40", 1)]
        [TestCase("Huwaei P20", int.MaxValue)]
        public void Test_Smartphone_Constructor(string modelName, int maximumBatteryCharge)
        {
            Smartphone smartphone = new Smartphone(modelName, maximumBatteryCharge);
            Assert.That(smartphone != null && smartphone.ModelName == modelName &&
                        smartphone.MaximumBatteryCharge == maximumBatteryCharge &&
                        smartphone.CurrentBateryCharge == maximumBatteryCharge,
                        "The constructor does not create a smarphone with given values.");
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void Test_Shop_Constructor(int capacity)
        {
            Shop shop = new Shop(capacity);
            Assert.That(shop.Count == 0 && shop.Capacity == capacity,
                        "The constructor does not create a shop with given value.");
        }

        [TestCase(-1)]
        [TestCase(-123762)]
        [TestCase(int.MinValue)]
        public void Test_Shop_Count_Property_Must_Throw_Error(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Shop(capacity),
                        "The constructor does not create a smarphone with given values.");
        }

        [TestCase(1, "Nokia 5", 100, 1)]
        [TestCase(12312, "IPhone 11", int.MaxValue, 1)]
        public void Test_Shop_Add_Method_Must_Add_Phone_To_The_SHop(int shopCapacity,
            string phoneModelName, int maximumBatteryCharge, int expectedPhoneCount)
        {
            Shop shop = new Shop(shopCapacity);

            Smartphone smartphone = new Smartphone(phoneModelName, maximumBatteryCharge);
            shop.Add(smartphone);

            Assert.That(shop.Count == expectedPhoneCount,
                $"The add method does not works correcty. The count og phones in the shops must be {expectedPhoneCount}.");
        }

        [TestCase(1, "Nokia 3310", 100, "Xiaomi MIA1", 12345)]
        [TestCase(1, "IPhone 7", int.MaxValue, "SAMSUNG Note", 2213)]
        public void Test_Shop_Add_Method_Must_Throw_Error_Shop_Is_Full(int shopCapacity,
            string FistPhoneModelName, int FirstMaximumBatteryCharge,
            string SecondPhoneModelName, int secondPhoneMaximumBatteryCharge)
        {
            Shop shop = new Shop(shopCapacity);

            Smartphone smartphoneOne = new Smartphone(FistPhoneModelName, FirstMaximumBatteryCharge);
            Smartphone smartphoneTwo = new Smartphone(SecondPhoneModelName, secondPhoneMaximumBatteryCharge);
            shop.Add(smartphoneOne);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphoneTwo),
                $"Must throw error becase the shop is full.");
        }

        [TestCase(123124, "Nokia 3310", 100)]
        [TestCase(2, "IPhone 7", int.MaxValue)]
        public void Test_Shop_Add_Method_Must_Throw_Error_Existing_Model(int shopCapacity,
            string phoneModelName, int maximumBatteryCharge)
        {
            Shop shop = new Shop(shopCapacity);

            Smartphone smartphoneOne = new Smartphone(phoneModelName, maximumBatteryCharge);
            Smartphone smartphoneTwo = new Smartphone(phoneModelName, maximumBatteryCharge);
            shop.Add(smartphoneOne);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphoneTwo),
                $"Must throw error becase the phone already exist.");
        }

        [TestCase(3, "Nokia 3310", 100, "Xiaomi MIA1", 12345, 0)]
        [TestCase(12421412, "IPhone 7", int.MaxValue, "SAMSUNG Note", 2213, 0)]
        public void Test_Smhop_Remove_Method_Must_Remove_Phone_From_Shop(int shopCapacity,
            string FistPhoneModelName, int FirstMaximumBatteryCharge,
            string SecondPhoneModelName, int secondPhoneMaximumBatteryCharge,
            int expectedCount)
        {
            Shop shop = new Shop(shopCapacity);

            Smartphone smartphoneOne = new Smartphone(FistPhoneModelName, FirstMaximumBatteryCharge);
            Smartphone smartphoneTwo = new Smartphone(SecondPhoneModelName, secondPhoneMaximumBatteryCharge);
            shop.Add(smartphoneOne);
            shop.Add(smartphoneTwo);

            shop.Remove(smartphoneOne.ModelName);
            shop.Remove(smartphoneTwo.ModelName);

            Assert.That(shop.Count == expectedCount,
                        $"The method does not works correctly. The count of phone in the shop must be {expectedCount}.");
        }

        [TestCase(123124, "Nokia 3310", 100)]
        [TestCase(2, "IPhone 7", int.MaxValue)]
        public void Test_Shop_Remove_Method_Must_Throw_Error_Non_Existing_Model(int shopCapacity,
            string phoneModelName, int maximumBatteryCharge)
        {
            Shop shop = new Shop(shopCapacity);

            Smartphone smartphoneOne = new Smartphone(phoneModelName, maximumBatteryCharge);
            shop.Add(smartphoneOne);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Invalid phone model"),
                $"Must throw error becase the phone model does not exist in the shop.");
        }

        [TestCase("Nokia 3310", 100, 50)]
        [TestCase("Huwaei P40", 1255, 1)]
        [TestCase("Huwaei P20", int.MaxValue, 12412515)]
        public void Test_Shop_TestPhone_Method_Must_Reduce_BatteryLevel
            (string modelName, int maximumBatteryCharge, int batteryUsage)
        {
            int shopCapacity = 5;
            Shop shop = new Shop(shopCapacity);
            Smartphone smartphone = new Smartphone(modelName, maximumBatteryCharge);
            shop.Add(smartphone);
            int expectedResult = smartphone.CurrentBateryCharge - batteryUsage;

            shop.TestPhone(smartphone.ModelName, batteryUsage);

            Assert.That(smartphone.CurrentBateryCharge == expectedResult,
                       $"Wrong calculation. The battery level must be {expectedResult}");
        }

        [TestCase("Nokia 3310", 50, 100)]
        [TestCase("Huwaei P40", 1, 2)]
        public void Test_Shop_TestPhone_Method_Must_Throw_Error_Low_Battery
            (string modelName, int maximumBatteryCharge, int batteryUsage)
        {
            int shopCapacity = 5;
            Shop shop = new Shop(shopCapacity);
            Smartphone smartphone = new Smartphone(modelName, maximumBatteryCharge);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, batteryUsage),
                       $"Must throw error. The battery level is low.");
        }

        [Test]
        public void Test_Shop_TestPhone_Method_Must_Throw_Error_Non_Existing_Phone()
        {
            int shopCapacity = 5;
            int batteryUsage = 1;
            Shop shop = new Shop(shopCapacity);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", batteryUsage),
                       $"Must throw error. The model does not exist in the shop.");
        }

        [TestCase("Nokia 3310")]
        [TestCase("Huwaei P40")]
        public void Test_Shop_Charnge_Method_Must_Throw_Error_Non_Existing_Phone(string phoneModelName)
        {
            int shopCapacity = 5;
            Shop shop = new Shop(shopCapacity);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone(phoneModelName),
                       $"Must throw error. The model does not exist in the shop.");
        }


        [TestCase("Nokia 3310", 100)]
        [TestCase("Huwaei P40", int.MaxValue)]
        public void Test_Shop_Change_Method_Must_Fully_Charge_The_Given_Phone
            (string phoneModelName, int maximumBatteryCharge)
        {
            int shopCapacity = 5;
            Shop shop = new Shop(shopCapacity);
            Smartphone phone = new Smartphone(phoneModelName, maximumBatteryCharge);

            phone.CurrentBateryCharge = 5;
            shop.Add(phone);
            shop.ChargePhone(phoneModelName);

            Assert.That(phone.CurrentBateryCharge == maximumBatteryCharge,
                       $"The method does not works correctly. Must fully charge the given phone");
        }
    }
}