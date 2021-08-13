using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.Security;
using Library.Tracker.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.API.Controllers
{
    [Route("Security")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityHandler securityHandler;
        public SecurityController(ISecurityHandler securityHandler)
        {
            this.securityHandler = securityHandler;
        }

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("nav-menu")]
        public async Task<List<NavMenuViewModel>> GetNavMenu() => await securityHandler.GetNavMenu();
        #endregion
    }
}
