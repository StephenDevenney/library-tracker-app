using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Tracker.Context
{
    public class SecurityContext: ISecurityContext
    {
        private readonly SqlContext sqlContext;
        public SecurityContext(SqlContext sqlRepo)
        {
            this.sqlContext = sqlRepo;
        }

        public async Task<List<NavMenuViewModel>> GetNavMenu()
        {
            return await sqlContext.NavMenu.Select(dbResult => new NavMenuViewModel
            {
                NavMenuName = dbResult.NavMenuName,
                NavMenuTitle = dbResult.NavMenuTitle,
                NavMenuRoute = dbResult.NavMenuRoute
            }).ToListAsync();
        }
    }
}
