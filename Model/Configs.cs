﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig
{
    public class Config
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Value { get; set; }
        public double PingTime { get; set; }
        public int PingsToOffline { get; set; }
        public double VerificationTime { get; set; }
        public string currentStatus { get; set; } = string.Empty;

        [ForeignKey("CameraId")]
        public Camera Camera { get; set; } = new();

        public override string ToString()
        {
            StringBuilder configObjToString = new StringBuilder();
            configObjToString.Append($"Id:{Id} Name:{Name} Value:{Value} ")
                .AppendLine().Append($"Ping Time:{PingTime} Pings to Offline:{PingsToOffline} Verification Time:{VerificationTime} ")
                .AppendLine().Append($"Current Status:{currentStatus}\n");

            return configObjToString.ToString();
        }
    }
}
