using DCS.Application.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DCS.Presetantion.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public AccountController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpGet]
        [Route("api/login/usuarios/{email}")]
        public Task<HttpResponseMessage> Get(string email)
        {
            var usuario = _usuarioApp.ObterUsuarioIdPorEmail(email);

            return CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpGet]
        [Route("api/logout/usuarios/{id:guid}")]
        public Task<HttpResponseMessage> Get(Guid id)
        {
            _usuarioApp.AtualizarDataDoUltimoLoginPorId(id);

            return CreateResponse(HttpStatusCode.OK, null);
        }
    }
}
