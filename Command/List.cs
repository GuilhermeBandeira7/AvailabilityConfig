using AvailabilityConfig.CustomException;
using AvailabilityConfig.Manager;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "List all cameras on configurations in the Database. ",
        documentation: "Displays all cameras or configurations on the console saved on the database.\n" +
        "command: list <PARAMETER> where the parameter is 'camera' or 'config'.\n")]
    public class List : ICommand
    {
        public async Task ExecuteCommandAsync(string[] args)
        {
            await ListAll(args);
        }

        private static async Task ListAll(string[] args)
        {
            try
            {
                if (args.Length == 1) throw new ConfigException("'list' needs the following parameters: <config> or <camera>");
                if (args[1] == "config")
                    await ConfigManager.ListAllConfigs();
                else
                    await CamManager.ListAllCameras();
            }
            catch (ConfigException confEx)
            {
                Console.WriteLine(confEx.Message, Console.ForegroundColor = ConsoleColor.Red);
            }
            catch (Exception ex)
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
