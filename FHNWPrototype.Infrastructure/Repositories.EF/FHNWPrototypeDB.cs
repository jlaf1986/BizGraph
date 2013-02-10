using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using FHNWPrototype.Infrastructure.Repositories.EF.TypeConfigurations;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain.Geographics;
using FHNWPrototype.Domain.Projects;
using FHNWPrototype.Domain.Publishing.Tweets;
using FHNWPrototype.Domain.Publishing.Likes;
using FHNWPrototype.Domain.Bookmarks;
using FHNWPrototype.Infrastructure.Security;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Messenger;
using FHNWPrototype.Domain.Notifications;
using FHNWPrototype.Domain.Tags;
 

namespace FHNWPrototype.Infrastructure.Repositories.EF
{
    public class FHNWPrototypeDB : DbContext
    {

        //public FHNWPrototypeDB(string connection) : base(connection) 
        //{
        //  //  this.Configuration.LazyLoadingEnabled = false;
           
        //}

        public FHNWPrototypeDB() :base("name=DefaultConnection")
        {
           // this.Configuration.LazyLoadingEnabled = false;
           // Database.DefaultConnectionFactory.CreateConnection("RemoteConnection");
            Database.SetInitializer(new DBContextInitializerV2());
          

        }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FHNWPrototypeDB, Configuration>());
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); 

            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new UserAccountTypeConfiguration());

            modelBuilder.Configurations.Add(new OrganizationAccountTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationTypeConfiguration());
       

            modelBuilder.Configurations.Add(new FriendshipTypeConfiguration());
            //modelBuilder.Configurations.Add(new FriendshipActionTypeConfiguration());

            modelBuilder.Configurations.Add(new GroupTypeConfiguration());
            modelBuilder.Configurations.Add(new GroupMembershipTypeConfiguration());
            //modelBuilder.Configurations.Add(new GroupMembershipActionTypeConfiguration());

            modelBuilder.Configurations.Add(new AllianceTypeConfiguration());
            //modelBuilder.Configurations.Add(new AllianceMembershipActionTypeConfiguration());

            modelBuilder.Configurations.Add(new PartnershipTypeConfiguration());
            //modelBuilder.Configurations.Add(new PartnershipActionTypeConfiguration());



            modelBuilder.Configurations.Add(new AllianceMembershipTypeConfiguration());
            //modelBuilder.Configurations.Add(new AllianceMembershipActionTypeConfiguration());

            modelBuilder.Configurations.Add(new LibraryTypeConfiguration());
            modelBuilder.Configurations.Add(new DocumentTypeConfiguration());
            modelBuilder.Configurations.Add(new FolderTypeConfiguration());

            modelBuilder.Configurations.Add(new ContentStreamTypeConfiguration());
            modelBuilder.Configurations.Add(new PostTypeConfiguration());
            modelBuilder.Configurations.Add(new CommentTypeConfiguration());

            modelBuilder.Configurations.Add(new GeoLocationTypeConfiguration());

            modelBuilder.Configurations.Add(new ProjectTypeConfiguration());
            modelBuilder.Configurations.Add(new WorkPackageTypeConfiguration());

            modelBuilder.Configurations.Add(new SuscriptionTypeConfiguration());
            modelBuilder.Configurations.Add(new EventTypeConfiguration());
            modelBuilder.Configurations.Add(new NotificationTypeConfiguration());


            //modelBuilder.Entity<Person>().
            //  Property(c => c.Name).
            //  IsRequired().
            //  HasColumnName("Name");  

        }

        //public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<OrganizationAccount> OrganizationAccounts { get; set; }
        public DbSet<Organization> Organizations { get; set; }
      
        public DbSet<FriendshipStateInfo> Friendships { get; set; }
        //public DbSet<FriendshipAction> FriendshipActions { get; set; }

        public DbSet<Group> Groups { get; set; }
        //public DbSet<GroupMembershipAction> GroupMembershipActions { get; set; }
        public DbSet<GroupMembershipStateInfo> GroupMemberships { get; set; }

        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<AllianceMembershipStateInfo> AllianceMemberships { get; set; }
        //public DbSet<AllianceMembershipAction> AllianceMembershipActions { get; set; }

        public DbSet<PartnershipStateInfo> Partnerships { get; set; }
        
        //public DbSet<PartnershipAction> PartnershipActions { get; set; }
        //public DbSet<Workspace> Workspaces { get; set; }

        public DbSet<ContentStream> ContentStreams { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<GeoLocation> Geolocations { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkPackage> WorkPackages { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Retweet> Retweets { get; set; }

        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<SystemAccount> SystemAccounts { get; set; }

       // public DbSet<LoginAccount> LoginAccounts { get; set; }

        public DbSet<BasicProfile> BasicProfiles { get; set; }

        public DbSet<MessengerPost> MessengerPosts { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Suscription> Suscriptions { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
