using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Dialog
{
    public static class Dialog
    {

        public static async Task InitialDialog()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to Availability Config");
            Console.WriteLine("===============================\n");

            await ConfigManager.CreateNewConfig();
        }

       
    }
}
