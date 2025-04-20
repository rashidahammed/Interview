using AutoMapper;
using INT.Application.Application.Core;
using INT.Application.Application.Interfaces;
using INT.Application.Model.Requests;
using INT.Application.Model.Responses;
using INT.Utility.Resources;
using Microsoft.AspNetCore.Mvc;

namespace INT.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleServices _service;
        private readonly IValidationServices _validation;

        public readonly IMapper _mapper;
        public RoleController(IRoleServices service, IMapper mapper, IValidationServices validation)
        {
            _service = service;
            _mapper = mapper;
            _validation = validation;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
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
        public async Task<IActionResult> Create([FromBody] CreateRoleVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.AddRole(_mapper.Map<RoleDto>(model));
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
        public async Task<IActionResult> Update([FromBody] UpdateRoleVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.UpdateRole(_mapper.Map<UpdateRoleDto>(model));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var result = await _service.Delete(id);
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
        public async Task<IActionResult> SoftDelete(int id)
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
