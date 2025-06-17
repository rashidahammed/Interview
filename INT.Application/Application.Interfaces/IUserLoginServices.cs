using INT.Application.Application.Core;
using INT.Application.Application.Core.Responses;
using INT.Utility;

namespace INT.Application.Application.Interfaces
{
    public interface IUserLoginServices
    {
        public Task<ServiceResponse<LoginResponseDto>> Login(LoginDto loginDto);
    }
}
