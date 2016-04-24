namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_TELEFONE", "DDD", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AlterColumn("dbo.TB_TELEFONE", "Numero", c => c.String(nullable: false, maxLength: 9, unicode: false));
            AlterColumn("dbo.TB_USUARIO", "Nome", c => c.String(nullable: false, maxLength: 150, unicode: false));
            AlterColumn("dbo.TB_USUARIO", "Senha", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.TB_USUARIO", "Email_Endereco", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.TB_USUARIO", "Token", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_USUARIO", "Token", c => c.String());
            AlterColumn("dbo.TB_USUARIO", "Email_Endereco", c => c.String());
            AlterColumn("dbo.TB_USUARIO", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.TB_USUARIO", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.TB_TELEFONE", "Numero", c => c.String(nullable: false, maxLength: 9, fixedLength: true));
            AlterColumn("dbo.TB_TELEFONE", "DDD", c => c.String(nullable: false, maxLength: 2, fixedLength: true));
        }
    }
}
