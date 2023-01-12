using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SynaverseLdap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;
        private IUserDetailService _UserDetailManager;

        public AuthsController(IAuthService authService, IUserDetailService userDetailManager)
        {
            _authService = authService;
            _UserDetailManager = userDetailManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.LoginAsync(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var tokenResult =  await _authService.CreateAccessTokenAsync(result.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }
            return BadRequest(tokenResult.Message);
        }


        [HttpGet("loginwithUserAndPwd")]
        [Route("loginwithUserAndPwd")]
        public async Task<IActionResult> loginwithUserAndPwd(string email , string pwd)
        {
            //http://localhost/WebApi/api/Auths/loginwithUserAndPwd?email=ulkuyasaryilmaz@gmail.com&pwd=1234
            UserForLoginDto dto = new UserForLoginDto()
            {
                Email = email,
                Password = pwd
            };
          
            var result = await _authService.LoginAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var tokenResult = await _authService.CreateAccessTokenAsync(result.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }
            return BadRequest(tokenResult.Message);
        }

        [HttpGet("refreshToken")]
        [Route("refreshToken")]
        public async Task<IActionResult> refreshToken(bool withCredentials)
        {
            //http://localhost/WebApi/api/Auths/refreshToken
            // bu methodu revize etmelisin... bu halde olmamalı

            var result = await _authService.GetUserWithEmailAsync("ulkuyasaryilmaz@gmail.com");
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var tokenResult = await _authService.CreateAccessTokenAsync(result.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }
            return BadRequest(tokenResult.Message);
        }

        [HttpGet("loginwithUserAndPwdAndFirebaseToken")]
        [Route("loginwithUserAndPwdAndFirebaseToken")]
        public async Task<IActionResult> loginwithUserAndPwdAndFirebaseToken(string email, string pwd,string firebaseToken)
        {
            UserForLoginDto dto = new UserForLoginDto()
            {
                Email = email,
                Password = pwd
            };

            var result = await _authService.LoginAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            await _authService.UpdateFireBaseTokenAsync(result.Data, firebaseToken);//firebaseToken db ye yazılıyor
            var tokenResult = await _authService.CreateAccessTokenAsync(result.Data);
            if (tokenResult.Success)
            {
                return Ok(tokenResult);
            }
            return BadRequest(tokenResult.Message);
        }


        


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForregisterDto)
        {
            var userExist = await _authService.UserExistsAsync(userForregisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = await _authService.RegisterAsync(userForregisterDto, userForregisterDto.Password);
            var result = await _authService.CreateAccessTokenAsync(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Int32 id)
        {
            var result = await _UserDetailManager.GetListAsync(id);
            if (result.Success && result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}