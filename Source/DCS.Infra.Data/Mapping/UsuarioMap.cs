using DCS.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DCS.Infra.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Chave primaria
            HasKey(u => u.IdUsuario);

            //Propriedades
            Property(u => u.IdUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            Property(u => u.Senha)
                .IsRequired();

            Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            Property(u => u.DataDeCriacao)
                .HasColumnType("DateTime2")
                .IsRequired();

            Property(u => u.DataAtualizacao)
                .HasColumnType("DateTime2");

            Property(u => u.DataDoUltimoLogin)
                .HasColumnType("DateTime2");

            //Mapeamentos
            ToTable("TB_USUARIO");

            Ignore(u => u.ValidationResult);

            //Relacionamentos
            HasMany(u => u.ListaDeTelefones)
                .WithOptional(t => t.Usuario);
        }
    }
}
