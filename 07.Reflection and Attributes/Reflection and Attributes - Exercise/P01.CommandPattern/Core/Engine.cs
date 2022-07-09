using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
           this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine();

                string cmdExecutionResult = this.commandInterpreter.Read(cmd);

                if(cmdExecutionResult == null)
                {
                    break;
                }

                Console.WriteLine(cmdExecutionResult);
            }
        }
    }
}