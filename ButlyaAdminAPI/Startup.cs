using ButlyaAdminAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SQLitePCL;

namespace ButlyaAdminAPI
{
    public class Startup
    {
        private WebApplicationBuilder _appBuilder;

        public Startup(WebApplicationBuilder appBuilder)
        {
            _appBuilder = appBuilder;
        }

        public WebApplication ConfigureServices()
        {
            #region Configure Services
                _appBuilder.Services.AddControllers();
                _appBuilder.Services.AddEndpointsApiExplorer();
                _appBuilder.Services.AddSwaggerGen();
                _appBuilder.Services.AddMvc();
            #endregion

            #region Database
                _appBuilder.Services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlite(_appBuilder.Configuration.GetConnectionString("IdentityDefaultConnection")));

                _appBuilder.Services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlite(_appBuilder.Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Authorization and Authentication
                _appBuilder.Services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<IdentityContext>();

                _appBuilder.Services.AddAuthorization(options =>
                {
                    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                });
            #endregion
            
            var app = _appBuilder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
