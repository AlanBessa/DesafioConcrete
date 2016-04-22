using DCS.Application.App.Command.TelefoneCommands;
using DCS.Application.App.Command.UsuarioCommands;
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
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new UsuarioCommand(
                nome: (string)body.nome,
                email: (string)body.email,
                senha: (string)body.senha,
                telefones: body.telefones.ToObject<List<TelefoneCommand>>()
            );

            var usuario = _usuarioApp.Registrar(command);

            return CreateResponse(HttpStatusCode.Created, usuario);
        }
    }
}
