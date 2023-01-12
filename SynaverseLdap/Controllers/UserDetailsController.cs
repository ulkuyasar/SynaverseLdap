//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Business.Abstract;
//using Entities.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace SynaverseLdap.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserDetailsController : ControllerBase
//    {
//        private IUserDetailService _UserDetailManager;
//        public UserDetailsController(IUserDetailService userdetailManager)
//        {
//            _UserDetailManager = userdetailManager;
//        }


//        [HttpGet("getall")]
//        //[Authorize(Roles = "Product.List")]  manager da yonet
//        public async Task<IActionResult> GetList()
//        {
//            //http://localhost/WebApi/api/UserDetails/getall
//            var result = await _UserDetailManager.GetListAsync(null);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet()]
//        //[Authorize(Roles = "Product.List")]  manager da yonet
//        public async Task<IActionResult> GetListAll()
//        {
//            //http://localhost/WebApi/api/UserDetails/getall
//            var result = await _UserDetailManager.GetListAsync(null);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("getlistbyotherobject")]
//        //[Authorize(Roles = "Product.List")]  manager da yonet
//        public async Task<IActionResult> GetListByOtherObject(int otherId)
//        {
//            var result = await _UserDetailManager.GetListAsync(otherId);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("getbyid")]
//        public async Task<IActionResult> GetById(Int32 id)
//        {
//            var result = await _UserDetailManager.GetByIdAsync(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("Add")]
  
//        public async Task<IActionResult> Add(UserDetail userdetail)
//        {
//            userdetail.Id = null;
//            var result = await _UserDetailManager.AddAsync(userdetail);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("Update")]
     
//        public async Task<IActionResult> Update(UserDetail userdetail)
//        {
//            var result = await _UserDetailManager.UpdateAsync(userdetail);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("Delete")]
       
//        public async Task<IActionResult> Delete(UserDetail userdetail)
//        {
//            var result = await _UserDetailManager.DeleteAsync(userdetail);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result.Message);
//        }



//    }


//}