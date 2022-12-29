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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<1)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            if (customer.CustomerId == customer.CustomerId)
            {
                return new ErrorResult(Messages.IdInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId!=customer.CustomerId)
            {
                return new ErrorResult(Messages.IdInvalid + " " + Messages.InvalidDelete);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Customer>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.CustomerId==customerId),Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CustomerId!=customer.CustomerId)
            {   
                return new ErrorResult(Messages.IdInvalid+" " + Messages.InvalidUpdate);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
