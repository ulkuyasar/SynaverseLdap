using Business.Abstract;
using Business.Constants;
using Business.MethodAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _OperationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationclaim)
        {
            _OperationClaimDal = operationclaim;
        }

        public async Task<IResult> AddAsync(OperationClaim operationclaim)
        {
            var result = await _OperationClaimDal.AddAsync(operationclaim);
            return new SuccessDataResult<OperationClaim>(result, "00", Messages.SuccessAdded);
        }
        public async Task<IResult> UpdateAsync(OperationClaim operationclaim)
        {
            var result = await _OperationClaimDal.UpdateAsync(operationclaim);
            return new SuccessDataResult<OperationClaim>(result, "00", Messages.SuccessUpdated);
        }
        public async Task<IResult> DeleteAsync(OperationClaim operationclaim)
        {
            await _OperationClaimDal.DeleteAsync(operationclaim);
            return new SuccessResult("00", Messages.SuccessDeleted);
        }
        public async Task<IDataResult<OperationClaim>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<OperationClaim>(await _OperationClaimDal.GetAsync(x => x.Id == id));
        }

        
        public async Task<IDataResult<List<OperationClaim>>> GetListAsync(string name)
        {
            List<OperationClaim> listOperationClaim = null;
            if (!string.IsNullOrEmpty(name))
            {
                listOperationClaim = await _OperationClaimDal.GetListAsync(p => p.Name == name);
            }
            else
            {
                listOperationClaim = await _OperationClaimDal.GetListAsync();
            }
            return new SuccessDataResult<List<OperationClaim>>(listOperationClaim);
        }



    }

}