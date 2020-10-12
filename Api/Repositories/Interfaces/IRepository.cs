using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Repositories.Interfaces
{
    /// <summary>
    /// The IRepository generic interface.
    /// This interface describes a collection of objects in memory.
    /// 1. Helps to decouple application from persistence frameworks.
    /// 2. Minimizes duplicate query logic.
    /// 3. Promotes testbility.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// GetById method
        /// Receives an id and returns an entity with that id
        /// </summary>
        /// <param name="id">Parameter id is of type int</param>
        /// <returns>An instance of type T</returns>
        T GetById(int id);

        /// <summary>
        /// GetAll method
        /// Returns a collection of T
        /// </summary>
        /// <returns>An IEnumerable collection of type T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Find method
        /// Receives an Expression of Func (delegate), 
        /// such as a lambda expression and returns
        /// a collection of T
        /// </summary>
        /// <param name="predicate">An Expression of Func (delegate)</param>
        /// <returns>An IEnumerable collection of type T</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// SingleOrDefault method
        /// Receives an Expression of Func (delegate), 
        /// such as a lambda expression and returns
        /// an instance of T
        /// </summary>
        /// <param name="predicate">An Expression of Func (delegate)</param>
        /// <returns>An instance of type T</returns>
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add method
        /// Receives an entity and adds it to the Repository
        /// </summary>
        /// <param name="entity">An instance of type T</param>
        void Add(T entity);

        /// <summary>
        /// Remove method
        /// Receives an entity and removes it from the Repository
        /// </summary>
        /// <param name="entity">An instance of type T</param>
        void Remove(T entity);


        /// <summary>
        /// Total number of records
        /// </summary>
        /// <returns>An integer that represents the total number of records</returns>
        int Count();
    }
}
