using INT.Application.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Interfaces
{
    public interface IValidationServices
    {
        public Task<bool> DoesRoleExist(RoleDto model, int? RoleId);
        public Task<bool> DoesUserExist(UserCreateDto dto, long? value);
    }
}
