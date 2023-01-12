using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, SynaverseLdapContext>, IOperationClaimDal
	{
	}

}
