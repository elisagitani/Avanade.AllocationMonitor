using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Repositories.Common;

namespace Avanade.AllocationMonitor.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string userName);
    }
}