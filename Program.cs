using AvailabilityConfig.Command;

namespace AvailabilityConfig
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SystemCommands commands = new SystemCommands();
            Dialog.Dialog.InitialDialog(commands);
        }
    }
}