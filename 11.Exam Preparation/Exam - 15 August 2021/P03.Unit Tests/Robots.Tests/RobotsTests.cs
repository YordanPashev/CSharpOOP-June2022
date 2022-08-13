namespace Robots.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        [TestCase("Robokop", 1)]
        [TestCase("Terminator", int.MaxValue)]
        public void Test_Robot_Constructor_Must_Create_A_New_Robot(string name, int maximumBattery)
        {
            Robot robot = new Robot(name, maximumBattery);

            Assert.That(robot != null && robot.Name == name &&
                        robot.MaximumBattery == maximumBattery &&
                        robot.Battery == maximumBattery,
                        "The constructor does not create a Robot with the given values.");
        }

        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void Test_RobotManager_Constructor_Must_Create_A_New_Manager(int capacity)
        {
            RobotManager robotManager = new RobotManager(capacity);

            Assert.That(robotManager != null && robotManager.Capacity == capacity &&
                        robotManager.Count == 0,
                        "The constructor does not create a Robot Manager with the given values.");
        }

        [TestCase(-1)]
        [TestCase(-11232)]
        [TestCase(int.MinValue)]
        public void Test_RobotManager_Constructor_Must_Throw_Error_For_Negative_Capacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity),
                        "The capacity can not be less than 0.");
        }

        [TestCase("Robokop", 1, 1)]
        [TestCase("Terminator", 12412, 124124321)]
        public void Test_Add_Method_Must_Add_New_Robot_To_The_Collection
            (string name, int maximumBattery, int capacity)
        {
            int expectedCount = 1;
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);

            robotManager.Add(robot);

            Assert.That(robotManager.Count == expectedCount,
                        "The add method does not add robots to the collection.");;
        }

        [TestCase("Robokop", 1, 1)]
        [TestCase("Terminator", 12412, 124124321)]
        public void Test_Add_Method_Must_Throw_Error_Robot_Already_Exist_In_The_Collection
           (string name, int maximumBattery, int capacity)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot),
                        "Must throw error because the robot already exist in the collection.");
        }

        [TestCase("Robokop", 1, 1)]
        [TestCase("Terminator", 12412, 1)]
        public void Test_Add_Method_Must_Throw_Error_Not_Enough_Capacity
           (string name, int maximumBattery, int capacity)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot),
                        "Must throw error because the collection is full.");
        }


        [TestCase("Robokop", 1, 1)]
        [TestCase("Terminator", 12412, 1312)]
        public void Test_Add_Method_Must_Remove_Chosen_Robot_From_The_Collection
            (string name, int maximumBattery, int capacity)
        {
            int expectedCount = 0;
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);

            robotManager.Add(robot);
            robotManager.Remove(robot.Name);

            Assert.That(robotManager.Count == expectedCount,
                        "The remove method does not remove chosen robot from the collection."); ;
        }

        [TestCase("Robokop", 1, 2,  "Pena")]
        [TestCase("Terminator", 12412, 5, "Spiro")]
        public void Test_Remove_Method_Must_Throw_Error_Non_Existing_Robot
           (string name, int maximumBattery, int capacity, string fakeRobotName)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robotOne = new Robot(name, maximumBattery);


            robotManager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(fakeRobotName),
                        "Must throw error because the robot dose not exist in the collection.");
        }

        [TestCase("Robokop", 1, 3, 1)]
        [TestCase("Terminator", 12412, 1312, 124)]
        public void Test_Work_Method_Must_Decrease_Chosen_Robot_Battery
            (string name, int maximumBattery, int capacity, int batteryUsage)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);
            int expcetedResult = robot.Battery - batteryUsage;
            string robotJob = "Teacher";

            robotManager.Add(robot);
            robotManager.Work(name, robotJob, batteryUsage);

            Assert.That(robot.Battery == expcetedResult,
                        "The work method does not decrease the chosen Robot's battery."); ;
        }

        [TestCase("Robokop", 1, 3, 2)]
        [TestCase("Terminator", 124, 1312, int.MaxValue)]
        public void Test_Work_Method_Must_Throw_Error_Non_Existing_Robot
            (string name, int maximumBattery, int capacity, int batteryUsage)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);
            int expcetedResult = robot.Battery - batteryUsage;
            string robotJob = "Teacher";

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, robotJob, batteryUsage),
                        "Must Throw Error because the Robot does not exist.");
        }

        [TestCase("Robokop", 1, 3, 2)]
        [TestCase("Terminator", 124, 1312, int.MaxValue)]
        public void Test_Work_Method_Must_Throw_Error_Low_Battery
            (string name, int maximumBattery, int capacity, int batteryUsage)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);
            int expcetedResult = robot.Battery - batteryUsage;
            string robotJob = "Teacher";

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, robotJob, batteryUsage),
                        "Must Throw Error because the battery is low.");
        }

        [TestCase("Robokop", 1, 3)]
        [TestCase("Terminator", 12412, 1312)]
        public void Test_Change_Method_Must_Set_Battery_To_Max_value
           (string name, int maximumBattery, int capacity)
        {
            int expcetedResult = maximumBattery;
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery);

            robotManager.Add(robot);
            robot.Battery = 1;
            robotManager.Charge(robot.Name);

            Assert.That(robot.Battery == expcetedResult,
                        "The work method does not decrease the chosen Robot's battery."); ;
        }

        [TestCase("Robokop", 1, 3)]
        [TestCase("Terminator", 124, 1312)]
        public void Test_Charge_Method_Must_Throw_Error_Non_Existing_Robot
            (string name, int maximumBattery, int capacity)
        {
            RobotManager robotManager = new RobotManager(capacity);
            Robot robot = new Robot(name, maximumBattery); 
            string fakeRobotName = "Kyncho";

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(fakeRobotName),
                        "Must Throw Error because the Robot does not exist.");
        }
    }
}
