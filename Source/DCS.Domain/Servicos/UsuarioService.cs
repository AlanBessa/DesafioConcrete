using DCS.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Repositorios;
using DCS.Domain.Validations;
using DomainValidation.Validation;
using DCS.Domain.SharedKernel.Events;

namespace DCS.Domain.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!PossuiConformidade(new UsuarioAptoParaCadastroValidation(_usuarioRepository).Validate(usuario)))
                _usuarioRepository.Adicionar(usuario);

            return usuario;
        }
                
        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        private static bool PossuiConformidade(ValidationResult validationResult)
        {
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return false;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return true;
        }        
    }
}
