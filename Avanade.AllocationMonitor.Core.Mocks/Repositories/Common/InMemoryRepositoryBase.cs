using Avanade.AllocationMonitor.Core.Entities.Common;
using Avanade.AllocationMonitor.Core.Repositories.Common;
using Avanade.AllocationMonitor.Core.Mocks.Storages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories.Common
{
    /// <summary>
    /// Abstract base class for in-memory repository
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public abstract class InMemoryRepositoryBase<TEntity>: IRepository<TEntity>
        where TEntity: class, IEntity, new()
    {
        /// <summary>
        /// List of working collection
        /// </summary>
        protected IList<TEntity> WorkingCollection { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listOfEntitiesOnStorage">Expression for list of entities exposed on storage class</param>
        protected InMemoryRepositoryBase(Func<InMemoryStorage, IList<TEntity>> listOfEntitiesOnStorage) 
        {
            //Validazione argomenti
            if (listOfEntitiesOnStorage == null) throw new ArgumentNullException(nameof(listOfEntitiesOnStorage));

            //Recupero la collezione di lavoro usando il delegato ("function expression")
            WorkingCollection = listOfEntitiesOnStorage(InMemoryStorage.Default);
        }

        /// <summary>
        /// Count all entities on storage
        /// </summary>
        /// <returns>Returns count of entities</returns>
        public int CountAll()
        {
            //COnteggio di tutto
            return WorkingCollection.Count;
        }

        /// <summary>
        /// Creates entity on storage
        /// </summary>
        /// <param name="entity">Entity to create</param>
        public void Create(TEntity entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Assegno un identificatore (il massimo + 1)
            entity.Id = (WorkingCollection.Max(e => e.Id) ?? 0) + 1;

            //Aggiunta alla lista di lavoro
            WorkingCollection.Add(entity);
        }

        /// <summary>
        /// Deletes entity on storage
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        public void Delete(TEntity entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Se ho passato una entity con Id nullo, eccezione
            if (entity.Id == null)
                throw new InvalidOperationException("Provided entity has invalid identifier");

            //Recupero l'elemento dalla collezione di lavoro
            var existing = WorkingCollection.SingleOrDefault(e => e.Id == entity.Id);

            //Se NON ho trovato l'entità, esco
            if (existing == null)
                return;

            //Procedo alla rimozione
            WorkingCollection.Remove(existing);
        }

        /// <summary>
        /// Fetch all entities
        /// </summary>
        /// <returns>Returns list of entities</returns>
        public IList<TEntity> FetchAll()
        {
            //Ritorno tutta la lista
            return WorkingCollection.ToList();
        }

        /// <summary>
        /// Get single entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns entity or null</returns>
        public TEntity GetById(int id)
        {
            //Se l'id è minore uguale a zero, null
            if (id < 0) 
                return null;

            //Ricerco l'oggetto per Id
            return WorkingCollection.SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Updates single entity on storage 
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(TEntity entity)
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Se ho passato una entity con Id nullo, eccezione
            if (entity.Id == null)
                throw new InvalidOperationException("Provided entity has invalid identifier");

            //Recupero l'elemento dalla collezione di lavoro
            var existing = WorkingCollection.SingleOrDefault(e => e.Id == entity.Id);

            //Se NON ho trovato l'entità, esco
            if (existing == null)
                return;

            //Se lo trovo, rimuovo l'elemento
            WorkingCollection.Remove(existing);

            //Aggiungo quello nuovo per evitare di rimappare le proprietà
            WorkingCollection.Add(entity);
        }
    }
}