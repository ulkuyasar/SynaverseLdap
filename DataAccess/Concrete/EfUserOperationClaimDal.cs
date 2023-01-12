using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, SynaverseLdapContext>, IUserOperationClaimDal
	{
	}


}
