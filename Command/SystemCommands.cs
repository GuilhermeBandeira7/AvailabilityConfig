using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    public class SystemCommands
    {
        public Dictionary<string, ICommand> Commands = new() 
        {
            {"help", new Help() } ,
            {"help create", new Help() } ,
            {"create", new Create() },
            {"create config", new Create() },
            {"create camera", new Create() },
            {"clear", new Clear() }
        };

        public ICommand? this[string key] => Commands.ContainsKey(key) ? Commands[key] : null;
    }
}
