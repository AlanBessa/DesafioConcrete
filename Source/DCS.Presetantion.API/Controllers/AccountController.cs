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

        [HttpPost]
        [Route("api/login/usuarios")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var usuario = _usuarioApp.ArmazenarTokenDoUsuarioPorEmail((string)body.email, (string)body.token);

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
