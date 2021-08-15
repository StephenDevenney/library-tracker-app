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
        public Task<List<ThemeViewModel>> GetThemes();
        #endregion

        #region PUT
        public Task<ThemeViewModel> UpdateSelectedTheme(ThemeViewModel theme);
        #endregion

        #region POST

        #endregion
    }
}
