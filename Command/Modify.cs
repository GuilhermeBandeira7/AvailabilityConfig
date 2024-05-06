using AvailabilityConfig.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [DocCommand(instruction: "modify",
        documentation: "Edit the properties of camera or config. \n" +
        "modify <PARAMETER> where the parameter is 'camera' of 'config'. \n")]
    public class Modify : ICommand
    {
        public async Task ExecuteCommandAsync(string[] args)
        {
            await ModifyEl(args);
        }

        public async Task ModifyEl(string[] args)
        {
            if (args[1] == "config")
                await ConfigManager.EditConfig();
        }
    }
}
