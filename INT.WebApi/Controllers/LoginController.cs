using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Utility;
using INT.Utility.Resources;
using INT.WebApi.Model.Requests;
using Microsoft.AspNetCore.Mvc;

namespace INT.WebApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLoginServices _service;

        public readonly IMapper _mapper;
        public LoginController(IMapper mapper, IUserLoginServices service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReqVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.Login(_mapper.Map<LoginDto>(model));
                return Ok(result);
            }
            catch (Exception ex)
            {
                {
                    var _retVal = new ServiceResponse()
                    {
                        Success = false,
                        Message = AppResource.CommonError,
                    };
                    return Ok(_retVal);
                }
            }

        }

    }
}
