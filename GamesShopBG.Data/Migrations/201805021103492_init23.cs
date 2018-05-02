namespace GamesShopBG.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "VideoUrl", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "VideoUrl", c => c.String(nullable: false, maxLength: 2048));
        }
    }
}
