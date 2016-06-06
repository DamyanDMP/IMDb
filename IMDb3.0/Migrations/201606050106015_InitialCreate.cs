namespace IMDb3._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorsID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PictureUrl = c.String(),
                        LinkUrl = c.String(),
                        TVSeriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorsID)
                .ForeignKey("dbo.TVSeries", t => t.TVSeriesID, cascadeDelete: true)
                .Index(t => t.TVSeriesID);
            
            CreateTable(
                "dbo.TVSeries",
                c => new
                    {
                        TVSeriesID = c.Int(nullable: false, identity: true),
                        PosterUlr = c.String(),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(),
                        NumberSeasons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TVSeriesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actors", "TVSeriesID", "dbo.TVSeries");
            DropIndex("dbo.Actors", new[] { "TVSeriesID" });
            DropTable("dbo.TVSeries");
            DropTable("dbo.Actors");
        }
    }
}
