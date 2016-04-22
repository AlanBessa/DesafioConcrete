using DCS.Domain.Entidades;
using DCS.Domain.SharedKernel.Resources;
using DCS.Domain.SharedKernel.ValueObjects;

namespace DCS.Domain.Scopes
{
    public static class UsuarioScopes
    {
        public static bool DefinirSenhaUsuarioScopeEhValido(this Usuario usuario, string senha)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(senha, ErrorMessage.SenhaObrigatoria),
                AssertionConcern.AssertLength(senha, Usuario.SenhaMinLength, Usuario.SenhaMaxLength, ErrorMessage.SenhaTamanhoInvalido)
            );
        }

        public static bool AutenticarUsuarioScopeEhValido(this Usuario usuario, string email, string senhaCriptografada)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(email, ErrorMessage.UsuarioObrigatorio),
                AssertionConcern.AssertNotNullOrEmpty(senhaCriptografada, ErrorMessage.SenhaObrigatoria),
                AssertionConcern.AssertAreEquals(usuario.Email.Endereco, email, ErrorMessage.UsuarioSenhaInvalido),
                AssertionConcern.AssertAreEquals(usuario.Senha, senhaCriptografada, ErrorMessage.UsuarioSenhaInvalido)
            );
        }

        public static bool DefinirEmailUsuarioScopeEhValido(this Usuario usuario, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, ErrorMessage.EmailTamanhoIncorreto),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, ErrorMessage.EmailObrigatorio),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco), ErrorMessage.EmailInvalido)
            );
        }
    }
}
