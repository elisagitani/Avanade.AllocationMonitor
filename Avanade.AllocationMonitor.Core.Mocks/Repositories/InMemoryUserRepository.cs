using Avanade.AllocationMonitor.Core.Entities;
using Avanade.AllocationMonitor.Core.Mocks.Repositories.Common;
using Avanade.AllocationMonitor.Core.Repositories;
using Avanade.AllocationMonitor.Core.Mocks.Storages;
using System.Linq;

namespace Avanade.AllocationMonitor.Core.Mocks.Repositories
{
    public class InMemoryUserRepository : InMemoryRepositoryBase<User>, IUserRepository
    {
        public InMemoryUserRepository()
            : base(storage => storage.Users) { }

        public User GetByUserName(string userName)
        {
            //Usiamo LINQ
            return InMemoryStorage.Default.Users
                .SingleOrDefault(u => u.UserName == userName);
        }
    }
}