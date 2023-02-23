using Business.Abstract;
using Business.MethodAspects.Autofac;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SynaverseLdap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly ILogger<OperationClaimsController> _logger;
        private IOperationClaimService _OperationClaimManager;
        public OperationClaimsController(IOperationClaimService operationclaimManager, ILogger<OperationClaimsController> logger)
        {
            _OperationClaimManager = operationclaimManager;
            _logger = logger;
        }

        [HttpGet("GetList")]
        //[Authorize(Roles = "Product.List")]  manager da yonet
        public async Task<IActionResult> GetList()
        {
            var result = await _OperationClaimManager.GetListAsync(null);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListByOtherObject/{name}")]
        //[Authorize(Roles = "Product.List")]  manager da yonet
        
        public async Task<IActionResult> GetListByOtherObject(string name)
        {
            var result = await _OperationClaimManager.GetListAsync(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _OperationClaimManager.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] OperationClaim operationclaim)
        {
            operationclaim.Id = null;
            var result = await _OperationClaimManager.AddAsync(operationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] OperationClaim operationclaim)
        {
            var result = await _OperationClaimManager.UpdateAsync(operationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] OperationClaim operationclaim)
        {
            var result = await _OperationClaimManager.DeleteAsync(operationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }


}