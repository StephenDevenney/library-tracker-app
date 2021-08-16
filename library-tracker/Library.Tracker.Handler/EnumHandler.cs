using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.ViewModels;

namespace Library.Tracker.Handler
{
    public class EnumHandler : IEnumHandler
    {
        #region CONSTRUCTOR
        private readonly IEnumContext enumRepo;
        public EnumHandler(IEnumContext enumRepo)
        {
            this.enumRepo = enumRepo;
        }
        #endregion

        #region GET
        public async Task<List<ThemeViewModel>> GetThemes() => await enumRepo.GetThemes();
        public async Task<List<AppIdleSecsViewModel>> GetAppIdleSecs() => await enumRepo.GetAppIdleSecs();
        #endregion

    }
}
