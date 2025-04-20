using INT.Application.Application.Core;
using INT.Application.Model.Requests;
using INT.Application.Model.Responses;
using INT.Domain.Model;

namespace INT.Application.Application.Mapper
{
    public class ModelProfile : AutoMapper.Profile
    {
        public ModelProfile()
        {
            CreateMap<RoleDto, Role>();
            CreateMap<CreateRoleVm, RoleDto>();
            CreateMap<Role, ViewRoleDto>();
            CreateMap<ViewRoleDto, ViewRoleDto>();
            CreateMap<UpdateRoleVm, UpdateRoleDto>();
            CreateMap<CreateUserVm, UserCreateDto>();
            CreateMap<UpdateUserVm, UpdateUserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserDetails, UserDetailsVm>();
            CreateMap<LoginReqVm, LoginDto>();
        }
    }
}
