
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
	public interface ITokenHelper
	{
		Task<AccessToken> CreateTokenAsync(User user,List<OperationClaim> operationClaims);
	}
}
