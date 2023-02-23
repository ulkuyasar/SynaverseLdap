using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IUserOperationClaimService
	{
		Task<IDataResult<List<UserOperationClaim>>> GetListAsync(int? foreignObjectID);
		Task<IDataResult<UserOperationClaim>> GetByIdAsync(int id);
		Task<IResult> AddAsync(UserOperationClaim useroperationclaim);
		Task<IResult> UpdateAsync(UserOperationClaim useroperationclaim);
		Task<IResult> DeleteAsync(UserOperationClaim useroperationclaim);


		//yasar sil
        Task<IDataResult<User>> GetByEmailAsync(string email);
    }
}
