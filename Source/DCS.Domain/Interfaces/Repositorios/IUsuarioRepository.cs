using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DCS.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario ObterPorEmail(string email);
    }
}
