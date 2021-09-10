using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Dipendente" with in-memory engine
    /// </summary>
    public class InMemoryDipendenteRepository: InMemoryRepositoryBase<Dipendente>, IDipendenteRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryDipendenteRepository() 
            : base(storage => storage.Dipendenti) { }
    }
}
