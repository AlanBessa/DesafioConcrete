using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Application.App.Command.TelefoneCommands
{
    public class TelefoneCommand
    {
        public TelefoneCommand(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        #region "Propriedades"

        public Guid? IdTelefone { get; set; }

        public string DDD { get; set; }

        public string Numero { get; set; }

        #endregion
    }
}
