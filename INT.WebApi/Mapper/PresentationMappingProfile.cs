using INT.Application.Application.Core;
using INT.WebApi.Model.Requests;

namespace INT.WebApi.Mapper
{
    public class PresentationMappingProfile : AutoMapper.Profile
    {
        PresentationMappingProfile()
        {
            CreateMap<CreateRoleVm, RoleDto>();
            CreateMap<UpdateRoleVm, UpdateRoleDto>();
            CreateMap<CreateUserVm, UserCreateDto>();
            CreateMap<UpdateUserVm, UpdateUserDto>();
            CreateMap<LoginReqVm, LoginDto>();
        }
    }
}
