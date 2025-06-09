using INT.Application.Application.Core;
using INT.Utility;

namespace INT.Application.Application.Interfaces
{
    public interface IRoleServices
    {
        public Task<ServiceResponse<bool>> AddRole(RoleDto Role);
        public Task<ServiceResponse<bool>> UpdateRole(UpdateRoleDto dto);
        public Task<ServiceResponse<ViewRoleDto>> GetById(int id);
        public Task<ServiceResponse<IEnumerable<ViewRoleDto>>> GetAll();
        public Task<ServiceResponse> Delete(int id);
        public Task<ServiceResponse> SoftDelete(int id);
    }
}
