using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Model
{
    public class Ping_MongoDB
    {
        public long Id { get; set; }
        public long AvailabilityConfig { get; set; }
        public long Counter { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Status { get; set; } = string.Empty;
    }
}
