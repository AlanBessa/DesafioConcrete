using DCS.Domain.Entidades;
using DCS.Infra.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DCS.Infra.Data.Context
{
    public class DCSContext : DbContext
    {
        public DCSContext()
            : base ("DefaultConnection")
        {
            Database.SetInitializer<DCSContext>(null);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // ModelConfiguration
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TelefoneMap());

            modelBuilder.Properties()
               .Where(p => p.Name == "Id" + p.ReflectedType.Name)
               .Configure(p => p.IsKey());
        }
    }
}
