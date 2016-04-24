namespace DCS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_USUARIO", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_USUARIO", "Token");
        }
    }
}
