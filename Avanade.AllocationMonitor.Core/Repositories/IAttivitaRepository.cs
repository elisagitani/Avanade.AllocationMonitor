using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Repositories.Common;
using System.Collections.Generic;

namespace Avanade.AllocationMonitor.Core.Repositories
{
    /// <summary>
    /// Interface for entity "Attivita"
    /// </summary>
    public interface IAttivitaRepository : IRepository<Attivita>
    {
        /// <summary>
        /// Recupera la lista delle attività su commessa
        /// </summary>
        /// <param name="commessa">Commessa</param>
        /// <returns>Ritorna gli elementi</returns>
        IList<Attivita> FetchByCommessa(Cliente commessa);
    }
}
