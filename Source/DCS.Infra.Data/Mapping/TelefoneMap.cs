using DCS.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DCS.Infra.Data.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            HasKey(t => t.IdTelefone);

            Ignore(t => t.ValidationResult);
        }
    }
}
