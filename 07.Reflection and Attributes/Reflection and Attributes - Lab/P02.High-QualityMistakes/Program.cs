using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string accessModifiersAnalysis = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(accessModifiersAnalysis);
        }
    }
}
