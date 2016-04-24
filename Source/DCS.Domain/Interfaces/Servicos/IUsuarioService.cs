using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DCS.Domain.Interfaces.Servicos
{
    public interface IUsuarioService
    {
        Usuario Adicionar(Usuario usuario);

        Usuario Atualizar(Usuario usuario);

        Usuario Autenticar(string email, string senha);

        Usuario ObterPorId(Guid id);

        Usuario ObterPorEmail(string email);

        IEnumerable<Usuario> ObterTodos();        
    }
}
