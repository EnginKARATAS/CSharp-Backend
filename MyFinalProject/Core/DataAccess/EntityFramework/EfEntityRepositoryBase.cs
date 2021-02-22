using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var addedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                addedEntity.State = EntityState.Added;//state = ekleme 
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var deletedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                deletedEntity.State = EntityState.Deleted;//state = durum  
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // context.Set<Product>() = a list
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())//using garbage collectore gelince işlem yapıp bittikten sonra garıç garbıç beni sil hemen diyor. bunun nedeni Context nesnesi nin maliyetidir. yani biz bu maliyeti en aza indirgemek için contex nesnesini garbage den hemen silmek istedik
            {
                var updatedEntity = context.Entry(entity); //veritabanındaki entity refereansini yakala
                updatedEntity.State = EntityState.Modified;//state = ekleme 
                context.SaveChanges();
            }
        }
    }
}
