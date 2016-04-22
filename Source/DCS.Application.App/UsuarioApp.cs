using DCS.Application.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCS.Domain.Entidades;
using DCS.Domain.Interfaces.Servicos;
using DCS.Infra.Data.UnitOfWork.Interface;
using DCS.Application.App.Command.UsuarioCommands;
using DCS.Application.App.Adapters;

namespace DCS.Application.App
{
    public class UsuarioApp : BaseApp, IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApp(IUsuarioService usuarioService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioCommand Registrar(UsuarioCommand usuario)
        {
            if (!_notifications.HasNotifications())
            {
                _usuarioService.Adicionar(UsuarioAdapter.ToDomainModel(usuario));
                Commit();
            }

            return usuario;
        }

        public UsuarioCommand Autenticar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
