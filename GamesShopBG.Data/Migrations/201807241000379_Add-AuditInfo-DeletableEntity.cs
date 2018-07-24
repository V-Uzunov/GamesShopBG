namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditInfoDeletableEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Games", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Games", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Orders", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.AspNetRoles", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ShoppingCartItems", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ShoppingCartItems", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.ShoppingCartItems", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.ShoppingCartItems", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
            CreateIndex("dbo.Games", "IsDeleted");
            CreateIndex("dbo.Orders", "IsDeleted");
            CreateIndex("dbo.AspNetRoles", "IsDeleted");
            CreateIndex("dbo.ShoppingCartItems", "IsDeleted");
            CreateIndex("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.ShoppingCartItems", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCartItems", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropIndex("dbo.ShoppingCartItems", new[] { "IsDeleted" });
            DropIndex("dbo.AspNetRoles", new[] { "IsDeleted" });
            DropIndex("dbo.Orders", new[] { "IsDeleted" });
            DropIndex("dbo.Games", new[] { "IsDeleted" });
            DropColumn("dbo.AspNetUsers", "ModifiedOn");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "DeletedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.ShoppingCartItems", "ModifiedOn");
            DropColumn("dbo.ShoppingCartItems", "CreatedOn");
            DropColumn("dbo.ShoppingCartItems", "DeletedOn");
            DropColumn("dbo.ShoppingCartItems", "IsDeleted");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "ModifiedOn");
            DropColumn("dbo.AspNetRoles", "CreatedOn");
            DropColumn("dbo.AspNetRoles", "DeletedOn");
            DropColumn("dbo.AspNetRoles", "IsDeleted");
            DropColumn("dbo.Orders", "ModifiedOn");
            DropColumn("dbo.Orders", "CreatedOn");
            DropColumn("dbo.Orders", "DeletedOn");
            DropColumn("dbo.Orders", "IsDeleted");
            DropColumn("dbo.Games", "ModifiedOn");
            DropColumn("dbo.Games", "CreatedOn");
            DropColumn("dbo.Games", "DeletedOn");
            DropColumn("dbo.Games", "IsDeleted");
        }
    }
}
