using INT.Application.Application.Core;
using INT.Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Interfaces
{
    public interface IUserServices
    {
        public Task<ServiceResponse<bool>> AddUser(UserCreateDto dto);
        public Task<ServiceResponse<bool>> UpdateUser(UpdateUserDto dto);
        public Task<ServiceResponse<IEnumerable<ViewUserDto>>> GetAll();
        public Task<ServiceResponse> Delete(int id);
        public Task<ServiceResponse> SoftDelete(int id);
    }
}
