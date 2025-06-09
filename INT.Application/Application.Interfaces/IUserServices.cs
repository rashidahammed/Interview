using INT.Application.Application.Core;
using INT.Application.Application.Core.Responses;
using INT.Utility;

namespace INT.Application.Application.Interfaces
{
    public interface IUserServices
    {
        public Task<ServiceResponse<bool>> AddUser(UserCreateDto dto);
        public Task<ServiceResponse<bool>> UpdateUser(UpdateUserDto dto);
        public Task<ServiceResponse> SoftDelete(long id);
        public Task<ServiceResponse<UserDetailsDto>> GetById(long id);
        public Task<ServiceResponse<IEnumerable<UserDetailsDto>>> GetAll();
    }
}
