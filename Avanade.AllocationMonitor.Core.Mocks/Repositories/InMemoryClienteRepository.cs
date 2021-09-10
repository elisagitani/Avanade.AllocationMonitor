using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Cliente" with in-memory engine
    /// </summary>
    public class InMemoryClienteRepository: InMemoryRepositoryBase<Cliente>, IClienteRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryClienteRepository() 
            : base(storage => storage.Clienti) { }

        /// <summary>
        /// Crea un elemento tramite testo
        /// </summary>
        /// <param name="searchText">Stringa di ricerca</param>
        /// <returns>Ritorna una lista</returns>
        public IList<Cliente> Search(string searchText)
        {
            //Se viene passato vuoto, esco
            if (string.IsNullOrEmpty(searchText))
                return new List<Cliente>();

            //Recupero tutti gli elementi e cerco con LINQ
            return WorkingCollection
                .Where(e =>
                    (e.Nome != null && e.Nome.Contains(searchText)) ||
                    (e.Citta != null && e.Citta.Contains(searchText)) ||
                    (e.Provincia != null && e.Provincia.Contains(searchText)) ||
                    (e.Regione != null && e.Regione.Contains(searchText)) ||
                    (e.NomeRiferimento != null && e.NomeRiferimento.Contains(searchText)) ||
                    (e.EmailRiferimento != null && e.EmailRiferimento.Contains(searchText))
                )
                .ToList();
        }
    }
}
