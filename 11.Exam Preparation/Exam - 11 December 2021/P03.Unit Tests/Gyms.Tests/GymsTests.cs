namespace Gyms.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {

        [TestCase("Pienchu")]
        [TestCase("Versache")]
        [TestCase("Bako Ivan")]
        public void Test_Athlete_Constructors_Works_Correctly(string athleteFullName)
        {
            string expectedAthleteFullName = athleteFullName;
            Athlete athlete = new Athlete(athleteFullName);

            Assert.That(athlete.FullName == athleteFullName &&
                        athlete.IsInjured == false,
                        $"Constructor does not works properly. The athlet should have FullName: {expectedAthleteFullName} and IsInjured = false.");
        }

        [TestCase("Samo za Batki i Nacepenqci", 22)]
        [TestCase("No pain no gain", int.MaxValue)]
        [TestCase("Ligth weight, baby", 1)]
        public void Test_Gym_Constructors_Works_Correctly(string gymName, int size)
        {
            Gym gym = new Gym(gymName, size);

            Assert.That(gym.Name == gymName && gym.Capacity == size &&
                        gym.Count == 0,
                        $"Constructor does not works properly. The gym should have Name: {gymName} and Capacity: {size}.");
        }

        [TestCase(null, int.MaxValue)]
        [TestCase("", 1)]
        public void Test_Gym_Property_Name_Must_Throw_Error(string gymName, int size)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(gymName, size),
                        "Must throw error because the name of the gym can not be null or empty.");
        }

        [TestCase("Samo za Batki i Nacepenqci", -1231276)]
        [TestCase("No pain no gain", int.MinValue)]
        [TestCase("Ligth weight, baby", -1)]
        public void Test_Gym_Property_Capacity_Must_Throw_Error(string gymName, int size)
        {
            Assert.Throws<ArgumentException>(() => new Gym(gymName, size),
                "Must throw error because the capacity of the gym can not be 0.");
        }

        [TestCase("No pain no gain", int.MaxValue)]
        [TestCase("Ligth weight, baby", 3)]
        public void Test_Gym_Property_Count_Must_Return_Right_Count_Of_All_Gym_Athletes(string gymName, int size)
        {
            int expectedAthletesCount = 3;

            Gym gym = new Gym(gymName, size);
            Athlete athleteOne = new Athlete("Versacki");
            Athlete athleteTwo = new Athlete("Lelq Cecka");
            Athlete athleteThree = new Athlete("Dimitrichko");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.AddAthlete(athleteThree);

            Assert.That(gym.Count == expectedAthletesCount,
                $"The right count of all athletes in the gym must be {expectedAthletesCount}.");
        }

        [TestCase("No pain no gain", int.MaxValue)]
        [TestCase("Ligth weight, baby", 2)]
        public void Test_Gym_Method_AddAthlete_Must_Add_New_Athlete_To_The_Gym(string gymName, int size)
        {
            int expectedAthletesCount = 2;

            Gym gym = new Gym(gymName, size);
            Athlete athleteOne = new Athlete("Baba Ivana");
            Athlete athleteTwo = new Athlete("Lelq Cecka");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.That(gym.Count == expectedAthletesCount,
                $"The right count of all athletes in the gym must be {expectedAthletesCount}.");
        }

        [TestCase("Bez zob si prosto mikrob", 2)]
        public void Test_Gym_Method_AddAthlete_Must_Throw_Error(string gymName, int size)
        {
            Gym gym = new Gym(gymName, size);
            Athlete athleteOne = new Athlete("Versacki");
            Athlete athleteTwo = new Athlete("Lelq Cecka");
            Athlete athleteThree = new Athlete("Dimitrichko");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athleteThree),
                $"Must throw error because the gym is full (capacity is equal to the athletes in hte gym).");
        }

        [TestCase("Ligth weight, baby", 12412421)]
        public void Test_Gym_Method_RemoveAthlete_Must_Remove_The_Chosen_Athlete(string gymName, int size)
        {
            Gym gym = new Gym(gymName, size);
            Athlete athleteOne = new Athlete("Versacki");
            Athlete athleteTwo = new Athlete("Lelq Cecka");
            Athlete athleteThree = new Athlete("Dimitrichko");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.AddAthlete(athleteThree);

            gym.RemoveAthlete(athleteTwo.FullName);
            gym.RemoveAthlete(athleteOne.FullName);
            int expectedAthletesLeftInTheGym = 1;

            Assert.That(gym.Count == expectedAthletesLeftInTheGym,
                        $"The count of athletes left in the gym is wrong. It must be {expectedAthletesLeftInTheGym}.");
        }

        [TestCase("Bez preparati nqma rezultati", 12412421)]
        public void Test_Gym_Method_RemoveAthlete_Must_Throw_Error(string gymName, int size)
        {
            Gym gym = new Gym(gymName, size);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Bako Ivan"),
                        $"Must throw error because there is no Athlete with this name in the gym.");
        }

        [TestCase("Versacki")]
        [TestCase("Shureq Petko")]
        public void Test_Gym_Method_InjureAthlete_Must_Change_InjureStatus_Of_The_Chosen_Athlete(string athleteName)
        {
            Gym gym = new Gym("Ako si chist si prosto glist", 15);
            Athlete athlete = new Athlete(athleteName);
            gym.AddAthlete(athlete);
            athlete = gym.InjureAthlete(athlete.FullName);
            Assert.That(athlete.IsInjured == true,
                        $"The Injure Status of the athlete must be true");
        }

        public void Test_Gym_Method_InjureAthlete_Must_Throw_Error()
        {
            Gym gym = new Gym("Ako si chist si prosto glist", 15);
            
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Bulq Docka"),
                        $"Must throw error because there is no Athlete with this name in the gym.");
        }

        [TestCase("Bez preparati nqma rezultati", 1512)]
        [TestCase("Tuk trenirat samo manqci chisti kato Risliskte ezera", 1512)]
        public void Test_Gym_Method_Repor_Return_Info_For_All_Athletes_In_The_Gym(string gymName, int size)
        {
            Gym gym = new Gym(gymName, size);
            Athlete athleteOne = new Athlete("Versacki");
            Athlete athleteTwo = new Athlete("Lelq Cecka");
            Athlete athleteThree = new Athlete("Dimitrichko");

            gym.AddAthlete(athleteOne);
            gym.AddAthlete(athleteTwo);
            gym.AddAthlete(athleteThree);

            string athleteNames = string.Join(", ", new string[] { "Versacki", "Lelq Cecka", "Dimitrichko"});
            string expectedReportResult = $"Active athletes at {gym.Name}: {athleteNames}";
            Assert.That(expectedReportResult == gym.Report(),
                        $"Something is missing. The method does not return the right information about each athlete in the gym.");
        }
    }
}
