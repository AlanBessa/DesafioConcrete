using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DCS.Domain.Interfaces.Servicos
{
    public interface IUsuarioService
    {
        Usuario Adicionar(Usuario usuario);

        Usuario ObterPorId(Guid id);

        IEnumerable<Usuario> ObterTodos();        
    }
}
