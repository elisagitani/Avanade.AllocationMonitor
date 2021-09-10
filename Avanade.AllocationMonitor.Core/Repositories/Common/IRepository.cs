using Avanade.AllocationMonitor.Core.Entities.Common;
using System.Collections.Generic;

namespace Avanade.AllocationMonitor.Core.Repositories.Common
{
    /// <summary>
    /// Interface for entity repository
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface IRepository<TEntity>
        where TEntity: IEntity
    {
        /// <summary>
        /// Get single entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns entity or null</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Fetch all entities
        /// </summary>
        /// <returns>Returns list of entities</returns>
        IList<TEntity> FetchAll();

        /// <summary>
        /// Count all entities on storage
        /// </summary>
        /// <returns>Returns count of entities</returns>
        int CountAll();

        /// <summary>
        /// Creates entity on storage
        /// </summary>
        /// <param name="entity">Entity to create</param>
        void Create(TEntity entity);

        /// <summary>
        /// Updates single entity on storage 
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes entity on storage
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(TEntity entity);
    }
}
