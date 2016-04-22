using DCS.Domain.Entidades;
using DCS.Domain.SharedKernel.Interfaces;
using System;

namespace DCS.Domain.Eventos
{
    public class UsuarioCadastradoEvent : IDomainEvent
    {
        public UsuarioCadastradoEvent(Usuario usuario) : this(usuario, DateTime.Now) { }

        public UsuarioCadastradoEvent(Usuario usuario, DateTime dataOcorrencia)
        {
            Versao = 1;
            Usuario = usuario;
            DataOcorrencia = dataOcorrencia;
        }

        public Usuario Usuario { get; set; }

        public DateTime DataOcorrencia { get; private set; }

        public int Versao { get; private set; }
    }
}
