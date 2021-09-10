using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Repositories.Common;
using System.Collections.Generic;

namespace Avanade.AllocationMonitor.Core.Repositories
{
    /// <summary>
    /// Interface for entity "Cliente"
    /// </summary>
    public interface IClienteRepository : IRepository<Cliente>
    {
        /// <summary>
        /// Crea un elemento tramite testo
        /// </summary>
        /// <param name="searchText">Stringa di ricerca</param>
        /// <returns>Ritorna una lista</returns>
        IList<Cliente> Search(string searchText);
    }
}
