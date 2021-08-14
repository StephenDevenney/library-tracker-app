using Library.Tracker.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tracker.Handler.Interfaces
{
    public interface ISecurityHandler
    {
        public Task<List<NavMenuViewModel>> GetNavMenu();
        public Task<UserSettingsViewModel> GetUserSettings();
    }
}
