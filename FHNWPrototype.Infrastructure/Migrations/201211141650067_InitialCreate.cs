namespace FHNWPrototype.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ProfilePicture = c.Binary(),
                        Key = c.Guid(nullable: false),
                        GeoLocation_GeoLocationID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GeoLocations", t => t.GeoLocation_GeoLocationID)
                .Index(t => t.GeoLocation_GeoLocationID);
            
            CreateTable(
                "dbo.GeoLocations",
                c => new
                    {
                        GeoLocationID = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Altitude = c.Double(nullable: false),
                        Accuracy = c.Double(nullable: false),
                        AltitudeAccuracy = c.Double(nullable: false),
                        Heading = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GeoLocationID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Key = c.Guid(nullable: false),
                        OrganizationAccountID = c.Int(),
                        Wall_ID = c.Int(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.OrganizationAccountID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.OrganizationAccountID)
                .Index(t => t.Wall_ID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.OrganizationAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EmailSuffix = c.String(),
                        Email = c.String(),
                        AvatarPicture = c.Binary(),
                        Key = c.Guid(nullable: false),
                        Organization_ID = c.Int(),
                        Location_GeoLocationID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_ID)
                .ForeignKey("dbo.GeoLocations", t => t.Location_GeoLocationID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.Organization_ID)
                .Index(t => t.Location_GeoLocationID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EmailSuffix = c.String(),
                        HeaderPicture = c.Binary(),
                        Key = c.Guid(nullable: false),
                        HeadquatersLocation_GeoLocationID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GeoLocations", t => t.HeadquatersLocation_GeoLocationID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.HeadquatersLocation_GeoLocationID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.ContentStreams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.Guid(nullable: false),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        Post_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.BasicProfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReferenceKey = c.Guid(nullable: false),
                        ReferenceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CommentLikes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        Comment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .ForeignKey("dbo.Comments", t => t.Comment_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Comment_ID);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        Post_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .ForeignKey("dbo.Posts", t => t.Post_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Post_ID);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(),
                        Text = c.String(),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Hashtag_ID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.AuthorID)
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_ID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.AuthorID)
                .Index(t => t.Hashtag_ID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Key = c.Guid(nullable: false),
                        AllianceContext_ID = c.Int(),
                        OrganizationContext_ID = c.Int(),
                        GroupContext_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alliances", t => t.AllianceContext_ID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.OrganizationContext_ID)
                .ForeignKey("dbo.Groups", t => t.GroupContext_ID)
                .Index(t => t.AllianceContext_ID)
                .Index(t => t.OrganizationContext_ID)
                .Index(t => t.GroupContext_ID);
            
            CreateTable(
                "dbo.Alliances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        HeaderPicture = c.Binary(),
                        ProfilePicture = c.Binary(),
                        Key = c.Guid(nullable: false),
                        Coordinator_ID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.Coordinator_ID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.Coordinator_ID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.AllianceMembershipStateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AllianceRequestedID = c.Int(),
                        AllianceMembershipAction = c.Int(nullable: false),
                        OrganizationRequestorID = c.Int(),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alliances", t => t.AllianceRequestedID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.OrganizationRequestorID)
                .Index(t => t.AllianceRequestedID)
                .Index(t => t.OrganizationRequestorID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        HeaderPicture = c.Binary(),
                        ProfilePicture = c.Binary(),
                        Key = c.Guid(nullable: false),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.Wall_ID);
            
            CreateTable(
                "dbo.GroupMembershipStateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestorAccountID = c.Int(),
                        RequestedGroupID = c.Int(),
                        GroupMembershipAction = c.Int(nullable: false),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.RequestedGroupID)
                .ForeignKey("dbo.UserAccounts", t => t.RequestorAccountID)
                .Index(t => t.RequestedGroupID)
                .Index(t => t.RequestorAccountID);
            
            CreateTable(
                "dbo.Retweets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Retweeter_ID = c.Int(),
                        Tweet_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.Retweeter_ID)
                .ForeignKey("dbo.Tweets", t => t.Tweet_ID)
                .Index(t => t.Retweeter_ID)
                .Index(t => t.Tweet_ID);
            
            CreateTable(
                "dbo.PartnershipStateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        SenderID = c.Int(),
                        ReceiverID = c.Int(),
                        ActionDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.SenderID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.ReceiverID)
                .Index(t => t.SenderID)
                .Index(t => t.ReceiverID);
            
            CreateTable(
                "dbo.FriendshipStateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        SenderID = c.Int(),
                        ReceiverID = c.Int(),
                        ActionDateTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.SenderID)
                .ForeignKey("dbo.UserAccounts", t => t.ReceiverID)
                .Index(t => t.SenderID)
                .Index(t => t.ReceiverID);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.Guid(nullable: false),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LibraryID = c.Int(),
                        ParentFolderID = c.Int(),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Folders", t => t.ParentFolderID)
                .ForeignKey("dbo.Libraries", t => t.LibraryID)
                .Index(t => t.ParentFolderID)
                .Index(t => t.LibraryID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        ParentFolder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.Author_ID)
                .ForeignKey("dbo.Folders", t => t.ParentFolder_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.ParentFolder_ID);
            
            CreateTable(
                "dbo.Bookmarks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Reference = c.Guid(nullable: false),
                        Key = c.Guid(nullable: false),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Key = c.Guid(nullable: false),
                        Coordinator_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrganizationAccounts", t => t.Coordinator_ID)
                .Index(t => t.Coordinator_ID);
            
            CreateTable(
                "dbo.WorkPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WbsCorrelationToken = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        ParentWorkPackageID = c.Int(),
                        Comments = c.String(),
                        IsMilestone = c.Boolean(nullable: false),
                        Key = c.Guid(nullable: false),
                        Owner_ID = c.Int(),
                        Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.Owner_ID)
                .ForeignKey("dbo.WorkPackages", t => t.ParentWorkPackageID)
                .ForeignKey("dbo.Projects", t => t.Project_ID)
                .Index(t => t.Owner_ID)
                .Index(t => t.ParentWorkPackageID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.SystemAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        Holder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Holder_ID)
                .Index(t => t.Holder_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SystemAccounts", new[] { "Holder_ID" });
            DropIndex("dbo.WorkPackages", new[] { "Project_ID" });
            DropIndex("dbo.WorkPackages", new[] { "ParentWorkPackageID" });
            DropIndex("dbo.WorkPackages", new[] { "Owner_ID" });
            DropIndex("dbo.Projects", new[] { "Coordinator_ID" });
            DropIndex("dbo.Bookmarks", new[] { "Owner_ID" });
            DropIndex("dbo.Documents", new[] { "ParentFolder_ID" });
            DropIndex("dbo.Documents", new[] { "Author_ID" });
            DropIndex("dbo.Folders", new[] { "LibraryID" });
            DropIndex("dbo.Folders", new[] { "ParentFolderID" });
            DropIndex("dbo.Libraries", new[] { "Owner_ID" });
            DropIndex("dbo.FriendshipStateInfoes", new[] { "ReceiverID" });
            DropIndex("dbo.FriendshipStateInfoes", new[] { "SenderID" });
            DropIndex("dbo.PartnershipStateInfoes", new[] { "ReceiverID" });
            DropIndex("dbo.PartnershipStateInfoes", new[] { "SenderID" });
            DropIndex("dbo.Retweets", new[] { "Tweet_ID" });
            DropIndex("dbo.Retweets", new[] { "Retweeter_ID" });
            DropIndex("dbo.GroupMembershipStateInfoes", new[] { "RequestorAccountID" });
            DropIndex("dbo.GroupMembershipStateInfoes", new[] { "RequestedGroupID" });
            DropIndex("dbo.Groups", new[] { "Wall_ID" });
            DropIndex("dbo.AllianceMembershipStateInfoes", new[] { "OrganizationRequestorID" });
            DropIndex("dbo.AllianceMembershipStateInfoes", new[] { "AllianceRequestedID" });
            DropIndex("dbo.Alliances", new[] { "Wall_ID" });
            DropIndex("dbo.Alliances", new[] { "Coordinator_ID" });
            DropIndex("dbo.Hashtags", new[] { "GroupContext_ID" });
            DropIndex("dbo.Hashtags", new[] { "OrganizationContext_ID" });
            DropIndex("dbo.Hashtags", new[] { "AllianceContext_ID" });
            DropIndex("dbo.Tweets", new[] { "Wall_ID" });
            DropIndex("dbo.Tweets", new[] { "Hashtag_ID" });
            DropIndex("dbo.Tweets", new[] { "AuthorID" });
            DropIndex("dbo.PostLikes", new[] { "Post_ID" });
            DropIndex("dbo.PostLikes", new[] { "Author_ID" });
            DropIndex("dbo.CommentLikes", new[] { "Comment_ID" });
            DropIndex("dbo.CommentLikes", new[] { "Author_ID" });
            DropIndex("dbo.Comments", new[] { "Post_ID" });
            DropIndex("dbo.Comments", new[] { "Author_ID" });
            DropIndex("dbo.Posts", new[] { "Wall_ID" });
            DropIndex("dbo.Posts", new[] { "Author_ID" });
            DropIndex("dbo.ContentStreams", new[] { "Owner_ID" });
            DropIndex("dbo.Organizations", new[] { "Wall_ID" });
            DropIndex("dbo.Organizations", new[] { "HeadquatersLocation_GeoLocationID" });
            DropIndex("dbo.OrganizationAccounts", new[] { "Wall_ID" });
            DropIndex("dbo.OrganizationAccounts", new[] { "Location_GeoLocationID" });
            DropIndex("dbo.OrganizationAccounts", new[] { "Organization_ID" });
            DropIndex("dbo.UserAccounts", new[] { "UserID" });
            DropIndex("dbo.UserAccounts", new[] { "Wall_ID" });
            DropIndex("dbo.UserAccounts", new[] { "OrganizationAccountID" });
            DropIndex("dbo.Users", new[] { "GeoLocation_GeoLocationID" });
            DropForeignKey("dbo.SystemAccounts", "Holder_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.WorkPackages", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.WorkPackages", "ParentWorkPackageID", "dbo.WorkPackages");
            DropForeignKey("dbo.WorkPackages", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Projects", "Coordinator_ID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Bookmarks", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Documents", "ParentFolder_ID", "dbo.Folders");
            DropForeignKey("dbo.Documents", "Author_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Folders", "LibraryID", "dbo.Libraries");
            DropForeignKey("dbo.Folders", "ParentFolderID", "dbo.Folders");
            DropForeignKey("dbo.Libraries", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.FriendshipStateInfoes", "ReceiverID", "dbo.UserAccounts");
            DropForeignKey("dbo.FriendshipStateInfoes", "SenderID", "dbo.UserAccounts");
            DropForeignKey("dbo.PartnershipStateInfoes", "ReceiverID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.PartnershipStateInfoes", "SenderID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Retweets", "Tweet_ID", "dbo.Tweets");
            DropForeignKey("dbo.Retweets", "Retweeter_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.GroupMembershipStateInfoes", "RequestorAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.GroupMembershipStateInfoes", "RequestedGroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.AllianceMembershipStateInfoes", "OrganizationRequestorID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.AllianceMembershipStateInfoes", "AllianceRequestedID", "dbo.Alliances");
            DropForeignKey("dbo.Alliances", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Alliances", "Coordinator_ID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Hashtags", "GroupContext_ID", "dbo.Groups");
            DropForeignKey("dbo.Hashtags", "OrganizationContext_ID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Hashtags", "AllianceContext_ID", "dbo.Alliances");
            DropForeignKey("dbo.Tweets", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Tweets", "Hashtag_ID", "dbo.Hashtags");
            DropForeignKey("dbo.Tweets", "AuthorID", "dbo.UserAccounts");
            DropForeignKey("dbo.PostLikes", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.PostLikes", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.CommentLikes", "Comment_ID", "dbo.Comments");
            DropForeignKey("dbo.CommentLikes", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Comments", "Post_ID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Posts", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Posts", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.ContentStreams", "Owner_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Organizations", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Organizations", "HeadquatersLocation_GeoLocationID", "dbo.GeoLocations");
            DropForeignKey("dbo.OrganizationAccounts", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.OrganizationAccounts", "Location_GeoLocationID", "dbo.GeoLocations");
            DropForeignKey("dbo.OrganizationAccounts", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.UserAccounts", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserAccounts", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.UserAccounts", "OrganizationAccountID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Users", "GeoLocation_GeoLocationID", "dbo.GeoLocations");
            DropTable("dbo.SystemAccounts");
            DropTable("dbo.WorkPackages");
            DropTable("dbo.Projects");
            DropTable("dbo.Bookmarks");
            DropTable("dbo.Documents");
            DropTable("dbo.Folders");
            DropTable("dbo.Libraries");
            DropTable("dbo.FriendshipStateInfoes");
            DropTable("dbo.PartnershipStateInfoes");
            DropTable("dbo.Retweets");
            DropTable("dbo.GroupMembershipStateInfoes");
            DropTable("dbo.Groups");
            DropTable("dbo.AllianceMembershipStateInfoes");
            DropTable("dbo.Alliances");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Tweets");
            DropTable("dbo.PostLikes");
            DropTable("dbo.CommentLikes");
            DropTable("dbo.BasicProfiles");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.ContentStreams");
            DropTable("dbo.Organizations");
            DropTable("dbo.OrganizationAccounts");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.GeoLocations");
            DropTable("dbo.Users");
        }
    }
}
