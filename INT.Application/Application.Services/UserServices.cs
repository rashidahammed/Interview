using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Application.Contexts;
using INT.Application.Model.Responses;
using INT.Domain.Domain.Interfaces;
using INT.Domain.Model;
using INT.Utility.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Services
{
    public class UserServices : IUserServices
    {

        private readonly IUserRepositories _repo;
        private readonly IRoleRepositories _releRepo;
        private readonly IUserRoleRepositories _userRoleRepo;


        public readonly IMapper _mapper;
        private readonly IValidationServices _validation;
        private readonly UserContext _UserContext;
        public UserServices(IUserRepositories repo, IRoleRepositories relerepo, IUserRoleRepositories userRoleRepo, IMapper mapper, IValidationServices validation, ICurrentUserContext UserContext)
        {
            _repo = repo;
            _mapper = mapper;
            _validation = validation;
            _UserContext = UserContext.GetUserContext();
            _releRepo = relerepo;
            _userRoleRepo = userRoleRepo;
        }
        public async Task<ServiceResponse<bool>> AddUser(UserCreateDto dto)
        {
            var _retVal = new ServiceResponse<bool>() { Data = false, Message = AppResource.CommonError, Success = false };
            bool _exist = await _validation.DoesUserExist(dto, null);
            if (_exist)
            {
                _retVal.Message = AppResource.UserAlreadyExist;
                return _retVal;
            }
            if (dto.UserRoles.Count == 0)
            {
                _retVal.Message = AppResource.RoleRequired;
                return _retVal;
            }
            else
            {
               if(!await _releRepo.DoRolesExistAsync(dto.UserRoles))
                {
                    _retVal.Message = AppResource.UserRolesDoesNotExist;
                    return _retVal;
                }
            }

            var hasher = new PasswordHasher<User>();
            dto.Password= hasher.HashPassword(null, dto.Password);

            var newEntity = _mapper.Map<User>(dto);
            newEntity.CreatedOn = DateTime.Now;
            newEntity.IsDeleted = false;
            newEntity.CreatedBy = _UserContext.UserId;
            await _repo.InsertAsync(newEntity);
            var _result = await _repo.SaveAsync();
            if (_result > 0)
            {
                var userRoles= await  _userRoleRepo.AddOrUpdateUserRoles(newEntity.Id, dto.UserRoles, _UserContext.UserId);

                _retVal.Success = true;
                _retVal.Message = AppResource.RoleAdded;
                _retVal.Data = true;
            }
            return _retVal;
        }
        public async Task<ServiceResponse<bool>> UpdateUser(UpdateUserDto dto)
        {
            var _retVal = new ServiceResponse<bool>() { Data = false, Message = AppResource.CommonError, Success = false };
            var obj = await _repo.GetByIdAsync(dto.Id);
            if (obj != null)
            {
                bool _exist = await _validation.DoesUserExist(dto, dto.Id);
                if (_exist)
                {
                    _retVal.Message = AppResource.RoleAlreadyExist;
                    return _retVal;
                }
                if (dto.UserRoles.Count == 0)
                {
                    _retVal.Message = AppResource.RoleRequired;
                    return _retVal;
                }
                else
                {
                    if (!await _releRepo.DoRolesExistAsync(dto.UserRoles))
                    {
                        _retVal.Message = AppResource.UserRolesDoesNotExist;
                        return _retVal;
                    }
                }

                obj.LastModifiedBy = _UserContext.UserId;
                obj.LastModifiedOn = DateTime.Now;

                _mapper.Map<UpdateUserDto, User>(dto, obj);
                var _result = await _repo.SaveAsync();
                if (_result > 0)
                {
                    var userRoles = await _userRoleRepo.AddOrUpdateUserRoles(obj.Id, dto.UserRoles, _UserContext.UserId);

                    _retVal.Success = true;
                    _retVal.Message = AppResource.UserAdded;
                    _retVal.Data = true;
                }
            }
            return _retVal;
        }
        //public async Task<ServiceResponse<ViewUserDto>> GetById(int id)
        //{
        //    var _retVal = new ServiceResponse<ViewUserDto>() { Data = new ViewUserDto(), Message = AppResource.CommonError, Success = false };
        //    var obj = await _repo.GetByIdAsync(id);
        //    _retVal.Data = _mapper.Map<ViewUserDto>(obj);
        //    if (_retVal.Data != null)
        //    {
        //        _retVal.Success = true;
        //        _retVal.Message = AppResource.CommonSuccess;
        //    }
        //    return _retVal;
        //}        //public async Task<ServiceResponse<ViewUserDto>> GetById(int id)
        //{
        //    var _retVal = new ServiceResponse<ViewUserDto>() { Data = new ViewUserDto(), Message = AppResource.CommonError, Success = false };
        //    var obj = await _repo.GetByIdAsync(id);
        //    _retVal.Data = _mapper.Map<ViewUserDto>(obj);
        //    if (_retVal.Data != null)
        //    {
        //        _retVal.Success = true;
        //        _retVal.Message = AppResource.CommonSuccess;
        //    }
        //    return _retVal;
        //}
        public async Task<ServiceResponse<IEnumerable<ViewUserDto>>> GetAll()
        {
            var _retVal = new ServiceResponse<IEnumerable<ViewUserDto>>() { Data = null, Message = AppResource.CommonError, Success = false };

            var obj = await _repo.GetAllAsync();
            _retVal.Data = _mapper.Map<IEnumerable<ViewUserDto>>(obj);

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
            obj.LastModifiedBy = _UserContext.UserId;
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
