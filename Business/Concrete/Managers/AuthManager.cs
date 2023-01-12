using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Enum;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
	public class AuthManager : IAuthService
	{
		private IUserService _userservice;
		private IUserDetailService _usersdetailservice;
		private IUserOperationClaimService _userOperationClaimService;
		private IOperationClaimService _operationClaimService;




		private ITokenHelper _tokenhelper;


		public AuthManager(IUserService userservice, ITokenHelper tokenhelper, IUserDetailService usersdetailervice, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
		{
			_userservice = userservice;
			_tokenhelper = tokenhelper;
			_usersdetailservice = usersdetailervice;
			_userOperationClaimService = userOperationClaimService;
			_operationClaimService = operationClaimService;
		}


		public async Task<IDataResult<User>> GetUserWithEmailAsync(string email)
		{
			var userToCheck = await _userservice.GetByEmailAsync(email);
			if (userToCheck.Data == null || userToCheck.Success == false)
			{
				return new ErrorDataResult<User>(Messages.UserNotFound);
			}
						
			return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfullToLogin);

		}


		public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
		{
			var userToCheck = await _userservice.GetByEmailAsync(userForLoginDto.Email);
			if ( userToCheck.Data == null || userToCheck.Success==false)
			{
				return new ErrorDataResult<User>(Messages.UserNotFound);
			}
			
			if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
			{
				return new ErrorDataResult<User>(Messages.PasswordError);
			}
			return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessfullToLogin);

		}

		//[TransactionScopeAspect]  bu aspect ıcın yogunlasman lazım. db nsertlerınde sorun yasatıyor
		public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
		{
			byte[] passwordHash, passwordSalt;
		    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
			var user = new User
			{
				Email = userForRegisterDto.Email,
				FirstName = userForRegisterDto.FirstName,
				LastName = userForRegisterDto.LastName,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				Status = false,
				FireBaseToken = "",
				RecordStatus = false,
				Pwd = password
				//,
				//Gender = userForRegisterDto.Gender,
				//Birthday = userForRegisterDto.Birthday
			};
			var result = await _userservice.AddAsync(user);

			var resultAsync = await _operationClaimService.GetListAsync(OperationClaimType.Default.ToString());
			List<OperationClaim> listClaim = resultAsync.Data;
			if (listClaim == null || listClaim.Count == 0)
				throw new Exception("Default user tanımı db de bulunmamaktadır. OperationClaim içinde bu tanım olmalı. Admın ıle iletişime gecilmeli");


			var userOperationClaim = new UserOperationClaim
			{
				Id = null,
				UserId = Convert.ToInt32( result.Data.Id.Value),
				OperationClaimId = Convert.ToInt32( listClaim[0].Id.Value)
			};
			await _userOperationClaimService.AddAsync(userOperationClaim);

			var userdetail = new UserDetail
			{
				Id = null,
				UserId = result.Data.Id.Value,
				Name = result.Data.FirstName,
				SurName = result.Data.LastName,
				PrefixName = "",
				RecordStatus = false,
				Birthday = Core.Utilities.DefaultValues.DefaultValue.DefaultTime
			};
			userdetail.SetDefaultValuesForIEntityExtendedId();
			await _usersdetailservice.AddAsync(userdetail);
			return new SuccessDataResult<User>(user,Messages.UserRegistered);
		}

		public async Task<IResult> UserExistsAsync(string email)
		{
			var resultUsers = await _userservice.GetByEmailAsync(email);
			if (resultUsers.Data != null)
			{
				return new ErrorResult(Messages.UserAlreadyExists);
			}
			return new SuccessResult();

		}

		public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
		{
			var claims = _userservice.GetClaimsAsync(user);
			var accessToken = await _tokenhelper.CreateTokenAsync(user,claims.Result.Data);
			return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
		}

		public async Task<IDataResult<User>> UpdateFireBaseTokenAsync(User user,string fireBaseToken)
        {
			return await _userservice.UpdateFireBaseTokenAsync(user, fireBaseToken);
		}
    }
}
