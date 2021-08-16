using Library.Tracker.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.Handler.Interfaces
{
    public interface IEnumHandler
    {
        #region GET
        public Task<List<ThemeViewModel>> GetThemes();
        public Task<List<AppIdleSecsViewModel>> GetAppIdleSecs();
        #endregion
    }
}
