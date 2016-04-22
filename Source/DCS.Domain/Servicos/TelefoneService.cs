using DCS.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Repositorios;

namespace DCS.Domain.Servicos
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;
              
        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public IEnumerable<Telefone> ObterTelefonesPorUsuario(Guid idUsuario)
        {
            return _telefoneRepository.ObterTelefonesPorUsuario(idUsuario);
        }
    }
}
