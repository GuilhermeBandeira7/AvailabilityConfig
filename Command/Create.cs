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
        documentation: "Prompt the user to create a new configuration or camera. \n" +
        "command: create <PARAMATER> to prompt for creation(s).\n")]
    internal class Create : ICommand
    {
        public async Task ExecuteCommandAsync(string[] args)
        {
            await InitializeCreation(args);
        }

        private static async Task InitializeCreation(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    if (args[1] == "config")
                        await CreateConfig();
                    else
                        await CreateCamera();
                }
                else
                    throw new ConfigException("'create' needs the following parameters: <config> or <camera>");

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

        private static async Task CreateConfig()
        {
            try
            {
                Console.WriteLine("Camera IP: ");
                string? ip = Console.ReadLine();

                if (ip == string.Empty || ip == null)
                    throw new ConfigException("Invalid IP.");

                Response res = CamManager.CameraExist(ip);
                if (res.Result == false || res.Value == null)
                    throw new ConfigException(res.Message);

                Camera cam = (Camera)res.Value;

                await ConfigManager.CreateNewConfig(cam);
            }
            catch (ConfigException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task CreateCamera()
        {
            await CamManager.CreateNewCamera();
        }
    }
}
