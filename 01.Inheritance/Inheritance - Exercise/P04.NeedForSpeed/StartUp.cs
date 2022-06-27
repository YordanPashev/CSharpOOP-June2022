namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar wanwan = new FamilyCar(400, 15);
            wanwan.Drive(5);
            System.Console.WriteLine(wanwan.Fuel);
        }
    }
}
