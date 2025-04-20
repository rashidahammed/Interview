using INT.Application.Application.Core;
using INT.Application.Model.Responses;

namespace INT.Application.Application.Interfaces
{
    public interface IUserLoginServices
    {
        public Task<ServiceResponse<string>> Login(LoginDto loginDto);
    }
}
