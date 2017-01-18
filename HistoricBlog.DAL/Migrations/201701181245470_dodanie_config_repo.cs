namespace HistoricBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_config_repo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationKey = c.String(),
                        ConfigurationValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configs");
        }
    }
}
