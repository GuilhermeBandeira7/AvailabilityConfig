using AvailabilityConfig.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Service
{
    public class CameraService
    {
        OraclaDbContext _context;

        public CameraService(OraclaDbContext context)
        {
            _context = context;   
        }

        //Whoever calls this function needs to make sure that returned != null
        public async Task<List<Camera>> GetCameras()
        {
            try
            {
                List<Camera> cameras = await _context.Cameras.ToListAsync();
                if (!cameras.Any())
                {
                    throw new Exception("No Cameras found.");
                }
                return cameras;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Whoever calls this functions needs to make sure that returned != null
        public async Task<Camera> GetCameraById(long id)
        {
            try
            {
                Camera? camera = await _context.Cameras.Where(cam => cam.Id == id).FirstOrDefaultAsync();
                if (camera != null)
                    return camera;
                throw new Exception();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response> PutCamera(long id, Camera camInfo)
        {
            try
            {
                Camera? cam = await _context.Cameras.Where(cam => cam.Id == id).FirstOrDefaultAsync();
                if (cam != null)
                {
                    _context.Entry(camInfo).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response(true, "Camera updated.");
                }
                else
                    throw new Exception("Failed to update.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostCamera(Camera camInfo)
        {
            try
            {
                await _context.Cameras.AddAsync(camInfo);
                await _context.SaveChangesAsync();
                Console.WriteLine("Camera added successfully.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCamera(long id)
        {
            try
            {
                await _context.Cameras.Where(cam => cam.Id == id).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                Console.WriteLine("Camera deleted successfully.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
