using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserService
	{
		Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(User user);
		Task<IDataResult<User>> GetByEmailAsync(string email);
		Task<IDataResult<User>> AddAsync(User user);
		Task<IDataResult<User>> GetByIdAsync(Int64 userId);
		Task<IDataResult<User>> UpdateFireBaseTokenAsync(User user, string fireBaseToken);
	}
}
