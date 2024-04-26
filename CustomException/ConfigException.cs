using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.CustomException
{
    internal class ConfigException : System.Exception
    {
        public ConfigException()
        {          
        }

        public ConfigException(string msg) :base(msg) 
        { 
        }

        public ConfigException(string msg, Exception innerException)
        {         
        }

        protected ConfigException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { 
        }
    }
}
