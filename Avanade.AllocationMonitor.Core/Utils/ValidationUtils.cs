using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Avanade.AllocationMonitor.Core.Entities.Common;

namespace Avanade.AllocationMonitor.Core.Utils
{
    /// <summary>
    /// Contains utilities for validations
    /// </summary>
    public static class ValidationUtils
    {
        /// <summary>
        /// Validates provided entity using data annotations
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity to validate</param>
        /// <returns>Returns list of validations</returns>
        public static IList<ValidationResult> Validate<TEntity>(TEntity entity)
            where TEntity : IEntity
        {
            //Validazione argomenti
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //Validation context e lista di validazioni in uscita
            var validations = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(entity);
            Validator.TryValidateObject(entity, context, validations, true);
            return validations;
        }
    }
}
