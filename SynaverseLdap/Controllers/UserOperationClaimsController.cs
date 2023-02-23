using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.MethodAspects.Autofac;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SynaverseLdap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private IUserOperationClaimService _UserOperationClaimManager;
        
        public UserOperationClaimsController(IUserOperationClaimService useroperationclaimManager)
        {
            _UserOperationClaimManager = useroperationclaimManager;
           
        }

        //yasar sil
        [HttpGet("GetLDAPUserTestAsync")]
        
        public async Task<IActionResult> GetLDAPUserTestAsync()
        {
            var result = await _UserOperationClaimManager.GetByEmailAsync("cinaryilmaz156@gmail.com");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("GetList")]
       // [Authorize(Roles = "Default")]  //  manager da yonet
        public async Task<IActionResult> GetList()
        {
            var result = await _UserOperationClaimManager.GetListAsync(null);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyotherobject")]
        [Authorize(Roles = "Product.List")]  //manager da yonet
        public async Task<IActionResult> GetListByOtherObject(int otherId)
        {
            var result = await _UserOperationClaimManager.GetListAsync(otherId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Int32 id)
        {
            var result = await _UserOperationClaimManager.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Add")]
    
        public async Task<IActionResult> Add(UserOperationClaim useroperationclaim)
        {
            useroperationclaim.Id = null;
            var result = await _UserOperationClaimManager.AddAsync(useroperationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Update")]
    
        public async Task<IActionResult> Update(UserOperationClaim useroperationclaim)
        {
            var result = await _UserOperationClaimManager.UpdateAsync(useroperationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Delete")]

        public async Task<IActionResult> Delete(UserOperationClaim useroperationclaim)
        {
            var result = await _UserOperationClaimManager.DeleteAsync(useroperationclaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }


}