using DCS.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DCS.Infra.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            HasKey(u => u.IdUsuario);

            Ignore(u => u.ValidationResult);

            HasMany(u => u.ListaDeTelefones)
                .WithOptional(t => t.Usuario);
        }
    }
}
