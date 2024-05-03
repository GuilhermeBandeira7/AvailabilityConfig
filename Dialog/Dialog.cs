using AvailabilityConfig.Command;
using AvailabilityConfig.CustomException;

namespace AvailabilityConfig.Dialog
{
    public static class Dialog
    {
        public static void InitialDialog(SystemCommands commands)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to Availability Config");
            Console.WriteLine("===============================\n");                   

            Console.WriteLine("For more information type 'help'.\n");

            while (true)
            {
                try
                {
                    string? cmd = Console.ReadLine();
                    if (cmd == string.Empty || cmd == null)
                        throw new ConfigException("Command can't be empty string.");

                    string[] cmdParam = cmd.Split(' '); 

                    ICommand? userCommand = commands[cmd] ?? throw new ConfigException("Invalid command.");
                    userCommand.ExecuteCommandAsync(cmdParam);
                }
                catch(ConfigException confEx)
                {
                    Console.WriteLine(confEx.Message, Console.ForegroundColor = ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }       
    }
}
