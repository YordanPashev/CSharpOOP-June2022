using System;

namespace SolidExerciseLogger.Layouts
{
    public class XmlLayout : Layout, ILayout
    {
        private static string xmlLayoutFormat = $"<log>{Environment.NewLine}" +
                                                "   <date>{0}</date>" + Environment.NewLine +
                                                "   <level>{1}</level>" + Environment.NewLine +
                                                "   <message>{2}</message>" + Environment.NewLine +
                                                $"</log>";

        public XmlLayout() : base(xmlLayoutFormat) { }
    }
}
