namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Telefone", "UsuarioId", c => c.Guid(nullable: false));
            DropColumn("dbo.Usuario", "Token");
            DropColumn("dbo.Usuario", "ValidationResult_Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "ValidationResult_Message", c => c.String());
            AddColumn("dbo.Usuario", "Token", c => c.Guid(nullable: false));
            DropColumn("dbo.Telefone", "UsuarioId");
        }
    }
}
