using SolidExerciseLogger.Core;

namespace SolidExerciseLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
