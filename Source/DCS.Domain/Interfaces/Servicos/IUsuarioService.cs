using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DCS.Domain.Interfaces.Servicos
{
    public interface IUsuarioService
    {
        Usuario Adicionar(Usuario usuario);

        Usuario Autenticar(string email, string senha);

        Usuario ObterPorId(Guid id);

        IEnumerable<Usuario> ObterTodos();        
    }
}
