namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Telefone", new[] { "Usuario_IdUsuario" });
            DropColumn("dbo.Telefone", "UsuarioId");
            RenameColumn(table: "dbo.Telefone", name: "Usuario_IdUsuario", newName: "UsuarioId");
            AlterColumn("dbo.Telefone", "UsuarioId", c => c.Guid());
            CreateIndex("dbo.Telefone", "UsuarioId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Telefone", new[] { "UsuarioId" });
            AlterColumn("dbo.Telefone", "UsuarioId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Telefone", name: "UsuarioId", newName: "Usuario_IdUsuario");
            AddColumn("dbo.Telefone", "UsuarioId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Telefone", "Usuario_IdUsuario");
        }
    }
}
