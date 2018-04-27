namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "VideoUrl", c => c.String(nullable: false, maxLength: 2048));
            DropColumn("dbo.Games", "VideoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "VideoId", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Games", "VideoUrl");
        }
    }
}
