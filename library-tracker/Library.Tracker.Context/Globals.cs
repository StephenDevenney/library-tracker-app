﻿using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Tracker.Context
{
    public class Globals: IGlobals
    {
        private readonly IHttpContextAccessor httpAccess;
        private readonly SqlContext sqlContext;
        public Globals(IHttpContextAccessor _httpAccess,
                        SqlContext sqlRepo)
        {
            this.httpAccess = _httpAccess;
            this.sqlContext = sqlRepo;
        }

        public async Task<UserEntity> GetCurrentUser()
        {
            return await sqlContext.User.Where(u => u.UserName == this.httpAccess.HttpContext.User.Identity.Name)
                .Join(sqlContext.UserRole,
                    u => u.UserId,
                    ur => ur.UserRoleId,
                    (u, ur) => new UserEntity
                    {
                        UserId = u.UserId,
                        UserName = u.UserName,
                        UserRoleId = ur.UserRoleId,
                        UserRoleName = ur.RoleName
                    }
                ).FirstOrDefaultAsync();
        }
    }
}