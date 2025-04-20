using INT.Application.Application.Core;

namespace INT.Application.Application.Interfaces
{
    public interface IValidationServices
    {
        public Task<bool> DoesRoleExist(RoleDto model, int? RoleId);
        public Task<bool> DoesUserExist(UserCreateDto dto, long? value);
    }
}
