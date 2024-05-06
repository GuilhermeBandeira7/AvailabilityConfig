using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    public static class CommandFactory
    {
        public static ICommand? CreateCommand(string[] command)
        {
            var cmd = command[0];
            switch (cmd)
            {
                case "list": return new List();
                case "create": return new Create();
                case "delete": return new Delete();
                case "help": return new Help();
                case "modify": return new Modify();
                case "clear": return new Clear();
                default: return null;   
            }
        }
    }
}
