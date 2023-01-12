using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserDetailService
	{
		Task<IDataResult<List<UserDetail>>> GetListAsync(int? foreignObjectID);
		Task<IDataResult<UserDetail>> GetByIdAsync(int id);
		Task<IResult> AddAsync(UserDetail userdetail);
		Task<IResult> UpdateAsync(UserDetail userdetail);
		Task<IResult> DeleteAsync(UserDetail userdetail);
	}

}
