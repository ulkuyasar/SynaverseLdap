using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IOperationClaimService
	{
		Task<IDataResult<List<OperationClaim>>> GetListAsync(string name);
		Task<IDataResult<OperationClaim>> GetByIdAsync(int id);
		Task<IResult> AddAsync(OperationClaim operationclaim);
		Task<IResult> UpdateAsync(OperationClaim operationclaim);
		Task<IResult> DeleteAsync(OperationClaim operationclaim);
	}

}
