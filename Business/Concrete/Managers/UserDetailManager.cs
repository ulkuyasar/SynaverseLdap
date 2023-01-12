using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class UserDetailManager : IUserDetailService
    {
        private IUserDetailDal _UserDetailDal;
        public UserDetailManager(IUserDetailDal userdetail)
        {
            _UserDetailDal = userdetail;
        }

        public async Task<IResult> AddAsync(UserDetail userdetail)
        {
            var result = await _UserDetailDal.AddAsync(userdetail);
            return new SuccessDataResult<UserDetail>(result, "00", Messages.SuccessAdded);
        }
        public async Task<IResult> UpdateAsync(UserDetail userdetail)
        {
            var result = await _UserDetailDal.UpdateAsync(userdetail);
            return new SuccessDataResult<UserDetail>(result, "00", Messages.SuccessUpdated);
        }
        public async Task<IResult> DeleteAsync(UserDetail userdetail)
        {
            await _UserDetailDal.DeleteAsync(userdetail);
            return new SuccessResult("00", Messages.SuccessDeleted);
        }
        public async Task<IDataResult<UserDetail>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<UserDetail>(await _UserDetailDal.GetAsync(x => x.Id == id));
        }
        public async Task<IDataResult<List<UserDetail>>> GetListAsync(int? foreignObjectID)
        {
            List<UserDetail> listUserDetail = null;
            if (foreignObjectID != null && foreignObjectID > 0)
            {
                listUserDetail = await _UserDetailDal.GetListAsync(p => p.UserId == foreignObjectID);
            }
            else
            {
                listUserDetail = await _UserDetailDal.GetListAsync();
            }
            return new SuccessDataResult<List<UserDetail>>(listUserDetail);
        }


    }



}