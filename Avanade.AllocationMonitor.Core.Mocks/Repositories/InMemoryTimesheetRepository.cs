using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    /// <summary>
    /// Repository of "Timesheet" with in-memory engine
    /// </summary>
    public class InMemoryTimesheetRepository: InMemoryRepositoryBase<Timesheet>, ITimesheetRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryTimesheetRepository() 
            : base(storage => storage.Timesheets) { }
    }
}
