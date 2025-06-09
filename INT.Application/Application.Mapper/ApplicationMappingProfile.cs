using INT.Application.Application.Core;
using INT.Domain.Model;

namespace INT.Application.Application.Mapper
{
    public class ApplicationMappingProfile : AutoMapper.Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<RoleDto, Role>();
            CreateMap<Role, ViewRoleDto>();
            CreateMap<ViewRoleDto, ViewRoleDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
