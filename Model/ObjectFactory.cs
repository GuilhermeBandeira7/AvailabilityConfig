using AvailabilityConfig.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Model
{
    public static class ObjectFactory
    {
        public static object? CreateNewObj(string type)
        {
            switch (type)
            {
                case "config":
                    Config config = new Config();
                    foreach (PropertyInfo property in config.GetType().GetProperties())
                    {
                        if (property.PropertyType == typeof(string))
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
                    return config;
                case "camera":
                    Camera camera = new Camera();
                    foreach (PropertyInfo property in typeof(Camera).GetProperties())
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            Console.WriteLine($"{property.Name}:");
                            string? prop = Console.ReadLine();
                            if (prop == string.Empty || prop == null)
                                throw new ConfigException($"{property.Name} can't be empty.");
                            property.SetValue(camera, prop);
                        }
                    }
                    return camera;
                default: return new();
            }
        }
    }
}
