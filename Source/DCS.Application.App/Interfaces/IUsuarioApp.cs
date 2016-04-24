using DCS.Application.App.Command.UsuarioCommands;
using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DCS.Application.App.Interfaces
{
    public interface IUsuarioApp
    {
        UsuarioCommand Registrar(UsuarioCommand usuario);

        UsuarioCommand Autenticar(string email, string senha);

        void AtualizarDataDoUltimoLoginPorId(Guid id);

        UsuarioCommand ObterPorId(Guid id);

        UsuarioCommand ObterUsuarioIdPorEmail(string email);

        IEnumerable<UsuarioCommand> ObterTodos();
    }
}
