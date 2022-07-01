using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Core;


namespace MilitaryElite
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
