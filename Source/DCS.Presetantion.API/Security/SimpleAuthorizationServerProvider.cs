using DCS.Application.App.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DCS.Presetantion.API.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUsuarioApp _usuarioApp;

        public SimpleAuthorizationServerProvider(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = _usuarioApp.Autenticar(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            GenericPrincipal principal = new GenericPrincipal(identity, new string[] { "usuario" });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }
    }
}
