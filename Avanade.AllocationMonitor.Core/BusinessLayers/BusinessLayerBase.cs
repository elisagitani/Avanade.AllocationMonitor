using Avanade.AllocationMonitor.Core.Entities.Common;
using Avanade.AllocationMonitor.Core.Repositories.Common;
using Avanade.AllocationMonitor.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avanade.AllocationMonitor.Core.BusinessLayers
{
    /// <summary>
    /// Base abstract class for business layers
    /// </summary>
    public abstract class BusinessLayerBase
    {
        /// <summary>
        /// Fetch all elements for provided repository
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="repository">Repository instance</param>
        /// <returns>Returns elements</returns>
        protected IList<TEntity> FetchAllEntities<TEntity>(IRepository<TEntity> repository)
            where TEntity : class, IEntity, new()
        {
            //Validazione argomenti
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            //Utilizzo la funzione sul repository
            return repository.FetchAll();
        }

        /// <summary>
        /// Creates a entity using entity and repository
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="repository">Repository instance</param>
        /// <returns>Returns list of validations</returns>
        protected IList<ValidationResult> CreateEntity<TEntity>(TEntity entity, IRepository<TEntity> repository)
            where TEntity : class, IEntity, new()
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            repository.Create(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        /// <summary>
        /// Updates a entity using entity and repository
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="repository">Repository instance</param>
        /// <returns>Returns list of validations</returns>
        protected IList<ValidationResult> UpdateEntity<TEntity>(TEntity entity, IRepository<TEntity> repository)
            where TEntity : class, IEntity, new()
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            repository.Update(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }

        /// <summary>
        /// Deletes a entity using entity and repository
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="repository">Repository instance</param>
        /// <returns>Returns list of validations</returns>
        protected IList<ValidationResult> DeleteEntity<TEntity>(TEntity entity, IRepository<TEntity> repository)
            where TEntity : class, IEntity, new()
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validazione dell'oggetto
            var validations = ValidationUtils.Validate(entity);

            //Se ho validazioni fallite, non vado avanti
            if (validations.Count > 0)
                return validations;

            //Chiedo al repository di creare
            repository.Delete(entity);

            //Ritorno le validazioni (che sono vuote) per segnalare
            //che tutto è andato a buon fine
            return validations;
        }
    }
}
