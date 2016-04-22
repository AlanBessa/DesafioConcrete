using DCS.Domain.Eventos;
using DCS.Domain.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace DCS.Domain.Handlers
{
    public class UsuarioCadastradoHandler : IHandler<UsuarioCadastradoEvent>
    {
        private List<UsuarioCadastradoEvent> _notifications;
        
        public List<UsuarioCadastradoEvent> GetValues()
        {
            return _notifications;
        }

        public void Handle(UsuarioCadastradoEvent args)
        {
            //Envia Email
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public IEnumerable<UsuarioCadastradoEvent> Notify()
        {
            return GetValues();
        }

        public void Dispose()
        {
            _notifications = new List<UsuarioCadastradoEvent>();
        }
    }
}
