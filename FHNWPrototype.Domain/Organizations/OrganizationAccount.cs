using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Geographics;
using FHNWPrototype.Domain.Publishing.ContentStreams;

namespace FHNWPrototype.Domain.Organizations
{
    public class OrganizationAccount : EntityBase, IAggregateRoot, IPublisher
    {

        public OrganizationAccount() 
        { 
        }

        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual String EmailSuffix { get; set; }
        public virtual String Email { get; set; }


        public virtual Organization Organization { get; set; }

        public virtual IList<UserAccount> Employees { get; set; }


        public virtual IList<PartnershipStateInfo> PartnershipsRequested { get; set; }
        public virtual IList<PartnershipStateInfo> PartnershipsReceived { get; set; }

        public virtual IList<AllianceMembershipStateInfo> AllianceMemberships { get; set; }


        public virtual GeoLocation Location { get; set; }

        public virtual ContentStream Wall { get; set; }

        public virtual String Tag { get; set; }

        public virtual byte[] AvatarPicture { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
