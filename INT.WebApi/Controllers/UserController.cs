using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Utility;
using INT.Utility.Resources;
using INT.WebApi.Model.Requests;
using Microsoft.AspNetCore.Mvc;

namespace INT.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _service;

        public readonly IMapper _mapper;
        public UserController(IUserServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _service.GetAll();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var result = await _service.GetById(id);
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.AddUser(_mapper.Map<UserCreateDto>(model));
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

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.UpdateUser(_mapper.Map<UpdateUserDto>(model));
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

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(long id)
        {
            try
            {
                var result = await _service.SoftDelete(id);
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
