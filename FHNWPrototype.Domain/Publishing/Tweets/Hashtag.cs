using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Groups;

namespace FHNWPrototype.Domain.Publishing.Tweets
{
    public class Hashtag : EntityBase, IAggregateRoot 
    {
        public virtual String Symbol { get; set; }

        //it could also be for other things like alliances, organizations, groups  
        //but only belongs to one context
        public virtual Alliance AllianceContext { get; set; }
        public virtual OrganizationAccount OrganizationContext { get; set; }
        public virtual Group GroupContext { get; set; }      

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
