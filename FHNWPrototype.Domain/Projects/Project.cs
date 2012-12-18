using System;
using System.Collections.Generic;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Tags;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Projects
{
    public class Project : EntityBase, IAggregateRoot , ITagCapable 
    {

        public Project()
        {
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        //public virtual int? CoordinatorID { get; set; }
        public virtual OrganizationAccount Coordinator { get; set; }
        //public virtual IList<User> Members { get; set; } //Members
        //public virtual int? WorkBreakdownStructureID { get; set; }
        public virtual WorkPackage WorkBreakdownStructure { get; set; } //WorkBreakdownStructure
        //public virtual List<Group> Groups { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
