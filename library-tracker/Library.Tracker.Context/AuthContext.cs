using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.Security;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Library.Tracker.Context
{
    public class AuthContext: IAuthContext
    {
        private readonly SqlContext sqlContext;
        private readonly AppSettings config;
        public AuthContext(SqlContext sqlRepo, IOptions<AppSettings> configSettings)
        {
            this.sqlContext = sqlRepo;
            this.config = configSettings.Value;
        }

        public async Task<UserViewModel> Authenticate(string username)
        {
            /* 
             * App doesn't require password protection but validation would happen here in a production application.
            */

            UserViewModel user = await sqlContext.User.Where(u => u.UserName == username)
                .Join(sqlContext.UserRole,
                    u => u.UserId,
                    ur => ur.UserRoleId,
                    (u, ur) => new UserViewModel
                    {
                        UserName = u.UserName,
                        UserRole = new UserRoleViewModel { UserRoleId = ur.UserRoleId, UserRoleName = ur.RoleName }
                    }
                ).FirstOrDefaultAsync();

            // return null if user not found
            if (user == null)
                return null;

            // Generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole.UserRoleName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.IsAuthenticated = true;

            return user;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            return await sqlContext.User.Join(
                sqlContext.UserRole,
                u => u.UserId,
                ur => ur.UserRoleId,
                (u, ur) => new UserViewModel
                {
                    UserName = u.UserName,
                    UserRole = new UserRoleViewModel { UserRoleId = ur.UserRoleId, UserRoleName = ur.RoleName }
                }
            ).ToListAsync();
        }

        public async Task<UserViewModel> GetUserById(int userId)
        {
            return await sqlContext.User.Where(u => u.UserId == userId)
                .Join(sqlContext.UserRole,
                    u => u.UserId,
                    ur => ur.UserRoleId,
                    (u, ur) => new UserViewModel
                    {
                        UserName = u.UserName,
                        UserRole = new UserRoleViewModel { UserRoleId = ur.UserRoleId, UserRoleName = ur.RoleName }
                    }
                ).FirstOrDefaultAsync();
        }
    }
}
