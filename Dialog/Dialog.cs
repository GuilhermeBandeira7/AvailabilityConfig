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

            Console.WriteLine("For more information type 'help'.\n");

            while (true)
            {
                try
                {
                    string? cmd = Console.ReadLine();
                    if (cmd == string.Empty || cmd == null)
                        throw new ConfigException("Command can't be empty string.");

                    string[] cmdParam = cmd.Split(' ');

                    ICommand? userCommand = CommandFactory.CreateCommand(cmdParam) 
                        ?? throw new ConfigException("Invalid command."); 
                    userCommand.ExecuteCommandAsync(cmdParam);
                }
                catch(ConfigException confEx)
                {
                    Console.WriteLine(confEx.Message, Console.ForegroundColor = ConsoleColor.Red);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }       
    }
}
