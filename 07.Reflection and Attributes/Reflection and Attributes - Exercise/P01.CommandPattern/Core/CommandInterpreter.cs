using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(' ');
            string cmd = input[0];
            string[] value = input[1..];

            Type commandType = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == $"{cmd}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command type");
            }
            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(value);
            return result;

            //Solution with Reflection:
            //Type type = Type.GetType("CommandPattern.Commands." + cmd + "Command");
            //ICommand command = Activator.CreateInstance(type) as ICommand;
            //string result = command.Execute(value);
            //return result;
        }
    }
}
