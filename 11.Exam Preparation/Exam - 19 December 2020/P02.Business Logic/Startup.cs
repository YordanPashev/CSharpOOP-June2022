using System;
using System.IO;
using WarCroft.Core;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            var sbWriter = new StringBuilderWriter();

            var engine = new Engine(reader, sbWriter);
            engine.Run();

            File.WriteAllText("../../../result", sbWriter.sb.ToString().Trim());
        }
    }
}