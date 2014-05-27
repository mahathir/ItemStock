namespace ItemStock.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppUserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "Email");
        }
    }
}
