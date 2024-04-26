using AvailabilityConfig.Context;
using AvailabilityConfig.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Manager
{
    public static class CamManager
    {
        private static readonly OraclaDbContext _context = new();
        private static readonly CameraService _service = new(_context);

        public static Response CameraExist(string camIP)
        {
            CameraInfo? camera = _context.Cameras.Where(c => c.Ip == camIP).FirstOrDefault();
            if (camera == null)
                return new Response(false, "Camera not found.");
            return new Response(true, camera);
        }
    }
}
