using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Utils.Extensions
{
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Generates a summary with all validations
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <returns>Returns list of validations</returns>
        public static string AsSummary(this IEnumerable<ValidationResult> instance) 
        {
            //Validazione degli argomenti
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            //Lista dei messaggi falliti
            IList<string> messages = instance
                .Select(v => v.ErrorMessage)
                .ToList();

            //Join di tutti i messaggi con ritorno a capo
            return string.Join("\n", messages);
        }
    }
}
