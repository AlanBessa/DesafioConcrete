namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_USUARIO", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_USUARIO", "Senha", c => c.String(nullable: false, maxLength: 36, fixedLength: true));
        }
    }
}
