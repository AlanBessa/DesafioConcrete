using DCS.Application.App.Command.TelefoneCommands;
using DCS.Application.App.Command.UsuarioCommands;
using DCS.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DCS.Application.App.Adapters
{
    public class UsuarioAdapter
    {
        public static Usuario ToDomainModel(UsuarioCommand usuarioCommand)
        {
            var telefones = new List<Telefone>();

            if (usuarioCommand.Telefones != null && usuarioCommand.Telefones.Any())
            {
                usuarioCommand.Telefones.ToList().ForEach(m => telefones.Add(TelefoneAdapter.ToDomainModel(m)));
            }

            var usuario = new Usuario(
                usuarioCommand.Nome,
                usuarioCommand.Email,
                usuarioCommand.Senha,
                telefones,
                usuarioCommand.IdUsuario);

            usuario.Token = usuarioCommand.Token;

            return usuario;
        }

        public static UsuarioCommand ToModelDomain(Usuario usuario)
        {
            if (usuario == null) return null;

            var telefones = new List<TelefoneCommand>();

            if (usuario.ListaDeTelefones != null && usuario.ListaDeTelefones.Any())
            {
                usuario.ListaDeTelefones.ToList().ForEach(m => telefones.Add(TelefoneAdapter.ToModelDomain(m)));
            }    

            var usuarioCommand = new UsuarioCommand(
                usuario.Nome,
                usuario.Email.Endereco,
                usuario.Senha,
                telefones);

            usuarioCommand.IdUsuario = usuario.IdUsuario;
            usuarioCommand.Token = usuario.Token;

            return usuarioCommand;
        }
                
    }
}
