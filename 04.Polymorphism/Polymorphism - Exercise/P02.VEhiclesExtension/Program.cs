using System;
using Vehicles.Core;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
