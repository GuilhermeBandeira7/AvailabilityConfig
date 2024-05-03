using AvailabilityConfig.CustomException;
using AvailabilityConfig.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (args[1] == "config")
                await ConfigManager.ListAllConfigs();
            else
                await CamManager.ListAllCameras();
        }
    }
}
