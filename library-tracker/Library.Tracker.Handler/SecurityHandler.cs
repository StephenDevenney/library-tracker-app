using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Tracker.Context;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.ViewModels;

namespace Library.Tracker.Handler
{
    public class SecurityHandler : ISecurityHandler
    {
        private readonly ISecurityContext securityRepo;
        public SecurityHandler(ISecurityContext securityRepo)
        {
            this.securityRepo = securityRepo;
        }

        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityRepo.GetNavMenu();

        public async Task<UserSettingsViewModel> GetUserSettings() => await securityRepo.GetUserSettings();

    }
}
