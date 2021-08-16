using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.ViewModels;

namespace Library.Tracker.Handler
{
    public class SecurityHandler : ISecurityHandler
    {
        #region CONSTRUCTOR
        private readonly ISecurityContext securityRepo;
        public SecurityHandler(ISecurityContext securityRepo)
        {
            this.securityRepo = securityRepo;
        }
        #endregion

        #region GET
        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityRepo.GetNavMenu();

        public async Task<UserSettingsViewModel> GetUserSettings() => await securityRepo.GetUserSettings();
        #endregion

        #region PUT
        public async Task<UserSettingsViewModel> UpdateSettings(UserSettingsViewModel settings) => await securityRepo.UpdateSettings(settings);
        #endregion

        #region POST

        #endregion

    }
}
