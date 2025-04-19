﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static INT.Domain.Domain.Constants.Enums;

namespace INT.Application.Contexts
{
    public class UserContext
    {
        public long UserId { get; set; }
        public required string Email { get; set; }
        public Language Language { get; set; }
        public int RoleId { get; set; }
        public required string UserName { get; set; }
    }
}
