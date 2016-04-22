using DomainValidation.Validation;
using System;
using DCS.Domain.Scopes;
using DCS.Domain.SharedKernel.Helpers;

namespace DCS.Domain.Entidades
{
    public class Telefone
    {
        #region "Constantes"

        public const int DDDLength = 2;
        public const int NumeroMinLength = 8;
        public const int NumeroMaxLength = 9;

        #endregion

        protected Telefone()
        {
        }

        public Telefone(string ddd, string numero, Guid? idTelefone)
        {
            IdTelefone = idTelefone == null ? Guid.NewGuid() : idTelefone.Value;
            DefinirDDD(ddd);
            DefinirNumero(numero);
        }

        #region "Propriedades"

        public Guid IdTelefone { get; private set; }

        public string DDD { get; private set; }

        public string Numero { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        private void DefinirDDD(string ddd)
        {
            ddd = StringHelper.RemoverCaracterEspecial(ddd);

            if (this.DefinirDDDTelefoneScopeEhValido(ddd))
                DDD = ddd;
        }

        private void DefinirNumero(string numero)
        {
            numero = StringHelper.RemoverCaracterEspecial(numero);

            if (this.DefinirNumeroTelefoneScopeEhValido(numero))
                Numero = numero;
        }        
    }
}
