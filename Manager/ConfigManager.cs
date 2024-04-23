using AvailabilityConfig.Context;
using AvailabilityConfig.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig
{
    public static class ConfigManager
    {
        private readonly static OraclaDbContext dbContext = new OraclaDbContext();
        private readonly static AvConfigService _avConfigService = new AvConfigService(dbContext);

        public static async Task CreateNewConfig()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Camera IP: ");
                    string? ip = Console.ReadLine();
                    CameraInfo? cam = null;

                    if (ip == string.Empty || ip == null)
                        continue;

                    cam = await dbContext.Cameras.Where(x => x.Ip == ip).FirstOrDefaultAsync();

                    if (cam == null)
                    {
                        Console.WriteLine("Any camera with the specified IP was found.");
                        continue;
                    }

                    AvailabilityConfig AvConfig = CreateNewConfig(cam);

                    await _avConfigService.PostAvailabilityConfig(AvConfig);

                    Console.Clear();
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static AvailabilityConfig CreateNewConfig(CameraInfo cam)
        {
            AvailabilityConfig AvConfig = new AvailabilityConfig();
            AvConfig.Camera = cam;

            Console.WriteLine("\nName: ");
            string? name = Console.ReadLine();
            if (name == string.Empty || name == null)
                throw new Exception("Name can't be empty.");

            Console.WriteLine("\nPing Time: ");
            bool successfullParse = double.TryParse(Console.ReadLine(), out double pingTime);
            if (!successfullParse)
                throw new Exception("Ping time has to be a numeric value.");

            Console.WriteLine("\nPings To Offline: ");
            successfullParse = int.TryParse(Console.ReadLine(), out int pingsToOffline);
            if(!successfullParse)
                throw new Exception("Pings to offline has to be a numeric value.");

            Console.WriteLine("\nVerification Time: ");
            successfullParse = double.TryParse(Console.ReadLine(), out double verificationTime);
            if (!successfullParse)
                throw new Exception("Verification has to be a numeric value.");

            Console.WriteLine("\nCurrent status: ");
            string? status = Console.ReadLine();
            if (status == string.Empty || status == null)
                throw new Exception("Status can't be empty.");

            AvConfig.Name = name;
            AvConfig.PingTime = pingTime;
            AvConfig.PingsToOffline = pingsToOffline;
            AvConfig.VerificationTime = verificationTime;
            AvConfig.currentStatus = status;

            return AvConfig;
        }
    }
}
