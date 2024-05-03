using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    public interface ICommand
    {
        Task ExecuteCommandAsync(string[] args);
    }
}
