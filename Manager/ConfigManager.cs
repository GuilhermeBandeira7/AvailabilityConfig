using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using System.Reflection;
using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using AvailabilityConfig.Model;
using AvailabilityConfig.Service;
using AvailabilityConfig.Manager;

namespace AvailabilityConfig
{
    public class ConfigManager
    {
        private static readonly OraclaDbContext _context = new();
        private static readonly AvConfigService _service = new(_context);

        public static async Task CreateNewConfig(Camera cam)
        {
            try
            {
                Config? config = ObjectFactory.CreateNewObj("config") as Config ?? throw new ConfigException("Failed to create new config.");
                config.Camera = cam;
                Response res = await _service.PostAvailabilityConfig(config);
                Console.WriteLine(res.Message);

            }
            catch (ConfigException ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
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

        public static async Task ListAllConfigs()
        {
            try
            {
                List<Config> configs = await _service.GetAllAvConfigs();
                foreach (Config config in configs)
                {
                    Console.WriteLine(config.ToString());
                }
            }
            catch (ConfigException ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
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

        public static async Task<Response> DeleteConfig(long id)
        {
            Response res = await _service.DeleteAvailabilityConfig(id);
            return res;
        }

        public static bool ConfigExists(long id)
        {
            Config? config = _context.Configs.Where(c => c.Id == id).FirstOrDefault();
            if (config == null) return false;
            return true;

        }

        public static async Task EditConfig()
        {
            try
            {
                Console.WriteLine("Config Id: ");
                bool parseIsSuccessfull = int.TryParse(Console.ReadLine(), out int confId);
                if (!parseIsSuccessfull) throw new ConfigException("Id has to be a greater than zero integer value.");
                if (!ConfigExists(confId)) throw new ConfigException("Config not found.");
                Config? config = ObjectFactory.CreateNewObj("config") as Config ?? throw new ConfigException("Failed to set new config parameters.");
                config.Id = confId;
                Response res = await _service.PutAvailabilityConfig(config);
                Console.WriteLine(res.Message);
            }
            catch (ConfigException  ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
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
