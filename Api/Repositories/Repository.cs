using Api.Models;
using Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LrsContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context of type LrsContext</param>
        public Repository(LrsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GetById method
        /// Receives an id and returns an entity with that id
        /// </summary>
        /// <param name="id">Parameter id is of type int</param>
        /// <returns>
        /// An instance of type T
        /// </returns>
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// GetAll method
        /// Returns a collection of T
        /// </summary>
        /// <returns>
        /// An IEnumerable collection of type T
        /// </returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Find method
        /// Receives an Expression of Func (delegate),
        /// such as a lambda expression and returns
        /// a collection of T
        /// </summary>
        /// <param name="predicate">An Expression of Func (delegate)</param>
        /// <returns>
        /// An IEnumerable collection of type T
        /// </returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// SingleOrDefault method
        /// Receives an Expression of Func (delegate),
        /// such as a lambda expression and returns
        /// an instance of T
        /// </summary>
        /// <param name="predicate">An Expression of Func (delegate)</param>
        /// <returns>
        /// An instance of type T
        /// </returns>
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Add method
        /// Receives an entity and adds it to the Repository
        /// </summary>
        /// <param name="entity">An instance of type T</param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Remove method
        /// Receives an entity and removes it from the Repository
        /// </summary>
        /// <param name="entity">An instance of type T</param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Total number of records
        /// </summary>
        /// <returns>
        /// An integer that represents the total number of records
        /// </returns>
        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}
