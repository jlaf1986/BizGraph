using System;
using System.Collections.Generic;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.GroupMemberships;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.AllianceMemberships.States;

namespace FHNWPrototype.Domain.Alliances
{
    public class Alliance : EntityBase, IAggregateRoot
    {
        public Alliance()
        {
        }

        //public Alliance(Guid key, String name, Organization coordinator)
        //{
        //    this.Key = key;
        //    this.Name = name;
        //    this.Coordinator = coordinator;
        //}

        public virtual String Name { get; set; }
        public virtual String Description { get; set; }

        //public virtual int? OrganizationId { get; set; }
        public virtual OrganizationAccount Coordinator { get; set; }


        public virtual byte[] HeaderPicture { get; set; }
        public virtual byte[] ProfilePicture { get; set; }

        public virtual IList<AllianceMembershipStateInfo> AllianceMemberships { get; set; }
        //public List<Membership> Memberships { get; set; }
        public virtual ContentStream Wall { get; set; }
        //public Library Library { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
