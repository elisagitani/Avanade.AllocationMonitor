using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Assegnazione" with in-memory engine
    /// </summary>
    public class InMemoryAssegnazioneRepository: InMemoryRepositoryBase<Assegnazione>, IAssegnazioneRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryAssegnazioneRepository() 
            : base(storage => storage.Assegnazioni) { }
    }
}
