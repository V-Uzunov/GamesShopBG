namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDbColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCartItems", "Game_Id", "dbo.Games");
            DropIndex("dbo.ShoppingCartItems", new[] { "Game_Id" });
            RenameColumn(table: "dbo.ShoppingCartItems", name: "Game_Id", newName: "GameId");
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ShoppingCartItems", "CartId", c => c.String());
            AddColumn("dbo.ShoppingCartItems", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ShoppingCartItems", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCartItems", "GameId");
            AddForeignKey("dbo.ShoppingCartItems", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderPlaced");
            DropColumn("dbo.ShoppingCartItems", "ShoppingCartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCartItems", "ShoppingCartId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderPlaced", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ShoppingCartItems", "GameId", "dbo.Games");
            DropIndex("dbo.ShoppingCartItems", new[] { "GameId" });
            AlterColumn("dbo.ShoppingCartItems", "GameId", c => c.Int());
            DropColumn("dbo.ShoppingCartItems", "DateCreated");
            DropColumn("dbo.ShoppingCartItems", "CartId");
            DropColumn("dbo.Orders", "OrderDate");
            RenameColumn(table: "dbo.ShoppingCartItems", name: "GameId", newName: "Game_Id");
            CreateIndex("dbo.ShoppingCartItems", "Game_Id");
            AddForeignKey("dbo.ShoppingCartItems", "Game_Id", "dbo.Games", "Id");
        }
    }
}
