using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;
using Avanade.AllocationMonitor.Core.Mocks.Storages;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Attivita" with in-memory engine
    /// </summary>
    public class InMemoryAttivitaRepository: InMemoryRepositoryBase<Attivita>, IAttivitaRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryAttivitaRepository() 
            : base(storage => storage.Attivitas) { }

        /// <summary>
        /// Recupera la lista delle attività su commessa
        /// </summary>
        /// <param name="commessa">Commessa</param>
        /// <returns>Ritorna gli elementi</returns>
        public IList<Attivita> FetchByCommessa(Cliente commessa)
        {
            //Recupero dallo storage eseguendo una query con LINQ
            return InMemoryStorage.Default.Attivitas
                .Where(a => a.Commessa.Id == commessa.Id)
                .ToList();
        }
    }
}
