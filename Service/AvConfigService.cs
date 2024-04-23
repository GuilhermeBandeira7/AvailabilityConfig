using AvailabilityConfig.Context;
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }

        public async Task PostAvailabilityConfig(AvailabilityConfig avConfig)
        {
            try
            {
                if(avConfig != null)
                {
                    await _context.Configs.AddAsync(avConfig);
                    await _context.SaveChangesAsync();  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
