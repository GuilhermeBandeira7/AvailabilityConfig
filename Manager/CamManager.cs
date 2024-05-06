using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using AvailabilityConfig.Model;
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
                Camera camera = ObjectFactory.CreateNewObj("camera") as Camera ?? 
                    throw new ConfigException("Camera can't be empty value.");
                await _service.PostCamera(camera);
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

        public static async Task DeleteCamera(long id)
        {
            try
            {
                await _service.DeleteCamera(id);
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

        public static async Task EditCamera()
        {
            try
            {
                Console.WriteLine("Camera Id: ");
                bool toIntParse = int.TryParse(Console.ReadLine(), out int camId);
                Camera? camera = _context.Cameras.Where(c => c.Id == camId).FirstOrDefault();
                if (camera == null) throw new ConfigException("Camera not found.");
                Camera? editedCam = ObjectFactory.CreateNewObj("camera") as Camera;
                Response res =  await _service.PutCamera(camera.Id, camera);
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
    }
}
