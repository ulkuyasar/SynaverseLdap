using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAuthService
	{
		Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto,string password);
		Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
		Task<IResult> UserExistsAsync(string email);
		Task<IDataResult<User>> UpdateFireBaseTokenAsync(User user, string fireBaseToken);
		Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);

		Task<IDataResult<User>> GetUserWithEmailAsync(string email);  // bunu ucuracaksın... angular testlerı ıcın eklendı

		
	}
}
