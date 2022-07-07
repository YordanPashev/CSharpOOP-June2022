using System.Text;
using System.Linq;

namespace SolidExerciseLogger.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
            => this.sb = new StringBuilder();

        public int Size
            => this.sb.Length.ToString().Where(char.IsLetter).Sum(x => x);

        public void Write(string message)
            => this.sb.AppendLine(message);
    }
}
