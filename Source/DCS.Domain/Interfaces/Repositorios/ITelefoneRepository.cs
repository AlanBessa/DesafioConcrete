﻿using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.Interfaces.Repositorios
{
    public interface ITelefoneRepository : IBaseRepository<Telefone>
    {
        IEnumerable<Telefone> ObterTelefonesPorUsuario(Guid idUsuario);
    }
}
