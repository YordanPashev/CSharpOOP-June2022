namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [TestCase("Dimitrichka")]
        [TestCase("Ribata Cecka")]
        public void Test_Fish_Constructor_Must_Create_A_Fish(string fishName)
        {
            Fish fish = new Fish(fishName);

            Assert.That(fish != null && fish.Name == fishName &&
                        fish.Available,
                        "The onstructor does not create a fish with given name and initial available status.");
        }

        [TestCase("Morski Rai", 0)]
        [TestCase("Domyt na Poseidon", int.MaxValue)]
        [TestCase("Akvariumyt", 1)]
        public void Test_Aquarium_Constructor_Must_Create_An_Aquarium(string aquariumName, int capacity)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);

            Assert.That(aquarium != null && aquarium.Name == aquariumName &&
                        aquarium.Capacity == capacity ,
                        "The onstructor does not create an aquarium with given values.");
        }

        [TestCase("", 3)]
        [TestCase(null, 15)]
        public void Test_Aquarium_Name_Must_Throw_Error(string aquariumName, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(aquariumName, capacity),
                        "The given name is valid.");
        }

        [TestCase("Morski Rai", -1)]
        [TestCase("Domyt na Poseidon", int.MinValue)]
        [TestCase("Akvariumyt", -123761247)]
        public void Test_Aquarium_Capacity_Must_Throw_Error(string aquariumName, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(aquariumName, capacity),
                        "The given capacity is valid.");
        }

        [TestCase("Domyt na Poseidon", 5, "Puhi", "Peshkata", 2)]
        public void Test_Aquarium_Count_Must_Return_The_Number_Of_All_Fishes_In_The_Aquarium
            (string aquariumName, int capacity, string firstFishName, 
            string secondFishName, int expectedCount)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);

            Fish fishOne = new Fish(firstFishName);
            Fish fishTwo = new Fish(secondFishName);
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            Assert.That(aquarium.Count == expectedCount,
                        $"The count is not right. It must be {expectedCount}.");
        }

        [TestCase("Morski Rai", 3, 3)]
        [TestCase("Domyt na Poseidon", 7, 3)]
        public void Test_Aquarium_Add_Method_Must_Add_Fishes_To_The_List
            (string aquariumName, int capacity, int expectedCount)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("Pena");
            Fish fishTwo = new Fish("RibchU");
            Fish fishThree = new Fish("NemU");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            aquarium.Add(fishThree);

            Assert.That(aquarium.Count == expectedCount,
                        $"The Add method does not works correctly. The fishes in the aquarium must be {expectedCount}.");
        }

        [TestCase("Morski Rai", 2, 3)]
        public void Test_Aquarium_Add_Method_Must_Throw_Error
            (string aquariumName, int capacity, int expectedCount)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("Pena");
            Fish fishTwo = new Fish("RibchU");
            Fish fishThree = new Fish("NemU");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fishThree),
            $"Expected InvalidOperationException because the fish in the aquarium can not be more that {capacity}.");
        }

        [TestCase("Morski Rai", 3, 1)]
        public void Test_Aquarium_Remove_Method_Must_Remove_Fishes_From_The_List
            (string aquariumName, int capacity, int expectedCount)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("Pena");
            Fish fishTwo = new Fish("RibchU");
            Fish fishThree = new Fish("NemU");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            aquarium.Add(fishThree);

            aquarium.RemoveFish(fishOne.Name);
            aquarium.RemoveFish(fishTwo.Name);


            Assert.That(aquarium.Count == expectedCount,
                        $"The Remove method does not works correctly. The fishes left in the aquarium must be {expectedCount}.");
        }

        [TestCase("Morski Rai", 2)]
        public void Test_Aquarium_Remove_Method_Must_Throw_Error
            (string aquariumName, int capacity)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("RibchU");

            aquarium.Add(fishOne);
            aquarium.RemoveFish(fishOne.Name);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nqkva izmislena riba det vaobshte q nqma na toq svqt"),
            $"Expected InvalidOperationException because the there is no fishes left in the aquarium.");
        }

        [TestCase("Morski Rai", 3)]
        public void Test_Aquarium_SelfFish_Method_Must_Change_Fish_Avaiable_Status_To_False
            (string aquariumName, int capacity)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("NemU");
            Fish fishTwo = new Fish("RibchU");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            Fish fish = aquarium.SellFish(fishOne.Name);


            Assert.That(!fish.Available,
                        $"The SelfFish method does not works correctly. The fishes change the avaibale status of the fish.");
        }

        [TestCase("Morski Rai", 2)]
        public void Test_Aquarium_SelfFish_Method_Must_Throw_Error
            (string aquariumName, int capacity)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("NemU");
            Fish fishTwo = new Fish("RibchU");

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fishTwo.Name),
            $"Expected InvalidOperationException because the there is no fishes with the given name in the aquarium");
        }

        [TestCase("Morski Rai", 2)]
        public void Test_Aquarium_Report_Method_Must_Return__Full_Info
            (string aquariumName, int capacity)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fishOne = new Fish("NemU");
            Fish fishTwo = new Fish("RibchU");

            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            string[] expectedFishNames = new string[] { "NemU", "RibchU" };
            string expectedReportResult = $"Fish available at {aquarium.Name}: {string.Join(", ", expectedFishNames)}";
            Assert.That(aquarium.Report() == expectedReportResult,
                        $"The result is wrong. Expected result {expectedReportResult}");
        }
    }
}
