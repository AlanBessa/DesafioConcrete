﻿using DCS.Application.App.Command.UsuarioCommands;
using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DCS.Application.App.Interfaces
{
    public interface IUsuarioApp
    {
        UsuarioCommand Registrar(UsuarioCommand usuario);

        UsuarioCommand Autenticar(string email, string senha);

        Usuario ObterPorId(Guid id);

        IEnumerable<Usuario> ObterTodos();
    }
}
