namespace HistoricBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_config_repo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Configs", "ConfigurationKey", c => c.String(nullable: false));
            AlterColumn("dbo.Configs", "ConfigurationValue", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Configs", "ConfigurationValue", c => c.String());
            AlterColumn("dbo.Configs", "ConfigurationKey", c => c.String());
        }
    }
}
