using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
	public class UserManager : IUserService
	{
		private IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public async Task<IDataResult<User>> AddAsync(User user)
		{
			var resullt = await _userDal.AddAsync(user);
			return new SuccessDataResult<User>(resullt);
		}

		public async Task<IDataResult<User>> GetByEmailAsync(string email)
		{
			return new SuccessDataResult<User>(await _userDal.GetAsync(x => x.Email == email));
		}

		public async Task<IDataResult<User>> GetByIdAsync(Int64 userId)
		{
			return new SuccessDataResult<User>(await _userDal.GetAsync(x => x.Id == userId));
		}

		public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(User user)
		{
			List<OperationClaim> listOperationClaim = null;
			listOperationClaim = await _userDal.GetClaimsAsync(user);
			return new SuccessDataResult<List<OperationClaim>>(listOperationClaim);
		}

        public async Task<IDataResult<User>> UpdateFireBaseTokenAsync(User user, string fireBaseToken)
        {
			user.FireBaseToken = fireBaseToken;
			var resullt = await  _userDal.UpdateAsync(user);
			return new SuccessDataResult<User>(resullt);
		}
    }
}
