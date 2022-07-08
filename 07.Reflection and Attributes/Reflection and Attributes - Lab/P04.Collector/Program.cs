using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string accessModifiersAnalysis = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(accessModifiersAnalysis);
        }
    }
}
