using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Application.Contexts;
using INT.Application.Model.Responses;
using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Utility.Resources;

namespace INT.Application.Application.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepositories _repo;
        public readonly IMapper _mapper;
        private readonly IValidationServices _validation;
        private readonly UserContext _userContext;
        public RoleServices(IRoleRepositories repo, IMapper mapper, IValidationServices validation, ICurrentUserContext userContext)
        {
            _repo = repo;
            _mapper = mapper;
            _validation = validation;
            _userContext = userContext.GetUserContext();
        }
        public async Task<ServiceResponse<bool>> AddRole(RoleDto dto)
        {
            var _retVal = new ServiceResponse<bool>() { Data = false, Message = AppResource.CommonError, Success = false };
            bool _exist = await _validation.DoesRoleExist(dto, null);
            if (_exist)
            {
                _retVal.Message = AppResource.RoleAlreadyExist;
                return _retVal;
            }

            var newEntity = _mapper.Map<Role>(dto);
            newEntity.CreatedOn = DateTime.Now;
            newEntity.IsDeleted = false;
            newEntity.CreatedBy = 1;
            await _repo.InsertAsync(newEntity);
            var _result = await _repo.SaveAsync();
            if (_result > 0)
            {
                _retVal.Success = true;
                _retVal.Message = AppResource.RoleAdded;
                _retVal.Data = true;
            }
            return _retVal;
        }
        public async Task<ServiceResponse<bool>> UpdateRole(UpdateRoleDto dto)
        {
            var _retVal = new ServiceResponse<bool>() { Data = false, Message = AppResource.CommonError, Success = false };
            var obj = await _repo.GetByIdAsync(dto.Id);
            if (obj != null)
            {
                bool isExist = await _validation.DoesRoleExist(dto, obj.Id);
                if (isExist)
                {
                    _retVal.Message = AppResource.RoleAlreadyExist;
                    return _retVal;
                }

                obj.LastModifiedBy = _userContext.RoleId;
                obj.LastModifiedOn = DateTime.Now;

                _mapper.Map<UpdateRoleDto, Role>(dto, obj);
                var _result = await _repo.SaveAsync();
                if (_result > 0)
                {
                    _retVal.Success = true;
                    _retVal.Message = AppResource.RoleAdded;
                    _retVal.Data = true;
                }
            }
            return _retVal;
        }
        public async Task<ServiceResponse<ViewRoleDto>> GetById(int id)
        {
            var _retVal = new ServiceResponse<ViewRoleDto>() { Data = new ViewRoleDto(), Message = AppResource.CommonError, Success = false };
            var obj = await _repo.GetByIdAsync(id);
            _retVal.Data = _mapper.Map<ViewRoleDto>(obj);
            if (_retVal.Data != null)
            {
                _retVal.Success = true;
                _retVal.Message = AppResource.CommonSuccess;
            }
            return _retVal;
        }
        public async Task<ServiceResponse<IEnumerable<ViewRoleDto>>> GetAll()
        {
            var _retVal = new ServiceResponse<IEnumerable<ViewRoleDto>>() { Data = null, Message = AppResource.CommonError, Success = false };

            var obj = await _repo.GetAllAsync();
            _retVal.Data = _mapper.Map<IEnumerable<ViewRoleDto>>(obj);

            if (_retVal.Data != null)
            {
                _retVal.Success = true;
                _retVal.Message = AppResource.CommonSuccess;
            }
            return _retVal;
        }
        public async Task<ServiceResponse> Delete(int id)
        {
            var _retVal = new ServiceResponse() { Message = AppResource.CommonError, Success = false };
            _repo.Delete(id);
            var _result = await _repo.SaveAsync();
            if (_result > 0)
            {
                _retVal.Success = true;
                _retVal.Message = AppResource.CommonSuccess;
            }
            return _retVal;
        }
        public async Task<ServiceResponse> SoftDelete(int id)
        {
            var _retVal = new ServiceResponse() { Message = AppResource.CommonError, Success = false };

            var obj = await _repo.GetByIdAsync(id);
            obj.IsDeleted = true;
            obj.LastModifiedBy = _userContext.RoleId;
            obj.LastModifiedOn = DateTime.Now;
            var _result = await _repo.SaveAsync();
            if (_result > 0)
            {
                _retVal.Success = true;
                _retVal.Message = AppResource.CommonSuccess;
            }
            return _retVal;
        }
    }
}
