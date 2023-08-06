using System;
using System.Linq;

namespace zipandsendApp.View
{
    public static class CommandLineView
    {
        public static string[] GetCommandLineArguments()
        {          

            return Environment.GetCommandLineArgs().Length > 1 ? Environment.GetCommandLineArgs()[1..] : Array.Empty<string>();
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
    