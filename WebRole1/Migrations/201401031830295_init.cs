namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        ReceiptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receipt", t => t.ReceiptId, cascadeDelete: true)
                .Index(t => t.ReceiptId);
            
            CreateTable(
                "dbo.Receipt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ReceiptId", "dbo.Receipt");
            DropForeignKey("dbo.Receipt", "StoreId", "dbo.Store");
            DropIndex("dbo.Product", new[] { "ReceiptId" });
            DropIndex("dbo.Receipt", new[] { "StoreId" });
            DropTable("dbo.Store");
            DropTable("dbo.Receipt");
            DropTable("dbo.Product");
        }
    }
}
