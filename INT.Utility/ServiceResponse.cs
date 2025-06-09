using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Utility
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
