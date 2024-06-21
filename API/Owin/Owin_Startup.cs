using DAL.Authentication;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System;

[assembly: OwinStartup(typeof(API.Owin.Owin_Startup))]

namespace API.Owin
{
    public class Owin_Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/loginToken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2),
                Provider = new ServiceProvider()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
