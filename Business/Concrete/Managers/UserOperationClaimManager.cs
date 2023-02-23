using Business.Abstract;
using Business.Constants;
using Business.MethodAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _UserOperationClaimDal;
        private IUserDal _UserDal;

        public UserOperationClaimManager(IUserOperationClaimDal useroperationclaim, IUserDal userDal)
        {
            _UserOperationClaimDal = useroperationclaim;
            _UserDal = userDal;
        }
        //[ValidationAspect(typeof(UserOperationClaimValidator), Priority = 1)]
        public async Task<IResult> AddAsync(UserOperationClaim useroperationclaim)
        {
            var result = await _UserOperationClaimDal.AddAsync(useroperationclaim);
            return new SuccessDataResult<UserOperationClaim>(result, "00", Messages.SuccessAdded);
        }
        public async Task<IResult> UpdateAsync(UserOperationClaim useroperationclaim)
        {
            var result = await _UserOperationClaimDal.UpdateAsync(useroperationclaim);
            return new SuccessDataResult<UserOperationClaim>(result, "00", Messages.SuccessUpdated);
        }
        public async Task<IResult> DeleteAsync(UserOperationClaim useroperationclaim)
        {
            await _UserOperationClaimDal.DeleteAsync(useroperationclaim);
            return new SuccessResult("00", Messages.SuccessDeleted);
        }
        public async Task<IDataResult<UserOperationClaim>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(await _UserOperationClaimDal.GetAsync(x => x.Id == id));
        }

       
        public async Task<IDataResult<List<UserOperationClaim>>> GetListAsync(int? foreignObjectID)
        {
            List<UserOperationClaim> listUserOperationClaim = null;
            if (foreignObjectID != null && foreignObjectID > 0)
            {
                listUserOperationClaim = await _UserOperationClaimDal.GetListAsync(p => p.UserId == foreignObjectID);
            }
            else
            {
                listUserOperationClaim = await _UserOperationClaimDal.GetListAsync();
            }
            return new SuccessDataResult<List<UserOperationClaim>>(listUserOperationClaim);
        }

        [SecuredOperation("Admin")]   // super kullanım
        public async Task<IDataResult<User>> GetByEmailAsync(string email)
        {

            return new SuccessDataResult<User>(await _UserDal.GetAsync(x => x.Email == "hamza.cetin@gmail.com"));
           //return _UserDal.GetAsync(x=>x.Email.Equals( "hamza.cetin@gmail.com"));   
        }
    }

}