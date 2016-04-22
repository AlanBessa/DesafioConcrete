using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DCS.Domain.Entidades;
using DCS.Domain.SharedKernel.Events;
using DCS.Domain.SharedKernel.Interfaces;

namespace DCS.Domain.Test.UsuarioTests
{
    [TestClass]
    public class UsuarioTest
    {
        protected readonly IHandler<DomainNotification> Notifications;

        public UsuarioTest()
        {
            Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        [TestMethod]
        public void CriarUsuarioValidoComSucesso()
        {
            var usuario = new Usuario("Alan Bessa", "bessa.alan@gmail.com", "123456", null, null);

            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void CriarUsuarioComEmailVazio()
        {
            var usuario = new Usuario("Alan Bessa", "", "123456", null, null);

            Assert.IsNotNull(usuario);
            Assert.IsNull(usuario.Email);
        }

        //[TestMethod]
        //public void CriarUsuarioComSenhaVazia()
    }
}
