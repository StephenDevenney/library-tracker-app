using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Tracker.Context
{
    public class EnumContext: IEnumContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        public EnumContext(SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
        }
        #endregion

        #region GET
        public async Task<List<ThemeViewModel>> GetThemes()
        {
            return await sqlContext.Theme.Select(res => new ThemeViewModel { ThemeId = res.ThemeId, ThemeName = res.ThemeName, ThemeClassName = res.ClassName }).ToListAsync();
        }

        public async Task<List<AppIdleSecsViewModel>> GetAppIdleSecs()
        {
            return await sqlContext.AppIdleSecs.Select(res => new AppIdleSecsViewModel { AppIdleSecsId = res.AppIdleSecsId, IdleTime = res.IdleTime, Description = res.Description }).ToListAsync();
        }
        #endregion
    }
}
