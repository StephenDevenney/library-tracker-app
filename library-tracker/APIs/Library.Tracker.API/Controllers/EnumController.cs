using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.Security;
using Library.Tracker.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.API.Controllers
{
    [Route("Enum")]
    public class EnumController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IEnumHandler enumHandler;
        public EnumController(IEnumHandler enumHandler)
        {
            this.enumHandler = enumHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("themes")]
        public async Task<List<ThemeViewModel>> GetThemes() => await enumHandler.GetThemes();

        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("appIdleSecs")]
        public async Task<List<AppIdleSecsViewModel>> GetAppIdleSecs() => await enumHandler.GetAppIdleSecs();
        #endregion
    }
}
