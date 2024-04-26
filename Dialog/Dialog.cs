using AvailabilityConfig.Command;
using AvailabilityConfig.CustomException;

namespace AvailabilityConfig.Dialog
{
    public static class Dialog
    {
        public static void InitialDialog()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to Availability Config");
            Console.WriteLine("===============================\n");
            
            SystemCommands commands = new SystemCommands();

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
                    Console.WriteLine(confEx.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }       
    }
}
