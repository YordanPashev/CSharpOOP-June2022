using CompositePattern;

var phone = new SingleGift("Phone", 256);
Console.WriteLine();
Console.WriteLine(phone);

var rootBox = new CompositeGift("RootBox", 1);
var truckToy = new SingleGift("TruckToy", 287);
var planeToy = new SingleGift("PlainToy", 587);

rootBox.Add(truckToy);
rootBox.Add(planeToy);

var childBox = new CompositeGift("ChildBox", 1);
var soldierToy = new SingleGift("SoldierToy", 200);

childBox.Add(soldierToy);
rootBox.Add(childBox);

Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice() }");

Console.WriteLine(rootBox);
