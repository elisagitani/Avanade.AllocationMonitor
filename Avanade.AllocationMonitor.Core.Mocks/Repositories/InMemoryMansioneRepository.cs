using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Mansione" with in-memory engine
    /// </summary>
    public class InMemoryMansioneRepository: InMemoryRepositoryBase<Mansione>, IMansioneRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryMansioneRepository() 
            : base(storage => storage.Mansioni) { }
    }
}
