using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Core.Responses;
using INT.Application.Application.Interfaces;
using INT.Domain.Domain.Interfaces;
using INT.Utility;
using INT.Utility.Resources;

namespace INT.Application.Application.Services
{
    public class UserLoginServices : IUserLoginServices
    {
        private readonly IUserRepositories _repo;
        public readonly IMapper _mapper;
        private readonly IValidationServices _validation;
        private readonly IJwtTokenService _iJwtTokenService;

        public UserLoginServices(IUserRepositories repo, IMapper mapper, IValidationServices validation, IJwtTokenService iJwtTokenService)
        {
            _repo = repo;
            _mapper = mapper;
            _validation = validation;
            _iJwtTokenService = iJwtTokenService;
        }
        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginDto loginDto)
        {
            var _result = new ServiceResponse<LoginResponseDto>() { Success = true, Message = AppResource.CommonSuccess,Data=new LoginResponseDto() };
            var user = await _repo.GetUseDetailsForLogin(loginDto.UserName, loginDto.Password);
            if (user != null)
            {
                _result.Data.Token = _iJwtTokenService.GenerateToken(user.Id, user.UserName, user.Email);
                _result.Data.Name = user.Name;
                _result.Data.Email = user.Email;
            }
            else
            {
                _result.Message = AppResource.LoginFailedMsg;
                _result.Success = false;
            }
            return _result;
        }
    }
}
