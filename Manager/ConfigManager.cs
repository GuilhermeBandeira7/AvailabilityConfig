using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using System.Reflection;
using System;
using System.Xml.Linq;

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
                Config config = new Config();   
                config.Camera = cam;    

                foreach(PropertyInfo property in config.GetType().GetProperties())
                {
                    if(property.PropertyType == typeof(string))
                    {
                        Console.WriteLine($"{property.Name}:");
                        string? prop = Console.ReadLine();
                        if (prop == null || prop == string.Empty)
                            throw new ConfigException($"{property.Name} can't be empty.");

                        property.SetValue(config, prop);
                        continue;
                    }                

                    if (property.PropertyType == typeof(double))
                    {
                        Console.WriteLine($"{property.Name}:");
                        double propParsed;
                        bool successfullParse = double.TryParse(Console.ReadLine(), out propParsed);
                        if (!successfullParse)
                            throw new ConfigException($"{property.Name} requires a decimal value.");
                        property.SetValue(config, propParsed);
                    }

                    if (property.PropertyType == typeof(int) && property.Name != "Id")
                    {
                        Console.WriteLine($"{property.Name}:");
                        int propParsed;
                        bool successfullParse = int.TryParse(Console.ReadLine(), out propParsed);
                        if (!successfullParse)
                            throw new ConfigException($"{property.Name} requires an integer value.");
                        property.SetValue(config, propParsed);
                    }
                }
                Response res = await _service.PostAvailabilityConfig(config);
                Console.WriteLine(res.Message);

            }
            catch (ConfigException ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public static async Task ListAllConfigs()
        {
            try
            {
                List<Config> configs = await _service.GetAllAvConfigs();
                foreach(Config config in configs)
                {
                    Console.WriteLine(config.ToString());
                }
            }
            catch(ConfigException ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public static async Task<Response> DeleteConfig(long id)
        {
            Response res = await _service.DeleteAvailabilityConfig(id);
            return res;
        }
    }
}
