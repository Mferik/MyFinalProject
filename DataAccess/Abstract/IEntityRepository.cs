using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> //Generic
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Filtreleme yapmamı sağlar
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(Product entity);


    }
}
