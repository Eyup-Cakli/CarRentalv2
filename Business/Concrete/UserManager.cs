using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utulities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            if (user.UserId!=user.UserId)
            {
                return new ErrorResult(Messages.InvalidDelete);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<User>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == userId), Messages.Listed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
