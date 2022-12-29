using Business.Abstract;
using Business.Constants;
using Core.Utulities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarDescription.Length > 1 && car.CarDailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.InvalidAdd);
            }
        }

        public IResult Delete(Car car)
        {
            if (car.CarId == car.CarId)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.Deleted);
            }
            else
            {
                return new ErrorResult(Messages.InvalidDelete);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarDailyPrice >= min && p.CarDailyPrice <= max), Messages.Listed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Car>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.CarId== carId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        public IResult Update(Car car)
        {
            if (car.CarDescription.Length < 1)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            if (car.CarId != car.CarId)
            {
                return new ErrorResult(Messages.IdInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
