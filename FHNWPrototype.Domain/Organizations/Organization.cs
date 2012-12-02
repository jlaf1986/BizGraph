using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain.Tags;
using FHNWPrototype.Domain.Geographics;
using FHNWPrototype.Domain.Partnerships;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.GroupMemberships;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Publishing.Likes;

namespace FHNWPrototype.Domain.Organizations
{
    public class Organization : EntityBase, IPublisher, IAggregateRoot, ITagCapable  
    {

        public Organization()
        {
            //this.Key = Guid.NewGuid();
        }



        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual String EmailSuffix { get; set; }
        //public virtual UserAccount Administrator { get; set; }

        public virtual IList<OrganizationAccount> OrganizationAccounts { get; set; }


        public virtual byte[] HeaderPicture { get; set; }
        //public virtual byte[] AvatarPicture { get; set; }

        public virtual GeoLocation HeadquatersLocation { get; set; }
        //public virtual ICollection<Group> Groups { get; set; } 
        //public List<Organization> Partners { get; set; }
        public virtual ContentStream Wall { get; set; }

        //public virtual List<OrganizationLike> OrganizationLikes { get; set; }
        //public Division RootDivision { get; set; }
        //public List<Division> SubDivisions { get; set; }
        //public List<Tag> Tags { get; set; }
        //public List<FixedResource> FixedResources { get; set; }
        //public List<MobileResource> MobileResources { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}
