namespace DogWalkerAgain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DogMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers");
            DropIndex("dbo.Walks", new[] { "WalkerId" });
            AlterColumn("dbo.Walks", "WalkerId", c => c.Int());
            CreateIndex("dbo.Walks", "WalkerId");
            AddForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers");
            DropIndex("dbo.Walks", new[] { "WalkerId" });
            AlterColumn("dbo.Walks", "WalkerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Walks", "WalkerId");
            AddForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers", "Id", cascadeDelete: true);
        }
    }
}
