using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using AvailabilityConfig.Service;
using System.Reflection;

namespace AvailabilityConfig.Manager
{
    public static class CamManager
    {
        private static readonly OraclaDbContext _context = new();
        private static readonly CameraService _service = new(_context);

        public static Response CameraExist(string camIP)
        {
            Camera? camera = _context.Cameras.Where(c => c.Ip == camIP).FirstOrDefault();
            if (camera == null)
                return new Response(false, "Camera not found.");
            return new Response(true, camera);
        }

        public static async Task CreateNewCamera()
        {
            try
            {
                Camera camera = new Camera();
                foreach(PropertyInfo property in typeof(Camera).GetProperties())
                {
                    if(property.PropertyType == typeof(string))
                    {
                        Console.WriteLine($"{property.Name}:");
                        string? prop = Console.ReadLine();
                        if (prop == string.Empty || prop == null)
                            throw new ConfigException($"{property.Name} can't be empty.");
                        property.SetValue(camera, prop);
                    }
                }
                await _service.PostCamera(camera);
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

        public static async Task ListAllCameras()
        {
            try
            {
                List<Camera> camList = await _service.GetCameras();
                foreach (Camera camera in camList)
                {
                    Console.WriteLine(camera.ToString());
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

        public static async Task DeleteCamera(long id)
        {
            try
            {
                await _service.DeleteCamera(id);
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
    }
}
