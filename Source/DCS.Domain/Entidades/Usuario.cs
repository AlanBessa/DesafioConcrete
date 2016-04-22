using DCS.Domain.Scopes;
using DCS.Domain.SharedKernel.Helpers;
using DCS.Domain.SharedKernel.ValueObjects;
using DomainValidation.Validation;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DCS.Domain.Entidades
{
    public class Usuario
    {
        #region "Constantes"

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        #endregion

        #region "Atributos"

        private IList<Telefone> _telefones;

        #endregion

        protected Usuario()
        {
        }

        public Usuario(string nome, string email, string senha, IList<Telefone> telefones, Guid? idUsuario)
        {
            DefinirNome(nome);
            DefinirEmail(email);
            IdUsuario = idUsuario == null ? Guid.NewGuid() : idUsuario.Value;
            ListaDeTelefones = new List<Telefone>();
            DataDeCriacao = DateTime.Now;
            DataAtualizacao = null;
            DataDoUltimoLogin = null;
            DefinirSenha(senha);
            DefinirTelefones(telefones);
        }

        #region "Propriedades"

        public Guid IdUsuario { get; private set; }

        public string Nome { get; private set; }

        public string Senha { get; private set; }

        public Email Email { get; private set; }

        public DateTime DataDeCriacao { get; private set; }

        public DateTime? DataAtualizacao { get; private set; }

        public DateTime? DataDoUltimoLogin { get; private set; }
        
        public ICollection<Telefone> ListaDeTelefones
        {
            get { return _telefones; }
            private set { _telefones = new List<Telefone>(value); }
        }
                
        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        private void DefinirNome(string nome)
        {
            if (this.DefinirNomeUsuarioScopeEhValido(nome))
                Nome = nome;
        }

        private void DefinirEmail(string email)
        {
            var objEmail = new Email(email);

            if (this.DefinirEmailUsuarioScopeEhValido(objEmail))
                Email = objEmail;
        }

        private void DefinirSenha(string senha)
        {
            if (this.DefinirSenhaUsuarioScopeEhValido(senha))
                Senha = StringHelper.Criptografar(senha);
        }

        public void DefinirTelefones(IList<Telefone> telefones)
        {
            if (telefones == null || !telefones.Any()) return;

            _telefones = new List<Telefone>();
            telefones.ToList().ForEach(x => AdicionarTelefone(x));
        }

        public bool Autenticar(string email, string senhaCriptografada)
        {
            if (this.AutenticarUsuarioScopeEhValido(email, senhaCriptografada))
                return true;

            return false;
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            _telefones.Add(telefone);
        }

        #endregion
    }
}
