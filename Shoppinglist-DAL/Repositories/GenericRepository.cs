using Microsoft.EntityFrameworkCore;
using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object=context.Set<T>();
        }

        public void Delete(T t)
        {
            _object.Remove(t);
            context.SaveChanges();
        }

        public void DeleteByStatus(T t)
        {
            var deletedEntity = context.Entry(t);
            deletedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.Single(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = context.Entry(t);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = context.Entry(t);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
