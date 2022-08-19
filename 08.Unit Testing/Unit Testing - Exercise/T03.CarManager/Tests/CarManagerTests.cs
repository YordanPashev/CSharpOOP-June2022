namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {

        [TestCase("VW", "Golf", 6, 40)]
        [TestCase("Porshe", "911", 10, 60)]
        [TestCase("Bugatti", "Veron", 18, 100)]
        public void Test_Is_Default_Constructors_Works(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.FuelAmount == 0,
                "Default constructor does not set default value for FuelAmount correctly (it should be 0 by default).");
        }

        [TestCase("VW", "Golf", 6, 1)]
        [TestCase("VW", "Passat", 1, double.MaxValue)]
        [TestCase("Porshe", "911", double.MaxValue, 60)]
        public void Test_If_Public_Constructors_And_All_Properties_Getters_Works(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(make == car.Make && model == car.Model &&
                        fuelConsumption == car.FuelConsumption && fuelCapacity == car.FuelCapacity &&
                        car.FuelAmount == 0,
                        "The constructor does not set all values correctly.");
        }

        [TestCase("", "Golf", 6, 40)]
        [TestCase(null, "P", 8, 60)]
        [TestCase("", "7", 15, 80)]
        public void Test_If_Make_Property_Tries_To_Set_Null_Or_Empty_Value_Should_Throw_Error(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            "You are trying to set valid make value");
        }

        [TestCase("V", "", 6, 40)]
        [TestCase("Seat", null, 8, 60)]
        [TestCase("Dacia", "", 15, 80)]
        public void Test_If_Model_Property_Tries_To_Set_Null_Or_Empty_Value_Should_Throw_Error(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            "You are trying to set valid model value");
        }

        [TestCase("VW", "Golf", 0, 1)]
        [TestCase("VW", "Passat", double.MinValue, double.MaxValue)]
        [TestCase("Porshe", "911", -3.14, 60)]
        public void Test_If_FuelConsumption_Property_Tries_To_Set_Null_Or_Empty_Value_Should_Throw_Error(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            "You are trying to set a positive fuelConsuption value");
        }

        [TestCase("VW", "Golf", 1, 0)]
        [TestCase("VW", "Passat", double.MaxValue, double.MinValue)]
        [TestCase("Porshe", "911", 3.14, -3.14)]
        public void Test_If_FuelCapacity_Property_Tries_To_Set_Null_Or_Empty_Value_Should_Throw_Error(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            "You are trying to set positive fuelCapacity value");
        }


        [TestCase("VW", "Golf", 6, 40, 40)]
        [TestCase("Porshe", "911", 10, 60, 3.14)]
        [TestCase("Bugatti", "Veron", 18, 100, 0.1)]
        public void Test_If_Refuel_Method_Works(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.That(fuelToRefuel == car.FuelAmount,
            "You are trying to refuel with negative value");
        }

        [TestCase("VW", "Golf", 6, 40, -1)]
        [TestCase("Porshe", "911", 10, 60, double.MinValue)]
        [TestCase("Bugatti", "Veron", 18, 100, 0)]
        [TestCase("Mazda", "6", 8, 40, -0.01)]
        public void Test_If_Refuel_Method_Tries_To_Refuel_With_Negative_Value_Or_Zero(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel),
            "You are trying to refuel with positive value");
        }

        [TestCase("VW", "Golf", 6, 40, 100)]
        [TestCase("Porshe", "911", 10, 60, double.MaxValue)]
        [TestCase("Bugatti", "Veron", 15, 0.5, 1)]
        [TestCase("Mazda", "6", 18, 0.01, 0.01)]
        public void Test_If_Refuel_Method_Tries_To_Fill_More_Fuel_Of_Car_Capacity_Should_Set_Max_Allowed_FuelAmount(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount == car.FuelCapacity,
            "You are trying to refuel with an amount not enough to fill up the tank");
        }

        [TestCase("VW", "Golf", 6, 40, 40, 0)]
        [TestCase("Porshe", "911", 10, 60, double.MaxValue, 5)]
        [TestCase("Bugatti", "Veron", 15, 100, 10, 1)]
        [TestCase("Mazda", "6", 18, 60, 5, 0.01)]
        public void Test_If_Drive_Method_Works(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);
            double expectedFuelAmountAfterDrive = car.FuelAmount - ((distance / 100) * car.FuelConsumption);

            car.Drive(distance);

            Assert.That(expectedFuelAmountAfterDrive == car.FuelAmount,
                        $"Drive method does not returns the right fuel amount after drive.");
        }

        [TestCase("VW", "Golf", 6, 40, 0.01, 1)]
        [TestCase("Porshe", "911", 10, 60, 1, double.MaxValue)]
        [TestCase("Bugatti", "Veron", 15, 100, 0.01, 3.14)]
        [TestCase("Mazda", "6", 18, 60, 5, 1298471827)]
        public void Test_If_Car_Does_Not_Have_Enough_To_Drive_Should_Throw_An_Error(string make, string model, double fuelConsumption, double fuelCapacity, double fuelToRefuel, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance),
                        $"Drive method does not returns the right fuel amount after drive.");
        }
    }
}