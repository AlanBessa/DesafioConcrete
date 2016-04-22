using DCS.Application.App.Command.TelefoneCommands;
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
            var telefones = new List<Telefone>();
            usuarioCommand.ListaDeTelefones.ToList().ForEach(m => telefones.Add(TelefoneAdapter.ToDomainModel(m)));

            var usuario = new Usuario(
                usuarioCommand.Nome,
                usuarioCommand.Email,
                usuarioCommand.Senha,
                telefones,
                usuarioCommand.IdUsuario);

            return usuario;
        }

        public static UsuarioCommand ToModelDomain(Usuario usuario)
        {
            var telefones = new List<TelefoneCommand>();
            usuario.ListaDeTelefones.ToList().ForEach(m => telefones.Add(TelefoneAdapter.ToModelDomain(m)));

            var usuarioCommand = new UsuarioCommand(
                usuario.Nome,
                usuario.Email.Endereco,
                usuario.Senha,
                telefones);

            usuarioCommand.IdUsuario = usuario.IdUsuario;

            return usuarioCommand;
        }
                
    }
}
