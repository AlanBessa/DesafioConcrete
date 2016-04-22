using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Repositorios;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.Specifications
{
    public class UsuarioDevePossuirEmailUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDevePossuirEmailUnicoSpecification(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Usuario aluno)
        {
            return _usuarioRepository.ObterPorEmail(aluno.Email.Endereco) == null;
        }
    }
}
