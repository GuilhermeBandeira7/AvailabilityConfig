using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Command
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DocCommand : Attribute
    {
        public DocCommand(string instruction, string documentation)
        {
            Instruction = instruction;
            Documentation = documentation;
        }

        public string Instruction { get; set; }
        public string Documentation { get; set; }
    }
}
