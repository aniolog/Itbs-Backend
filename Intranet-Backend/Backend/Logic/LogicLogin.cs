using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Backend.Logic
{
    public class LogicLogin : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                Model.User UserAuth = (new LogicUser()).GetUser(context.UserName);
                if (UserAuth == null) {
                    throw new IntranetException.ItbsException(HttpStatusCode.NotFound, IntranetException.ExceptionResource.UsuarioInexistente);
                }
                /*
                var Logic = new Logic.LdapLogic(null);
                if (!(Logic.IsAuthenticated(null, UserAuth.Usename, context.Password))) {
                    return;
                }*/

                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, UserAuth.Rol.Nombre));
                context.Validated(identity);
            }
            catch (IntranetException.ItbsException e)
            {
                return;
            }
            catch (Exception e) {
                return; 
            }
        }
    }
}