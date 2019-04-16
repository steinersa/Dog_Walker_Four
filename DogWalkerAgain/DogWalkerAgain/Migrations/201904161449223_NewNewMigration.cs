namespace DogWalkerAgain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demeanors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalFriendly = c.Boolean(nullable: false),
                        KidFriendly = c.Boolean(nullable: false),
                        Comments = c.String(),
                        DogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dogs", t => t.DogId, cascadeDelete: true)
                .Index(t => t.DogId);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Breed = c.String(nullable: false),
                        Size = c.String(nullable: false),
                        SpayedNeutered = c.Boolean(nullable: false),
                        Rating = c.Int(),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Healths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeartCondition = c.Boolean(nullable: false),
                        SeizureCondition = c.Boolean(nullable: false),
                        Allergies = c.Boolean(nullable: false),
                        Blind = c.Boolean(nullable: false),
                        Deaf = c.Boolean(nullable: false),
                        PhysicalLimitations = c.Boolean(nullable: false),
                        Comments = c.String(),
                        DogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dogs", t => t.DogId, cascadeDelete: true)
                .Index(t => t.DogId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WalkDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Distance = c.Double(nullable: false),
                        NumberOfDogs = c.Int(nullable: false),
                        WalkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walks", t => t.WalkId, cascadeDelete: true)
                .Index(t => t.WalkId);
            
            CreateTable(
                "dbo.Walks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WalkerApprovalStatus = c.String(),
                        OwnersApprovalStatus = c.String(),
                        WalkComplete = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        WalkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Walkers", t => t.WalkerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.WalkerId);
            
            CreateTable(
                "dbo.Walkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Rating = c.Int(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalkDetails", "WalkId", "dbo.Walks");
            DropForeignKey("dbo.Walks", "WalkerId", "dbo.Walkers");
            DropForeignKey("dbo.Walkers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Walks", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Healths", "DogId", "dbo.Dogs");
            DropForeignKey("dbo.Demeanors", "DogId", "dbo.Dogs");
            DropForeignKey("dbo.Dogs", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Owners", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Walkers", new[] { "ApplicationId" });
            DropIndex("dbo.Walks", new[] { "WalkerId" });
            DropIndex("dbo.Walks", new[] { "OwnerId" });
            DropIndex("dbo.WalkDetails", new[] { "WalkId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Healths", new[] { "DogId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Owners", new[] { "ApplicationId" });
            DropIndex("dbo.Dogs", new[] { "OwnerId" });
            DropIndex("dbo.Demeanors", new[] { "DogId" });
            DropTable("dbo.Walkers");
            DropTable("dbo.Walks");
            DropTable("dbo.WalkDetails");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Healths");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Owners");
            DropTable("dbo.Dogs");
            DropTable("dbo.Demeanors");
        }
    }
}
