using Avanade.AllocationMonitor.Core.Entities;

namespace Avanade.AllocationMonitor.Core.Structures
{
    public class WorkerHoursByMonth
    {
        public Dipendente Dipendente { get; set; }

        public int TotalHours { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }
    }
}
