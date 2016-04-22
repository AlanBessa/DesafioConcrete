using DCS.Application.App.Command.UsuarioCommands;
using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Application.App.Adapters
{
    public class UsuarioAdapter
    {
        public static Usuario ToDomainModel(UsuarioCommand usuarioCommand)
        {
            var usuario = new Usuario(
                usuarioCommand.Nome,
                usuarioCommand.Email,
                usuarioCommand.Senha,
                usuarioCommand.IdUsuario);

            return usuario;
        }
    }
}
