using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.RentDate!=null)
            {
                return new ErrorResult(Messages.InvalidAdd);
            }
            if (rental.RentalId == rental.RentalId)
            {
                return new ErrorResult(Messages.IdInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId!=rental.RentalId)
            {
                return new ErrorResult(Messages.IdInvalid + " " + Messages.InvalidDelete);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetByCustomerId(int customerId)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CustomerId == customerId), Messages.Listed);
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<Rental>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == rentalId), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentalId!=rental.RentalId)
            {
                return new ErrorResult(Messages.IdInvalid+" " + Messages.InvalidUpdate);
            }
            return new SuccessResult(Messages.Updated);
        }
    }
}
