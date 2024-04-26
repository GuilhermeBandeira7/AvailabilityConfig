using AvailabilityConfig.Context;
using AvailabilityConfig.CustomException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig
{
    public class AvConfigService
    {
        OraclaDbContext _context;

        public AvConfigService(OraclaDbContext context)
        {
            _context = context;
        }

        public async Task<List<AvailabilityConfig>> GetAllAvConfigs()
        {
            try
            {
                List<AvailabilityConfig> configs = await _context.Configs.ToListAsync();
                if (!configs.Any())
                    throw new ConfigException("Any configuration was found.");

                return configs;
            }
            catch(ConfigException ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }

        public async Task<AvailabilityConfig> GetAvailabilityConfig(string camIP)
        {
            try
            {
                AvailabilityConfig? config = await _context.Configs
                   .Include(c => c.Camera)
                   .Where(conf => conf.Camera.Ip == camIP)
                   .SingleOrDefaultAsync();

                if (config != null)
                    return config;

                return new();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }

        public async Task<Response> PostAvailabilityConfig(AvailabilityConfig avConfig)
        {
            try
            {
                await _context.Configs.AddAsync(avConfig);
                await _context.SaveChangesAsync();
                return new Response(true, "Configuration added successfully.");
            }
            catch (Exception ex)
            {

                return new Response(false, ex.Message);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Response(false, "Failed to delete configuration.");
            }
        }

    }
}
