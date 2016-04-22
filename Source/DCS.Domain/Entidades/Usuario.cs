using DCS.Domain.Scopes;
using DCS.Domain.SharedKernel.Helpers;
using DCS.Domain.SharedKernel.ValueObjects;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace DCS.Domain.Entidades
{
    public class Usuario
    {
        #region "Constantes"

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        #endregion

        protected Usuario()
        {
        }

        public Usuario(string nome, string email, string senha, Guid? IdUsuario = null)
        {
            Nome = nome;
            DefinirEmail(email);
            IdUsuario = IdUsuario == null ? Guid.NewGuid() : IdUsuario;
            ListaDeTelefones = new List<Telefone>();
            DataDeCriacao = DateTime.Now;
            DataAtualizacao = null;
            DataDoUltimoLogin = null;
            DefinirSenha(senha);
        }

        #region "Propriedades"

        public Guid IdUsuario { get; private set; }

        public string Nome { get; private set; }

        public string Senha { get; private set; }

        public Email Email { get; private set; }

        public DateTime DataDeCriacao { get; private set; }

        public DateTime? DataAtualizacao { get; private set; }

        public DateTime? DataDoUltimoLogin { get; private set; }
        
        public ICollection<Telefone> ListaDeTelefones { get; set; }
                
        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirEmail(string email)
        {
            var objEmail = new Email(email);

            if (this.DefinirEmailUsuarioScopeEhValido(objEmail))
                Email = objEmail;
        }

        public void DefinirSenha(string senha)
        {
            if (this.DefinirSenhaUsuarioScopeEhValido(senha))
                Senha = StringHelper.Criptografar(senha);
        }

        public void Autenticar(string email, string senha)
        {
            if (this.AutenticarUsuarioScopeEhValido(email, senha))
                return;
        }

        #endregion
    }
}
