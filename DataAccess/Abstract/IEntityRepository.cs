using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic constraint 
    //class : referans tip
    //IEntity: IEntity olabilir ya da IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olabilir. ---IEntity newlenemeyeceği için koyamayız.
    public interface IEntityRepository<T> where T:class,IEntity,new() //Generic
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);//Filtreleme yapmamı sağlar
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
