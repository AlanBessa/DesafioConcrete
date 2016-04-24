using DCS.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCS.Infra.Data.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            // Chave primaria
            HasKey(t => t.IdTelefone);

            //Propriedades
            Property(t => t.IdTelefone)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(t => t.DDD)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired();

            Property(t => t.Numero)
                .HasMaxLength(9)
                .IsFixedLength()
                .IsRequired();

            //Mapeamentos
            ToTable("TB_TELEFONE");

            Ignore(t => t.ValidationResult);

            //Relacionamentos
            HasOptional(t => t.Usuario)
                .WithMany(u => u.ListaDeTelefones)
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
