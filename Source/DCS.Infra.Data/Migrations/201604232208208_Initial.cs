namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_TELEFONE",
                c => new
                    {
                        IdTelefone = c.Guid(nullable: false, identity: true),
                        DDD = c.String(nullable: false, maxLength: 2, fixedLength: true),
                        Numero = c.String(nullable: false, maxLength: 9, fixedLength: true),
                        UsuarioId = c.Guid(),
                    })
                .PrimaryKey(t => t.IdTelefone)
                .ForeignKey("dbo.TB_USUARIO", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.TB_USUARIO",
                c => new
                    {
                        IdUsuario = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 36, fixedLength: true),
                        Email_Endereco = c.String(),
                        DataDeCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataDoUltimoLogin = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_TELEFONE", "UsuarioId", "dbo.TB_USUARIO");
            DropIndex("dbo.TB_TELEFONE", new[] { "UsuarioId" });
            DropTable("dbo.TB_USUARIO");
            DropTable("dbo.TB_TELEFONE");
        }
    }
}
