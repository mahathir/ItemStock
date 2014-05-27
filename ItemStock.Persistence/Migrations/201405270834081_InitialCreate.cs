namespace ItemStock.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Stock = c.Int(nullable: false),
                        BuyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimalSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDateTime = c.DateTime(),
                        LastModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockTransactionItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDateTime = c.DateTime(),
                        LastModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDateTime = c.DateTime(),
                        LastModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        CreatedDateTime = c.DateTime(),
                        LastModifiedDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppUsers");
            DropTable("dbo.StockTransactions");
            DropTable("dbo.StockTransactionItems");
            DropTable("dbo.Goods");
        }
    }
}
