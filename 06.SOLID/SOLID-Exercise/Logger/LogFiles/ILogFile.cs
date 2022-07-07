namespace SolidExerciseLogger.LogFiles
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
