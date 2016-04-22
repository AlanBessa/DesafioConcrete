using System;
using System.Collections.Generic;
using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Repositorios;
using DCS.Infra.Data.Context;

namespace DCS.Infra.Data.Repositorios
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DCSContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Telefone> ObterTelefonesPorUsuario(Guid idUsuario)
        {
            return Buscar(m => m.UsuarioId == idUsuario);
        }
    }
}
