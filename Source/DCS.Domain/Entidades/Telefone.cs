using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.Entidades
{
    public class Telefone
    {
        public Telefone()
        {
            IdTelefone = Guid.NewGuid();
        }

        public Guid IdTelefone { get; set; }

        public string DDD { get; set; }

        public string Numero { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
