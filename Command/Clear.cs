using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "clear",
        documentation: "clear the console. \n" +
        "command: clear.\n")]
    public class Clear : ICommand
    {
        public Task ExecuteCommandAsync(string[] args)
        {
            ClearConsole();
            return Task.CompletedTask;  
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
