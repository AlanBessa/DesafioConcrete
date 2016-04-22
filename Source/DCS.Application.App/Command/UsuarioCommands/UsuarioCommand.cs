using DCS.Application.App.Command.TelefoneCommands;
using System;
using System.Collections.Generic;

namespace DCS.Application.App.Command.UsuarioCommands
{
    public class UsuarioCommand
    {
        public UsuarioCommand(string nome, string email, string senha, IEnumerable<TelefoneCommand> telefones)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
        }

        #region "Propriedades"

        public Guid? IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }
        
        public string Email { get; set; }

        public IEnumerable<TelefoneCommand> Telefones { get; set; }

        #endregion
    }
}
