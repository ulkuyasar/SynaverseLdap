using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, SynaverseLdapContext>, IUserDal
	{
		public async Task<List<OperationClaim>> GetClaimsAsync(User user)
		{
			 using (var context = new SynaverseLdapContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims
								on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
				return result.ToList();
			}
		}
	}
}
