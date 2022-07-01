using BirthdayCelebrations.Core;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
