using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Application.App.Command.UsuarioCommands
{
    public class UsuarioCommand
    {
        public UsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        #region "Propriedades"

        public Guid IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }
        
        public string Email { get; set; }        

        #endregion  
    }
}
