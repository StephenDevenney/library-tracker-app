using Library.Tracker.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.Handler.Interfaces
{
    public interface ISecurityHandler
    {
        #region GET
        public Task<List<NavMenuViewModel>> GetNavMenu();
        public Task<UserSettingsViewModel> GetUserSettings();
        #endregion

        #region PUT
        public Task<UserSettingsViewModel> UpdateSettings(UserSettingsViewModel settings);
        #endregion

        #region POST

        #endregion
    }
}
