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
                        LastAccessOnNotifications = c.DateTime(nullable: false),
                        Tag = c.String(),
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
                        Tag = c.String(),
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
                "dbo.Retweets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                        Tweet_ID = c.Int(),
                        Wall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .ForeignKey("dbo.Tweets", t => t.Tweet_ID)
                .ForeignKey("dbo.ContentStreams", t => t.Wall_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Tweet_ID)
                .Index(t => t.Wall_ID);
            
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
                "dbo.FriendshipStateInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SCMRelationshipType = c.Int(nullable: false),
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
                "dbo.SystemAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        LastCheck = c.DateTime(nullable: false),
                        Holder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Holder_ID)
                .Index(t => t.Holder_ID);
            
            CreateTable(
                "dbo.MessengerPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChatRoom = c.Guid(nullable: false),
                        Text = c.String(),
                        PublishDateTime = c.DateTime(nullable: false),
                        Key = c.Guid(nullable: false),
                        Author_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Author_ID)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.Guid(nullable: false),
                        Event_ID = c.Int(),
                        NotifiedTo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.Event_ID)
                .ForeignKey("dbo.BasicProfiles", t => t.NotifiedTo_ID)
                .Index(t => t.Event_ID)
                .Index(t => t.NotifiedTo_ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        TriggeredOn = c.DateTime(nullable: false),
                        PostOrComment = c.Guid(nullable: false),
                        Key = c.Guid(nullable: false),
                        TriggeredBy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.TriggeredBy_ID)
                .Index(t => t.TriggeredBy_ID);
            
            CreateTable(
                "dbo.Suscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReferencePoint = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Key = c.Guid(nullable: false),
                        Suscriber_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasicProfiles", t => t.Suscriber_ID)
                .Index(t => t.Suscriber_ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Key = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Suscriptions", new[] { "Suscriber_ID" });
            DropIndex("dbo.Events", new[] { "TriggeredBy_ID" });
            DropIndex("dbo.Notifications", new[] { "NotifiedTo_ID" });
            DropIndex("dbo.Notifications", new[] { "Event_ID" });
            DropIndex("dbo.MessengerPosts", new[] { "Author_ID" });
            DropIndex("dbo.SystemAccounts", new[] { "Holder_ID" });
            DropIndex("dbo.Bookmarks", new[] { "Owner_ID" });
            DropIndex("dbo.WorkPackages", new[] { "Project_ID" });
            DropIndex("dbo.WorkPackages", new[] { "ParentWorkPackageID" });
            DropIndex("dbo.WorkPackages", new[] { "Owner_ID" });
            DropIndex("dbo.Projects", new[] { "Coordinator_ID" });
            DropIndex("dbo.Documents", new[] { "ParentFolder_ID" });
            DropIndex("dbo.Documents", new[] { "Author_ID" });
            DropIndex("dbo.Folders", new[] { "LibraryID" });
            DropIndex("dbo.Folders", new[] { "ParentFolderID" });
            DropIndex("dbo.Libraries", new[] { "Owner_ID" });
            DropIndex("dbo.Groups", new[] { "Wall_ID" });
            DropIndex("dbo.GroupMembershipStateInfoes", new[] { "RequestorAccountID" });
            DropIndex("dbo.GroupMembershipStateInfoes", new[] { "RequestedGroupID" });
            DropIndex("dbo.FriendshipStateInfoes", new[] { "ReceiverID" });
            DropIndex("dbo.FriendshipStateInfoes", new[] { "SenderID" });
            DropIndex("dbo.Alliances", new[] { "Wall_ID" });
            DropIndex("dbo.Alliances", new[] { "Coordinator_ID" });
            DropIndex("dbo.AllianceMembershipStateInfoes", new[] { "OrganizationRequestorID" });
            DropIndex("dbo.AllianceMembershipStateInfoes", new[] { "AllianceRequestedID" });
            DropIndex("dbo.PartnershipStateInfoes", new[] { "ReceiverID" });
            DropIndex("dbo.PartnershipStateInfoes", new[] { "SenderID" });
            DropIndex("dbo.Retweets", new[] { "Wall_ID" });
            DropIndex("dbo.Retweets", new[] { "Tweet_ID" });
            DropIndex("dbo.Retweets", new[] { "Author_ID" });
            DropIndex("dbo.Tweets", new[] { "Wall_ID" });
            DropIndex("dbo.Tweets", new[] { "Author_ID" });
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
            DropForeignKey("dbo.Suscriptions", "Suscriber_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Events", "TriggeredBy_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Notifications", "NotifiedTo_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Notifications", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.MessengerPosts", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.SystemAccounts", "Holder_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Bookmarks", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.WorkPackages", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.WorkPackages", "ParentWorkPackageID", "dbo.WorkPackages");
            DropForeignKey("dbo.WorkPackages", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Projects", "Coordinator_ID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Documents", "ParentFolder_ID", "dbo.Folders");
            DropForeignKey("dbo.Documents", "Author_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Folders", "LibraryID", "dbo.Libraries");
            DropForeignKey("dbo.Folders", "ParentFolderID", "dbo.Folders");
            DropForeignKey("dbo.Libraries", "Owner_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Groups", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.GroupMembershipStateInfoes", "RequestorAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.GroupMembershipStateInfoes", "RequestedGroupID", "dbo.Groups");
            DropForeignKey("dbo.FriendshipStateInfoes", "ReceiverID", "dbo.UserAccounts");
            DropForeignKey("dbo.FriendshipStateInfoes", "SenderID", "dbo.UserAccounts");
            DropForeignKey("dbo.Alliances", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Alliances", "Coordinator_ID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.AllianceMembershipStateInfoes", "OrganizationRequestorID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.AllianceMembershipStateInfoes", "AllianceRequestedID", "dbo.Alliances");
            DropForeignKey("dbo.PartnershipStateInfoes", "ReceiverID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.PartnershipStateInfoes", "SenderID", "dbo.OrganizationAccounts");
            DropForeignKey("dbo.Retweets", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Retweets", "Tweet_ID", "dbo.Tweets");
            DropForeignKey("dbo.Retweets", "Author_ID", "dbo.BasicProfiles");
            DropForeignKey("dbo.Tweets", "Wall_ID", "dbo.ContentStreams");
            DropForeignKey("dbo.Tweets", "Author_ID", "dbo.BasicProfiles");
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
            DropTable("dbo.Tags");
            DropTable("dbo.Suscriptions");
            DropTable("dbo.Events");
            DropTable("dbo.Notifications");
            DropTable("dbo.MessengerPosts");
            DropTable("dbo.SystemAccounts");
            DropTable("dbo.Bookmarks");
            DropTable("dbo.WorkPackages");
            DropTable("dbo.Projects");
            DropTable("dbo.Documents");
            DropTable("dbo.Folders");
            DropTable("dbo.Libraries");
            DropTable("dbo.Groups");
            DropTable("dbo.GroupMembershipStateInfoes");
            DropTable("dbo.FriendshipStateInfoes");
            DropTable("dbo.Alliances");
            DropTable("dbo.AllianceMembershipStateInfoes");
            DropTable("dbo.PartnershipStateInfoes");
            DropTable("dbo.Retweets");
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
