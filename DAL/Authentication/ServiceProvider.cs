using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAL.Authentication
{
    public class ServiceProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserRepository _repo = new UserRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password are incorrect");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserName", user.UserName));

                var permissions = _repo.GetUserPermissionsByUsername(user.UserName);
                foreach (var permission in permissions)
                {
                    identity.AddClaim(new Claim("permission", permission)); // Add permissions as claims
                }

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "userName", user.UserName }
                    // No need to add permissions here since they will be added in the TokenEndpoint
                });

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            // Add additional response parameters here
            var permissions = context.Identity.FindAll("permission");
            if (permissions != null)
            {
                context.AdditionalResponseParameters.Add("permissions", string.Join(",", permissions.Select(p => p.Value)));
            }

            return base.TokenEndpoint(context);
        }
    }
}
