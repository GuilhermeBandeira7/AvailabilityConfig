using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;

namespace AvailabilityConfig
{
    public class ConfigManager
    {
        private static readonly OraclaDbContext _context = new OraclaDbContext();
        private static readonly AvConfigService _service = new AvConfigService(_context);

        public static async Task CreateNewConfig(CameraInfo cam)
        {
            AvailabilityConfig AvConfig = new()
            {
                Camera = cam
            };

            Console.WriteLine("\nName: ");
            string? name = Console.ReadLine();
            if (name == string.Empty || name == null)
                throw new ConfigException("Name can't be empty.");

            bool successfullParse = true;

            Console.WriteLine("\nPing Time: ");
            successfullParse = double.TryParse(Console.ReadLine(), out double pingTime);
            if (!successfullParse)
                throw new ConfigException("Ping time has to be a numeric value.");

            Console.WriteLine("\nPings To Offline: ");
            successfullParse = int.TryParse(Console.ReadLine(), out int pingsToOffline);
            if(!successfullParse)
                throw new ConfigException("Pings to offline has to be a numeric value.");

            Console.WriteLine("\nVerification Time: ");
            successfullParse = double.TryParse(Console.ReadLine(), out double verificationTime);
            if (!successfullParse)
                throw new ConfigException("Verification has to be a numeric value.");

            Console.WriteLine("\nCurrent status: ");
            string? status = Console.ReadLine();
            if (status == string.Empty || status == null)
                throw new ConfigException("Status can't be empty.");

            AvConfig.Name = name;
            AvConfig.PingTime = pingTime;
            AvConfig.PingsToOffline = pingsToOffline;
            AvConfig.VerificationTime = verificationTime;
            AvConfig.currentStatus = status;

            Response res = await _service.PostAvailabilityConfig(AvConfig);
            Console.WriteLine(res.Message);
        }

        public static async Task<List<AvailabilityConfig>> ListAllConfigs()
        {
            List<AvailabilityConfig>? configs = await _service.GetAllAvConfigs();
            return configs; 
        }

        public static async Task<Response> DeleteConfig(long id)
        {
            Response res = await _service.DeleteAvailabilityConfig(id);
            return res;
        }
    }
}
