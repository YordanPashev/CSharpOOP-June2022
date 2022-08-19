namespace DatabaseExtended.Tests
{
    using System;
    using System.Linq;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person[] personsToAdd;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
            personsToAdd = new Person[5]
            {
                    new Person(long.MaxValue, "Shurenaikata Petq"),
                    new Person(int.MaxValue, "Baba Vuna"),
                    new Person(999_999, "Bulq Maria"),
                    new Person(1236786612, "Tedka mi Tanq"),
                    new Person(0, "Bacho Rosen") 
            };
        }

        [Test]
        public void Test_If_Constructor_Takes_An_Array_Of_Persons()
        {
            int expectedPersonsCount = personsToAdd.Length;

            database = new Database(personsToAdd);

            Assert.That(expectedPersonsCount == database.Count,
                "The Constructor does not returns the right Count of Persons.");
        }

        [Test]
        public void Test_If_Conctructor_Takes_More_Than_16_Persons_Should_Throw_Error()
        {
            Person[] arrayWithInvalidLength = new Person[17];

            Assert.Throws<ArgumentException>(()
                => database = new Database(arrayWithInvalidLength),
                "You are trying to add less than 17 persons.");
        }

        [Test]
        public void Test_If_Add_Method_Tries_To_Add_More_Than_16_Person_Should_Throw_Error()
        {
            Person[] personsToAdd = new Person[16];

            for (int i = 0; i < personsToAdd.Length; i++)
            {
                personsToAdd[i] = new Person(i, $"{(char)(i + 65)}");
            }

            database = new Database(personsToAdd);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(1255, "Stoyanchu")),
                "Your database has less than 16 persons." );
        }


        [Test]
        public void Test_If_Add_Method_Tries_To_Add_A_Person_With_Already_Existing_Name_Throw_Error()
        {
            database = new Database(personsToAdd);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(666, "Bacho Rosen")),
                "You are trying to add Person in database with non existing Name."
                );
        }

        [Test]
        public void Test_If_Add_Method_Tries_To_Add_A_Person_With_Already_Existing_Id_Throw_Error()
        {
            database = new Database(personsToAdd);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(long.MaxValue, "Komshiqta Ivan")),
                "You try to add Person in database with non existing Id.");
        }

        [Test]
        public void Test_If_Add_Method_Adds_A_Person_Counter_Should_Increase()
        {
            database = new Database(personsToAdd);

            database.Add(new Person(23456799, "Mecho Puh"));
            int expectedPersonCount = personsToAdd.Length + 1;

            Assert.That(expectedPersonCount == database.Count,
                "Something is worng. The Add Method does not returns the right Count of Persons.");       
        }

        [Test]
        public void Test_If_Remove_Method_Tries_To_Remove_A_Person_On_Empty_Database_Throw_Error()
        {
            Assert.Throws<InvalidOperationException>(()
                => database.Remove(),
                "You are trying to remove a Person while database is not empty.");
        }


        [Test]
        public void Test_If_Remove_Method_Removes_A_Person_Counter_Should_Decrease()
        {
            database = new Database(personsToAdd);

            database.Remove();
            int expectedPersonCount = personsToAdd.Length - 1;

            Assert.That(expectedPersonCount == database.Count,
                "The Remove Method does not returns the right Count of Persons.");
        }

        [Test]
        public void Test_If_FindByUsername_Method_Tries_To_Display_A_Person_Whitout_UserName()
        {
            database = new Database(personsToAdd);
            
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null),
                "You are trying to find a Person with a valid username.");
        }

        [Test]
        public void Test_If_FindByUsername_Method_Tries_To_Display_A_Non_Existing_Person()
        {
            database = new Database(personsToAdd);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Bacho Kolyo"),
                "You are trying to find a Person with an existing username.");
        }

        [Test]
        public void Test_If_FindByUsername_Method_Returns_A_Existing_Person()
        {
            Person person = new Person(0, "Bacho Rosen");
            database = new Database(person);
       
            Person personFromFindByUserName = database.FindByUsername("Bacho Rosen");

            Assert.That(personFromFindByUserName.UserName == person.UserName &&
                        personFromFindByUserName.Id == person.Id,
                "The FindByUsername method does not returns the correct object.");
        }

        [Test]
        public void Test_If_FindById_Method_Take_A_Negative_Id_Number_SHould_Throw_Error()
        {
            database = new Database(personsToAdd);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1),
                "You are trying to find a Person with positive Id number");
        }

        [Test]
        public void Test_If_FindById_Method_Tries_To_Return_A_Non_Existing_Id_Number_Should_Throw_Error()
        {
            database = new Database(personsToAdd);

            Assert.Throws<InvalidOperationException>(() => database.FindById(12312312545),
                 "You are trying to find a Person with an existing Id number");
        }

        [Test]
        public void Test_If_FindById_Method_Returns_A_Existing_Person()
        {
            Person person = new Person(0, "Bacho Rosen");

            database = new Database(person);

            Person personFromFindByIdMethod = database.FindById(0);

            Assert.That(personFromFindByIdMethod.UserName == person.UserName &&
                        personFromFindByIdMethod.Id == person.Id,
                "The FindById method does not returns the correct object");
        }
    }
}