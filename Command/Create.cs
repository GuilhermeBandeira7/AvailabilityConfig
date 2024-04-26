using AvailabilityConfig.CustomException;
using AvailabilityConfig.Manager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "create",
        documentation: "prompt the user to create a new configuration. \n"+
        "create <PARAMATER> to prompt for new configuration(s).\n")]
    internal class Create : ICommand
    {
        public Task ExecuteCommandAsync(string[] args)
        {
            _ = InitializeConfigCreation(args); 
            return Task.CompletedTask;
        }

        private static async Task InitializeConfigCreation(string[] args)
        {
            try
            {
                Console.WriteLine("Camera IP: ");
                string? ip = Console.ReadLine();
                CameraInfo? cam = null;

                if (ip == string.Empty || ip == null)
                    throw new ConfigException("Invalid IP.");

                Response res = CamManager.CameraExist(ip);
                if(res.Result == false)
                    Console.WriteLine(res.Message);

                if (res.Value == null)
                    throw new ConfigException("Camera not found.");

                cam = (CameraInfo)res.Value;
                await ConfigManager.CreateNewConfig(cam);

                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
