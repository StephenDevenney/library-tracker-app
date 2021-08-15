using Library.Tracker.Shared.Entities;
using System.Threading.Tasks;

namespace Library.Tracker.Context.Interfaces
{
    public interface IGlobals
    {
        public Task<UserEntity> GetCurrentUser();
        public Task<int> GetUserId();
    }
}
