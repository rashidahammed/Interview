using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Model.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        //public int StatusCode { get; set; } = 200;
    }
    public class ServiceResponse
    {
        //public int StatusCode { get; set; } = 200;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
