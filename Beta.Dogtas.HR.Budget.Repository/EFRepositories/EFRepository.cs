using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Beta.Dogtas.HR.Budget.Repository.EFRepositories
{
    public class EFRepository<T, TOc>  where T : class
        where TOc : DbContext, new()
    {
        private TOc _context;
        private string _idColumnName;
        public EFRepository()
        {
            _context = new TOc();
            _idColumnName = ((IObjectContextAdapter) _context)
                .ObjectContext
                .CreateObjectSet<T>()
                .EntitySet
                .ElementType
                .KeyMembers[0]
                .ToString();
        }
        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public List<T> Read()
        {
            return _context.Set<T>().ToList();
        }
        public T Read(int id)
        {
            var itemParameter = Expression.Parameter(typeof(T),"item");
            var whereExpression = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(itemParameter, _idColumnName), Expression.Constant(id)), new[] {itemParameter});
            return _context.Set<T>().FirstOrDefault(whereExpression);
        }
        public void Update(T item)
        {
            _context.Set<T>().Attach(item);
            _context.SaveChanges();
        }
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
    }
}
