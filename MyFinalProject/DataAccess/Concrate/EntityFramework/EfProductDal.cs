using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var addedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                addedEntity.State = EntityState.Added;//state = ekleme 
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var deletedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                deletedEntity.State = EntityState.Deleted;//state = ekleme 
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // context.Set<Product>() = a list
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var updatedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                updatedEntity.State = EntityState.Modified;//state = ekleme 
                context.SaveChanges();
            }
        }
    }
}
