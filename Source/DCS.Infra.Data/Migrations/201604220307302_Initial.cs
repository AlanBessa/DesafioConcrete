namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        IdTelefone = c.Guid(nullable: false),
                        DDD = c.String(),
                        Numero = c.String(),
                        Usuario_IdUsuario = c.Guid(),
                    })
                .PrimaryKey(t => t.IdTelefone)
                .ForeignKey("dbo.Usuario", t => t.Usuario_IdUsuario)
                .Index(t => t.Usuario_IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Guid(nullable: false),
                        Nome = c.String(),
                        Senha = c.String(),
                        Email_Endereco = c.String(),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        DataDoUltimoLogin = c.DateTime(),
                        Token = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "Usuario_IdUsuario", "dbo.Usuario");
            DropIndex("dbo.Telefone", new[] { "Usuario_IdUsuario" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
        }
    }
}
