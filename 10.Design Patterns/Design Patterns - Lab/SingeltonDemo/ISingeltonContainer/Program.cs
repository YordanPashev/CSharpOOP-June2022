using SingeltonDemo;

var db = SingeltonContainer.Instance;
Console.WriteLine(db.GetPopulation("London"));
Console.WriteLine(db.GetPopulation("Ruse"));
Console.WriteLine(db.GetPopulation("New York"));

