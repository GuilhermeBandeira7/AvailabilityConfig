using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    internal interface ICommand
    {
        Task ExecuteCommandAsync(string[] args);
    }
}
