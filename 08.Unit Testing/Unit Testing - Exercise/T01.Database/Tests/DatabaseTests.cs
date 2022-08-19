namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void Test_Array_Constructor_If_Its_Try_To_Take_More_Than_16_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(()
                => database = new Database(new int[17]),
                "You try to add less than 17 elements.");
        }

        [Test]
        public void Test_Array_If_Its_Add_Method_Adds_Element_At_The_Next_Free_Cell()
        {
            int numberOfElementsToAdd = 3;
            database.Add(1);
            database.Add(2);
            int elemetnsToAddAndCheck = 123;
            database.Add(elemetnsToAddAndCheck);
            int[] arrayCopy = database.Fetch();
            int lastIndex = arrayCopy.Length - 1;
            Assert.That(arrayCopy[lastIndex] == elemetnsToAddAndCheck && arrayCopy.Length == numberOfElementsToAdd,
                "Something is wrong. Add Method is not adding elements correctly.");
        }

        [Test]
        public void Test_Array_If_Its_Add_Method_Tries_To_Add_More_Than_16_Elements_Throw_Error()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(()
                => database.Add(1), "You try to add less than 17 elements.");
        }

        [Test]
        public void Test_Array_If_Its_Remove_Method_Removing_Last_Element()
        {
            int numberOfElementToAdd = 8;
            for (int i = 0; i < numberOfElementToAdd; i++)
            {
                database.Add(i);
            }

            int lastElementValue = numberOfElementToAdd;
            database.Remove();
            int[] arrayCopy = database.Fetch();
            int databaseLength = numberOfElementToAdd - 1;
            int lastIndex = arrayCopy.Length - 1;
            Assert.That(databaseLength == database.Count && !(arrayCopy.Contains(lastElementValue)),
                "Something wrong. Removing method is not removing elements correctly.");
        }

        [Test]
        public void Test_Array_If_Its_Removing_Method_Tries_To_Remove_Elements_When_Database_Is_Empty_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(() 
                => database.Remove(), "You are trying to remove an element in non empty array.");
        }

        [Test]
        public void Test_Array__Its_Fetch_Method_Returns_The_Elements_Of_The_Array()
        {
            int[] testArray = new int[3] { 15, -25, 0};
            database = new Database(testArray);
            Assert.That(testArray, Is.EquivalentTo(database.Fetch()), 
                "Array is not equal to the testArray.");
        }

        [Test]
        public void Test_Array_Constructor_Its_Should_Take_Arr_Of_Integer()
        {
            int[] testArray = new int[2] { 1, 0 };
            database = new Database(testArray);
            Assert.That(testArray.Length == database.Count,
                "Constructor do not take the element correctly.");
        }
    }
}
