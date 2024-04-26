using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    internal class SystemCommands
    {
        public Dictionary<string, ICommand> Commands = new() 
        {
            {"help", new Help() } ,
            {"create", new Create() }
        };

        public ICommand? this[string key] => Commands.ContainsKey(key) ? Commands[key] : null;
    }
}
