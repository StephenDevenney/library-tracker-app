using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.Security;
using Library.Tracker.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.API.Controllers
{
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHandler authHandler;
        public AuthController(IAuthHandler authHandler)
        {
            this.authHandler = authHandler;
        }

        #region GET
        [Authorize(Roles = SecureRole.Admin)]
        [HttpGet("all-users")]
        public async Task<List<UserViewModel>> GetAllUsers() => await authHandler.GetAllUsers();

        [AllowAnonymous]
        [HttpGet("authenticate/{userName}")]
        public async Task<UserViewModel> Authenticate(string userName) => await authHandler.Authenticate(userName);
        #endregion
    }
}
