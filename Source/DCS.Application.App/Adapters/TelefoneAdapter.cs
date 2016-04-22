using DCS.Application.App.Command.TelefoneCommands;
using DCS.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Application.App.Adapters
{
    public class TelefoneAdapter
    {
        public static Telefone ToDomainModel(TelefoneCommand telefoneCommand)
        {
            var telefone = new Telefone(
                telefoneCommand.DDD,
                telefoneCommand.Numero,
                telefoneCommand.IdTelefone);

            return telefone;
        }

        public static TelefoneCommand ToModelDomain(Telefone telefone)
        {
            var telefoneCommand = new TelefoneCommand (
                telefone.DDD,
                telefone.Numero);

            telefoneCommand.IdTelefone = telefone.IdTelefone;

            return telefoneCommand;
        }
    }
}
