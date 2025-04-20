using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Domain.Domain.Interfaces;

namespace INT.Application.Application.Services
{
    public class ValidationServices : IValidationServices
    {
        private readonly IRoleRepositories _roleRepo;
        private readonly IUserRepositories _userRepo;


        public readonly IMapper _mapper;
        public ValidationServices(IRoleRepositories roleRepo, IUserRepositories userRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<bool> DoesRoleExist(RoleDto dto, int? roleId)
        {
            var _result = await _roleRepo.DoesRoleExist(dto.Name, dto.NameHi, roleId);
            return _result;
        }

        public async Task<bool> DoesUserExist(UserCreateDto dto, long? userId)
        {
            var _result = await _userRepo.DoesUserExist(dto.UserName, dto.Email, userId);
            return _result;
        }

        public async Task<bool> DoRolesExistAsync(List<int> roleIds)
        {
            var _result = await _roleRepo.DoRolesExistAsync(roleIds);
            return _result; ;
        }

    }
}
