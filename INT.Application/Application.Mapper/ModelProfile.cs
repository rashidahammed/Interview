using INT.Application.Application.Core;
using INT.Application.Model.Requests;
using INT.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //CreateMap<UserCreateDto, User>()
            //.ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src =>
            // src.UserRoles.Select(roleId => new UserRole { RoleId = roleId }).ToList()));
        }
    }
}
