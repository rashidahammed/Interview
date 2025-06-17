using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Core.Responses
{
    public class LoginResponseDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Name { get; set; }
    }
}
