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
            return cmd switch
            {
                "list" => new List(),
                "create" => new Create(),
                "delete" => new Delete(),
                "help" => new Help(),
                "modify" => new Modify(),
                "clear" => new Clear(),
                _ => null,
            };
        }
    }
}
