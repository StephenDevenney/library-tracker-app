using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Tracker.Context
{
    public class SecurityContext: ISecurityContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        private readonly IGlobals globals;
        public SecurityContext(IGlobals _globals,
                                SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<NavMenuViewModel>> GetNavMenu()
        {
            UserEntity user = await this.globals.GetCurrentUser();
            return await sqlContext.NavMenu.Join(sqlContext.NavMenuRole.Where(nmr => nmr.UserRoleId == user.UserRoleId),
                nm => nm.NavMenuId,
                nmr => nmr.NavMenuId,
                (nm, nmr) => new NavMenuViewModel
                {
                    NavMenuName = nm.NavMenuName,
                    NavMenuTitle = nm.NavMenuTitle,
                    NavMenuRoute = nm.NavMenuRoute
                }).ToListAsync();
        }

        public async Task<UserSettingsViewModel> GetUserSettings()
        {
            UserEntity user = await this.globals.GetCurrentUser();
            return await sqlContext.AppSettings.Where(u => u.UserId == user.UserId)
                .Join(sqlContext.Theme,
                    appSettings => appSettings.AppSettingsId,
                    theme => theme.ThemeId,
                    (appSettings, theme) => new { appSettings, theme })
                .Join(sqlContext.AppIdleSecs,
                        r2 => r2.appSettings.AppSettingsId,
                        appIdleSecs => appIdleSecs.AppIdleSecsId,
                        (r2, appIdleSecs) => new UserSettingsViewModel
                        {
                            User = new UserViewModel { UserName = user.UserName, UserRole = new UserRoleViewModel { UserRoleId = user.UserRoleId, UserRoleName = user.UserRoleName }, Token = "", IsAuthenticated = user.IsAuthenticated },
                            Theme = new ThemeViewModel { ThemeId = r2.theme.ThemeId, ThemeName = r2.theme.ThemeName, ThemeClassName = r2.theme.ClassName },
                            AppIdleSecs = new AppIdleSecsViewModel { IdleTime = appIdleSecs.IdleTime, Description = appIdleSecs.Description },
                            NavMinimized = r2.appSettings.NavMinimised
                        }).FirstOrDefaultAsync();
        }

        public async Task<List<ThemeViewModel>> GetThemes()
        {
            return await sqlContext.Theme.Select(res => new ThemeViewModel { ThemeId = res.ThemeId, ThemeName = res.ThemeName, ThemeClassName = res.ClassName }).ToListAsync();
        }
        #endregion

        #region PUT
        public async Task<ThemeViewModel> UpdateSelectedTheme(ThemeViewModel theme)
        {
            UserEntity user = await this.globals.GetCurrentUser();
            AppSettingsEntity asE = await this.sqlContext.AppSettings.Where(u => u.UserId == user.UserId).FirstOrDefaultAsync();
            asE.ThemeId = theme.ThemeId;
            this.sqlContext.Attach(asE);
            await sqlContext.SaveChangesAsync();
            return null;
        }
        #endregion

        #region POST

        #endregion
    }
}
