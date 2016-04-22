using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Repositorios;
using DCS.Domain.Specifications;
using DomainValidation.Validation;

namespace DCS.Domain.Validations
{
    public class UsuarioAptoParaCadastroValidation : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidation(IUsuarioRepository usuarioRepository)
        {
            var emailDuplicado = new UsuarioDevePossuirEmailUnicoSpecification(usuarioRepository);
            
            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, "E-mail já cadastrado!"));
        }
    }
}
