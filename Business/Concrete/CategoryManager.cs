using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal; //constructor injection
        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Category>>  GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Select * from Categories where CategoryId = categoryId
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId == categoryId));
        }
    }
}
