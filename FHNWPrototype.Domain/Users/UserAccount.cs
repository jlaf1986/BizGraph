using System;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Organizations;
using System.Collections.Generic;
using FHNWPrototype.Domain.Friendships;
using FHNWPrototype.Domain.GroupMemberships;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.GroupMemberships.States;
using System.Xml.Serialization;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Geographics;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain.Bookmarks;


namespace FHNWPrototype.Domain.Users
{
    /// <summary>
    /// Explanation of the multiple many-to-many relationships within 2 tables
    /// <see cref="http://stackoverflow.com/questions/9081256/entity-framework-code-first-union-of-the-two-fields-into-one-collection"/>
    /// <seealso cref="http://stackoverflow.com/questions/710856/how-do-you-send-complex-objects-using-wcf-does-it-work-is-it-good"/>
    /// </summary>


    public class UserAccount : EntityBase, IAggregateRoot, IPublisher
    {

        public UserAccount()
        {
            //this.Key = Guid.NewGuid();
        }

        //public UserAccount(Guid key, String email, User user)
        //{
        //    this.Key = key;
        //    this.Email = email;
        //    this.User=user;
        //}

   

        //public UserAccount(Guid key, String email, User user, Organization organization)
        //{
        //    this.Key = key;
        //    this.Email = email;
        //    this.User = user;
        //    this.Organization = organization;
        //}
  
        public virtual String Email { get; set; }

        //public virtual int? UserId { get; set; }
        
        public virtual User User { get; set; }

        //public virtual int? OrganizationId { get; set; }


        
        public virtual OrganizationAccount OrganizationAccount { get; set; }        
         
        public virtual IList<FriendshipStateInfo> FriendshipsRequested { get; set; }
         
        public virtual IList<FriendshipStateInfo> FriendshipsReceived { get; set; }
         
        public virtual IList<GroupMembershipStateInfo> GroupMemberships { get; set; }

        public virtual ContentStream Wall { get; set; }

        public virtual Library DocumentLibrary { get; set; }

        public virtual List<Bookmark> Bookmarks { get; set; } 

        //public Workspace Workspace { get; set; }
        //public List<Workspace> PartnershipWorkspaces { get; set; }

        //public virtual Boolean IsConfirmed { get; set; }
      
        //public virtual Boolean IsActive { get; set; }
        //  public List<Access> AccessHistory { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
