using Library.Tracker.Handler;
using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Context;
using Library.Tracker.Context.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Library.Tracker.Shared.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Library.Tracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region JWT
            // JWT Configuration
            var appSettingsSection = Configuration.GetSection("App");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            // Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region USERROLES
            // Authorisation
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });
            #endregion

            #region EFCORE
            // EfCore
            services.AddDbContextPool<SqlContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppDB"));
            });
            #endregion

            #region SERVICES
            // Services & Context
            services.AddScoped<IGlobals, Globals>();
            services.AddHttpContextAccessor();
            services.AddScoped<ISecurityHandler, SecurityHandler>();
            services.AddScoped<ISecurityContext, SecurityContext>();
            #endregion

            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                        builder => builder.WithOrigins(appSettings.PortUrlCors.Split(","))
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
