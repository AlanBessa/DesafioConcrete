using DCS.Domain.Entidades;
using DCS.Domain.SharedKernel.Resources;
using DCS.Domain.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.Scopes
{
    public static class TelefoneScopes
    {
        public static bool DefinirDDDTelefoneScopeEhValido(this Telefone telefone, string ddd)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertMatches("^[0-9]*$", ddd, ErrorMessage.SomenteNumero),
                AssertionConcern.AssertNotNullOrEmpty(ddd, ErrorMessage.DDDObrigatorio),
                AssertionConcern.AssertFixedLength(ddd, Telefone.DDDLength, ErrorMessage.DDDTamanhoInvalido)
            );
        }

        public static bool DefinirNumeroTelefoneScopeEhValido(this Telefone telefone, string numero)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertMatches("^[0-9]*$", numero, ErrorMessage.SomenteNumero),
                AssertionConcern.AssertNotNullOrEmpty(numero, ErrorMessage.NumeroObrigatorio),
                AssertionConcern.AssertLength(numero, Telefone.NumeroMinLength, Telefone.NumeroMaxLength, ErrorMessage.NumeroTamanhoInvalido)
            );
        }
    }
}
