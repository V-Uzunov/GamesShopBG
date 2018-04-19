namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRoles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropTable("dbo.Articles");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Articles", "AuthorId");
            AddForeignKey("dbo.Articles", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
