using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.Interfaces.Servicos
{
    public interface ITelefoneService
    {
        IEnumerable<Telefone> ObterTelefonesPorUsuario(Guid idUsuario);
    }
}
