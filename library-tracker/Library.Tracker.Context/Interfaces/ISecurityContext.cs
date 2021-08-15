using Library.Tracker.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.Context.Interfaces
{
    public interface ISecurityContext
    {
        #region GET
        public Task<List<NavMenuViewModel>> GetNavMenu();
        public Task<UserSettingsViewModel> GetUserSettings();
        public Task<List<ThemeViewModel>> GetThemes();
        #endregion

        #region PUT
        public Task<UserSettingsViewModel> UpdateSettings(UserSettingsViewModel settings);
        #endregion

        #region POST

        #endregion
    }
}
