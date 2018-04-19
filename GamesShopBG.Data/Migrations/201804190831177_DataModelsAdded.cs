namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataModelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        ThumbnailUrl = c.String(nullable: false, maxLength: 2040),
                        PublishDate = c.DateTime(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AddressLine = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        City = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 50),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlaced = c.DateTime(nullable: false),
                        Game_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.Double(nullable: false),
                        VideoId = c.String(nullable: false, maxLength: 11),
                        ThumbnailUrl = c.String(maxLength: 2047),
                        Description = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ShoppingCartId = c.String(),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartItems", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "GameId", "dbo.Games");
            DropForeignKey("dbo.Orders", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCartItems", new[] { "Game_Id" });
            DropIndex("dbo.OrderDetails", new[] { "GameId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Game_Id" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            DropTable("dbo.ShoppingCartItems");
            DropTable("dbo.Games");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Articles");
        }
    }
}
