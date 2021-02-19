using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        //interface metodları default publicdir ⬇
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //filter = null filter is not compulsory
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entitiy);
        void Update(T entitiy);
        void Delete(T entitiy);
    }
}
