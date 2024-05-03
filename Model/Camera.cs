using System;
using System.Collections.Generic;
using System.Globalization;
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

        public override string ToString()
        {
            StringBuilder cameraObjToString = new StringBuilder();
            cameraObjToString.Append($"Id:{Id} Name:{Name} Direction:{Direction} ")
                .AppendLine().Append($"Highway:{Highway} Parentes:{Parents} Latitude Longitude:{LATLNG} ")
                .AppendLine().Append($"KM Complement:{KmComplement} Status:{Status} Last Verification:{LastVerification.ToString()}\n");

            return cameraObjToString.ToString();
        }
    }
}
