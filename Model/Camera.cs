using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Highway { get; set; } = string.Empty;
        public string Parents { get; set; } = string.Empty;
        public string LATLNG { get; set; } = string.Empty;
        public string? KmComplement { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public DateTime? LastVerification { get; set; }

        public List<Config> AvailabilityConfigs { get; set; } = new();
    }
}
