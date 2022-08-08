using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {

        [TestFixture]
        public class RepairsShopTests
        {
            [TestCase("Golf", 1)]
            [TestCase("911", 0)]
            [TestCase("Veron", int.MaxValue)]
            public void Test_Is_Car_Constructors_Works(string carModel, int numberOfIssues)
            {
                Car car = new Car(carModel, numberOfIssues);

                Assert.That(car.CarModel == carModel &&
                            car.NumberOfIssues == numberOfIssues,
                            "Default constructor does not works correctly.");
            }

            [TestCase("Golf", 1)]
            [TestCase("911", 6612312)]
            [TestCase("Veron", int.MaxValue)]
            public void Test_Car_Property_IsFixet_Should_Returns_False(string carModel, int numberOfIssues)
            {
                Car car = new Car(carModel, numberOfIssues);

                Assert.That(car.IsFixed == false,
                            "Must return false because the value of numberOfIssues is bigger that 0.");
            }

            [TestCase("Golf", 0)]
            [TestCase("RV66", 0)]
            public void Test_Car_isFixet_Property_Should_Returns_True(string carModel, int numberOfIssues)
            {
                Car car = new Car(carModel, numberOfIssues);

                Assert.That(car.IsFixed == true,
                            "Must return true because the value of numberOfIssues is 0.");
            }

            [TestCase("Top Serviza na Kvartala", 161231)]
            [TestCase("Pri Bako Ivan", 1)]
            [TestCase("Avtomontior Super Razbivach", int.MaxValue)]
            public void Test_Is_Grage_Constructors_Works(string name, int mechanicsAvailable)
            {
                Garage garage = new Garage(name, mechanicsAvailable);

                Assert.That(garage.Name == name &&
                            garage.MechanicsAvailable == mechanicsAvailable &&
                            garage.CarsInGarage == 0,
                            "Must return true because the value of numberOfIssues is 0.");
            }

            [TestCase(null, 161231)]
            [TestCase("", 1)]
            public void Test_Garage_Property_Name_Must_Throw_Error(string name, int mechanicsAvailable)
            {
                Assert.Throws<ArgumentNullException>(() =>
                    new Garage(name, mechanicsAvailable),
                            "Must throw ArgumentNullException because the name is null or empty.");
            }

            [TestCase("Top Serviza na Kvartala", 0)]
            [TestCase("Ivaylo Conev - Diuzata", -1231876)]
            [TestCase("Pri Bako Ivan", -1)]
            [TestCase("Avtomontior Super Razbivach", int.MinValue)]
            public void Test_Garage_Propert_MechanicsAvailable_Must_Throw_Error(string name, int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() =>
                    new Garage(name, mechanicsAvailable),
                   "Must throw ArgumentException because number of mechanicsAvailable is 0 or less.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_AddCar_Must_Add_New_Cars_In_The_Garage_And_Return_Their_Count(string name, int mechanicsAvailable)
            {
                Garage garage = new Garage(name, mechanicsAvailable);
                Car firstCar = new Car ("Mazda 6", 95656541);
                Car secondCar = new Car("Mazda 5", 1);
                Car thirdCar = new Car("Mazda 6", int.MaxValue);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);

                int expectedCarsCount = 3;

                Assert.That(garage.CarsInGarage == expectedCarsCount,
                            $"Count of Car ing the Garage must be {expectedCarsCount}.");
            }

            [TestCase("Avtomontior Super Razbivach", 2)]
            [TestCase("Top Fear", 2)]

            public void Test_Garage_Method_AddCar_Must_Throw_Error(string name, int mechanicsAvailable)
            {
                Garage garage = new Garage(name, mechanicsAvailable);
                Car firstCar = new Car("Mazda 6", 95656541);
                Car secondCar = new Car("Mazda 5", 1);
                Car thirdCar = new Car("Mazda 6", int.MaxValue);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.Throws<InvalidOperationException>(() =>
                   garage.AddCar(thirdCar),
                   $"Must throw ArgumentException because cars count int the garage is bigger than available mechanics.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_FixCar_Must_Return_Fixed_Car_With_numberOfIssues_Zero(string name, int mechanicsAvailable)
            {
                int carsToAdd = 6;
                Garage garage = new Garage(name, mechanicsAvailable);
                for (int i = 1; i <= carsToAdd; i++)
                {
                    string carModel = $"BMW X{i}";
                    int numberOfIssues = i;

                    Car carToAdd = new Car(carModel, numberOfIssues);
                    garage.AddCar(carToAdd);
                }

                Car carToFix = new Car("BMW X5", 5);
                Car car = garage.FixCar(carToFix.CarModel.ToString());

                Assert.That(car.CarModel.ToString() == carToFix.CarModel.ToString() &&
                            car.NumberOfIssues == 0,
                            $"Mehotd does not woks correctly it must return car {carToFix.CarModel.ToString()}.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_FixCar_Must_Throw_Error(string name, int mechanicsAvailable)
            {
                int carsToAdd = 6;
                Garage garage = new Garage(name, mechanicsAvailable);
                for (int i = 1; i <= carsToAdd; i++)
                {
                    string carModel = $"BMW X{i}";
                    int numberOfIssues = i;

                    Car carToAdd = new Car(carModel, numberOfIssues);
                    garage.AddCar(carToAdd);
                }

                Car searchedCar = new Car("Simson V4", 5);

                 Assert.Throws<InvalidOperationException>(() =>
                    garage.FixCar(searchedCar.CarModel.ToString()),
                    $"Mehotd does not woks correctly. It must throw InvalidOperationException because there is no such a car in the garage.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_RemoveFixedCars_Must_Return_Count_Of_All_Fixed_Cars(string name, int mechanicsAvailable)
            {
                int carsToAdd = 6;
                Garage garage = new Garage(name, mechanicsAvailable);
                for (int i = 1; i <= carsToAdd; i++)
                {
                    string carModel = $"BMW X{i}";
                    int numberOfIssues = i;
                    
                    Car carToAdd = new Car(carModel, numberOfIssues);
                    garage.AddCar(carToAdd);
                }

                string firstCarModelTobeFixed = "BMW X5";
                string secondCarModelTobeFixed = "BMW X1";

                Car fixedCarNumberOne = garage.FixCar(firstCarModelTobeFixed);
                Car fixedCarNumberTwo = garage.FixCar(secondCarModelTobeFixed);

                int expectedFixedCarsCount = 2;

                Assert.That(garage.RemoveFixedCar() == expectedFixedCarsCount,
                   $"Mehotd does not woks correctly. Fixed cars count must be {expectedFixedCarsCount}.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_RemoveFixedCars_Must_Throw_Error(string name, int mechanicsAvailable)
            {
                int carsToAdd = 6;

                Garage garage = new Garage(name, mechanicsAvailable);
                for (int i = 1; i <= carsToAdd; i++)
                {
                    string carModel = $"BMW X{i}";
                    int numberOfIssues = i;

                    Car carToAdd = new Car(carModel, numberOfIssues);
                    garage.AddCar(carToAdd);
                }

                Assert.Throws<InvalidOperationException>(() => 
                        garage.RemoveFixedCar(),
                        $"Mehotd does not woks correctly. It must throw InvalidOperationException because there is no fixed cars in the garage.");
            }

            [TestCase("Top Serviza na Kvartala", 14412)]
            [TestCase("Avtomontior Super Razbivach", 555)]
            public void Test_Garage_Method_Report_Must_Return_Count_And_Names_Of_Non_Fixed_Cars(string name, int mechanicsAvailable)
            {
                List<string> expectedReport = new List<string>();
                int carsToAdd = 3;

                Garage garage = new Garage(name, mechanicsAvailable);
                for (int i = 1; i <= carsToAdd; i++)
                {
                    string carModel = $"BMW X{i}";
                    int numberOfIssues = i;
                    
                    Car carToAdd = new Car(carModel, numberOfIssues);
                    expectedReport.Add(carToAdd.CarModel.ToString());
                    garage.AddCar(carToAdd);
                }

                string carsNames = string.Join(", ", expectedReport);
                string expectedResult = $"There are {expectedReport.Count} which are not fixed: {carsNames}.";

                Assert.That(garage.Report() == expectedResult,
                        $"Mehotd does not woks correctl. It does not reutnr the correct count of non fixed cars and their names.");
            }
        }
    }
}