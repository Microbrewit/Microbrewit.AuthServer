using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer4.Core.Services;
using IdentityServer4.Core.Validation;
using Microbrewit.AuthServer.Configuration;
using Microbrewit.AuthServer.Service;
using Microbrewit.AuthServer.Settings;
using Microbrewit.AuthServer.UI;
using Microbrewit.AuthServer.UI.Login;
using Microbrewit.AuthSever.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//test 
namespace Microbrewit.AuthServer
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        public Startup(IHostingEnvironment environment)
        {
            _environment = environment;
            var builder = new ConfigurationBuilder()
               .SetBasePath(environment.ContentRootPath)
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
           services.Configure<ServerSettings>(options => Configuration.GetSection("ServerSettings").Bind(options));
            var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsrv4test.pfx"), "idsrv3test");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var builder = services.AddIdentityServer(options =>
            {
                options.SigningCertificate = cert;
            });

            builder.Services.AddTransient<IUserRepository,UserRepository>();
            builder.Services.AddTransient<IProfileService,UserProfileService>();
            builder.Services.AddTransient<IResourceOwnerPasswordValidator,UserResourceOwnerPasswordValidator>();
            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryScopes(Scopes.Get());
            //builder.AddInMemoryUsers(Users.Get());
            //builder.AddCustomGrantValidator<CustomGrantValidator>();

                
            // for the UI
            services
                .AddMvc()
                .AddRazorOptions(razor =>
                {
                    razor.ViewLocationExpanders.Add(new CustomViewLocationExpander());
                });
            services.AddTransient<LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Trace);
            loggerFactory.AddDebug(LogLevel.Trace);

            app.UseDeveloperExceptionPage();
                                
            app.UseMiddleware<Middlevare.BaseUrlMiddleware>();
            app.UseIdentityServer();
            
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
