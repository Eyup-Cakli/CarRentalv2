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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length<1)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            if (color.ColorId == color.ColorId)
            {
                return new ErrorResult(Messages.IdInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            if (color.ColorId!=color.ColorId)
            {
                return new ErrorResult(Messages.IdInvalid+" "+Messages.InvalidDelete);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintananceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult(Messages.MaintananceTime);
            }
            if (color.ColorId!=color.ColorId)
            {
                return new ErrorResult(Messages.IdInvalid+" "+Messages.InvalidDelete);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
