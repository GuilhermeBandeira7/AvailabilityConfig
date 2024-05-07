using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using Microsoft.EntityFrameworkCore;

namespace AvailabilityConfig
{
    public class AvConfigService
    {
        OraclaDbContext _context;

        public AvConfigService(OraclaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Config>> GetAllAvConfigs()
        {
            try
            {
                List<Config> configs = await _context.Configs.ToListAsync();
                if (!configs.Any())
                    throw new ConfigException("Any configuration was found.");

                return configs;
            }
            catch(ConfigException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Config> GetAvailabilityConfig(string camIP)
        {
            try
            {
                Config? config = await _context.Configs
                   .Include(c => c.Camera)
                   .Where(conf => conf.Camera.Ip == camIP)
                   .SingleOrDefaultAsync();

                if (config != null)
                    return config;

                return new();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response> PostAvailabilityConfig(Config avConfig)
        {
            try
            {
                await _context.Configs.AddAsync(avConfig);
                await _context.SaveChangesAsync();
                return new Response(true, "Configuration added successfully.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response> DeleteAvailabilityConfig(long id)
        {
            try
            {
                await _context.Configs.Where(c => c.Id == id).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                return new Response(true, "Configuration deleted successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response> PutAvailabilityConfig(Config avConfig)
        {
            try
            {
                _context.Entry(avConfig).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new Response(true, "Config updated.");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
