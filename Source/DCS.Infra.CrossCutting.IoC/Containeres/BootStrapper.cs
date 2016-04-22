using DCS.Application.App;
using DCS.Application.App.Interfaces;
using DCS.Domain.Eventos;
using DCS.Domain.Handlers;
using DCS.Domain.Interfaces.Repositorios;
using DCS.Domain.Interfaces.Servicos;
using DCS.Domain.Servicos;
using DCS.Domain.SharedKernel.Events;
using DCS.Domain.SharedKernel.Handlers;
using DCS.Domain.SharedKernel.Interfaces;
using DCS.Infra.Data.Context;
using DCS.Infra.Data.Repositorios;
using DCS.Infra.Data.UnitOfWork;
using DCS.Infra.Data.UnitOfWork.Interface;
using Microsoft.Practices.Unity;

namespace DCS.Infra.CrossCutting.IoC.Containeres
{
    public class BootStrapper
    {
        public static void Register(UnityContainer container)
        {            
            // APP
            container.RegisterType<IUsuarioApp, UsuarioApp>(new HierarchicalLifetimeManager());

            // Domain
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());

            // Infra Dados Repos
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITelefoneRepository, TelefoneRepository>(new HierarchicalLifetimeManager());            
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Infra Dados
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<DCSContext>(new HierarchicalLifetimeManager());

            // Handlers
            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<IHandler<UsuarioCadastradoEvent>, UsuarioCadastradoHandler>(new HierarchicalLifetimeManager());
        }
    }
}
