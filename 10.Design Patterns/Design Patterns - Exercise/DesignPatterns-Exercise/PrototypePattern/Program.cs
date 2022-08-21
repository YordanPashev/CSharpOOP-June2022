using PrototypePattern;

Tire tireone = new Tire("Michelin");
Tire tireTwo = new Tire("Michelin");
Tire tireThree = new Tire("Michelin");
Tire tireFour = new Tire("Michelin");

List<Tire> tires = new List<Tire> { tireone, tireTwo, tireThree, tireFour };
Car carOne = new Car("Tesla", "Model 3", 2009, tires);

Car? carTwo = carOne.Clone();

carOne.Year = 2010;

foreach (var tire in carOne.Tires)
{
    tire.Condition = "Worn-out";
}

Console.WriteLine($"Car 1: {carOne}");
Console.WriteLine($"Car 2: {carTwo}");


