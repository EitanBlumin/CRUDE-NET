using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudePortal.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudePortal
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
            Microsoft.AspNetCore.Authentication.AuthenticationBuilder authBuilder;
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            authBuilder = services.AddAuthentication();

            if (!String.IsNullOrEmpty(Configuration["Authentication:Microsoft:ClientSecret"]))
                authBuilder.AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                    microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                });

            if (!String.IsNullOrEmpty(Configuration["Authentication:Google:ClientSecret"]))
                authBuilder.AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                });

            if (!String.IsNullOrEmpty(Configuration["Authentication:Facebook:ClientSecret"]))
                authBuilder.AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:ClientId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:ClientSecret"];
                });

            if (!String.IsNullOrEmpty(Configuration["Authentication:Twitter:ClientSecret"]))
                authBuilder.AddTwitter(twitterOptions =>
                {
                    twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ClientId"];
                    twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ClientSecret"];
                });

            if (!String.IsNullOrEmpty(Configuration["Authentication:LinkedIn:ClientSecret"]))
                authBuilder.AddOAuth("LinkedIn", "LinkedIn", oauthOptions =>
                {
                    oauthOptions.ClientId = Configuration["Authentication:LinkedIn:ClientId"];
                    oauthOptions.ClientSecret = Configuration["Authentication:LinkedIn:ClientSecret"];
                    oauthOptions.CallbackPath = new PathString("/signin-linkedin");
                    oauthOptions.AuthorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
                    oauthOptions.TokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
                    oauthOptions.UserInformationEndpoint = "https://api.linkedin.com/v1/people/~:(id,formatted-name,email-address,picture-url)";
                    //oauthOptions.UserInformationEndpoint = "https://api.linkedin.com/v2/me/?projection=(id,firstName,lastName,profilePicture(displayImage~:playableStreams))";
                    //oauthOptions.Scope = new { "r_basicprofile", "r_emailaddress" };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
