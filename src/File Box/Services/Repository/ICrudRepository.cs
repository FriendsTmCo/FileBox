using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Repository
{
    /// <summary>
    /// Crud Repository Services 
    /// </summary>
    /// <typeparam name="T">T Model</typeparam>
    public interface ICrudRepository<T>
    {
        /// <summary>
        /// Return All Model 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Return All Model With Expression
        /// </summary>
        /// <param name="where">Expression</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> where);

        /// <summary>
        /// Return All Model with Search
        /// </summary>
        /// <param name="q">Search Parameter</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetBySearchAsync(string q);

        /// <summary>
        /// Fidn Model 
        /// </summary>
        /// <param name="Id">Model Id</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(object Id);

        /// <summary>
        /// Insert New Model To Data Base
        /// </summary>
        /// <param name="tModel">T Model</param>
        /// <returns></returns>
        Task<bool> InsertAsync(T tModel);

        /// <summary>
        /// Update Model 
        /// </summary>
        /// <param name="tModel">T Model</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T tModel);

        /// <summary>
        /// Delete Model 
        /// </summary>
        /// <param name="tModel">T Model</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T tModel);

        /// <summary>
        /// Delete Model With Id
        /// </summary>
        /// <param name="Id">T Model Id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(object Id);

        /// <summary>
        /// Save All changes Async
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();

        /// <summary>
        /// Save All Changes
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
