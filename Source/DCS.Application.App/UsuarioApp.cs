using DCS.Application.App.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using DCS.Domain.Interfaces.Servicos;
using DCS.Infra.Data.UnitOfWork.Interface;
using DCS.Application.App.Command.UsuarioCommands;
using DCS.Application.App.Adapters;

namespace DCS.Application.App
{
    public class UsuarioApp : BaseApp, IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITelefoneService _telefoneService;

        public UsuarioApp(IUsuarioService usuarioService, ITelefoneService telefoneService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _telefoneService = telefoneService;
        }

        public UsuarioCommand Registrar(UsuarioCommand usuarioCommand)
        {            
            var usuario = _usuarioService.Adicionar(UsuarioAdapter.ToDomainModel(usuarioCommand));

            if (Commit())
                return UsuarioAdapter.ToModelDomain(usuario);

            return null;           
        }

        public UsuarioCommand Autenticar(string email, string senha)
        {
            var usuario = _usuarioService.Autenticar(email, senha);

            return UsuarioAdapter.ToModelDomain(usuario);
        }

        public void AtualizarDataDoUltimoLoginPorId(Guid id)
        {
            var idGuid = new Guid(id.ToString());

            var usuario = _usuarioService.ObterPorId(idGuid);
            usuario.DataDoUltimoLogin = DateTime.Now;

            _usuarioService.Atualizar(usuario);

            Commit();
        }

        public UsuarioCommand ObterPorId(Guid id)
        {
            var usuario = _usuarioService.ObterPorId(id);
            usuario.DefinirTelefones(_telefoneService.ObterTelefonesPorUsuario(usuario.IdUsuario).ToList());

            return UsuarioAdapter.ToModelDomain(usuario);
        }

        public UsuarioCommand ArmazenarTokenDoUsuarioPorEmail(string email, string token)
        {
            var usuario = _usuarioService.ObterPorEmail(email);
            usuario.Token = token;

            _usuarioService.Atualizar(usuario);

            if (Commit())
            {
                var usuarioCommand = new UsuarioCommand(usuario.Nome, usuario.Email.Endereco, string.Empty, null);
                usuarioCommand.IdUsuario = usuario.IdUsuario;
                usuarioCommand.Token = token;

                return usuarioCommand;
            }

            return null;
        }

        public IEnumerable<UsuarioCommand> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
