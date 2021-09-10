using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Commessa" with in-memory engine
    /// </summary>
    public class InMemoryCommessaRepository: InMemoryRepositoryBase<Commessa>, ICommessaRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryCommessaRepository() 
            : base(storage => storage.Commesse) { }
    }
}
