using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entitiy)
        {
            using (NorthwindContext context = new NorthwindContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {

            }
        }

        public void Delete(Product entitiy)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
