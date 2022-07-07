namespace SolidExerciseLogger.Layouts
{
    public class SimpleLayout : Layout, ILayout
    {
        private const string SimpleLayoutFormat = "{0} - {1} - {2}";

        public SimpleLayout() : base(SimpleLayoutFormat) { }
    }
}
