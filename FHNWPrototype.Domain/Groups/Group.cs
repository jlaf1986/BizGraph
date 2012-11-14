using System;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Tags;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.GroupMemberships.States;
using System.Collections.Generic;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;

namespace FHNWPrototype.Domain.Groups
{
    public class Group : EntityBase , IPublishingCapable , IAggregateRoot, ITagCapable 
    {

        public Group()
        {
            //this.Key = Guid.NewGuid();
        }

        public Group(Guid key, String name, String description)
        {

            this.Key = key;
            this.Name = name;
            this.Description = description;
            //this.Administrator = administrator;
        }


        public virtual String Name { get; set; }
        public virtual String Description { get; set; }

        public virtual byte[] HeaderPicture { get; set; }
        public virtual byte[] ProfilePicture { get; set; }
        //public virtual UserAccount Administrator { get; set; }
        //public List<Tag> Tags { get; set; }

        public virtual ContentStream Wall { get; set; }

        public virtual IList<GroupMembershipStateInfo> GroupMemberships { get; set; }

        //public virtual List<GroupLike> GroupLikes { get; set; }
       
        //public Workspace GroupWorkspace { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
