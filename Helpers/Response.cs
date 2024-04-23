using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig
{
    public class Response
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Value { get; set; } = null;

        public Response() { }

        public Response(bool result)
        {
            Result = result;
            Message = result ? "Success" : "Invalid Object";
        }

        public Response(bool result, string message)
        {
            Result = result;
            Message = message;
        }


        public Response(bool result, object obj)
        {
            Result = result;
            Message = result ? "Success" : "Invalid Object";
            Value = obj;
        }

        public Response(bool result, string message, object obj)
        {
            Result = result;
            Message = message;
            Value = obj;
        }
    }
}
