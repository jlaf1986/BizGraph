using System;
using System.Collections.Generic;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Tags;

namespace FHNWPrototype.Domain.Projects
{
    public class WorkPackage : EntityBase, IAggregateRoot, ITagCapable 
    {
        public virtual String WbsCorrelationToken { get; set; }
        public virtual String Title { get; set; }
        public virtual String Description { get; set; }

        //public virtual int? OwnerId { get; set; }
        public virtual UserAccount Owner { get; set; }

        public virtual int? ParentWorkPackageID { get; set;}
        public virtual WorkPackage ParentWorkPackage { get; set; }


        public virtual List<WorkPackage> ChildWorkPackages { get; set; }
        //public virtual IList<UserAccount> Participants { get; set; }

        //public virtual DateTime DateTime { get; set; }
        //public virtual TimeSpan TimeSpan { get; set; }

        //public virtual int? LibraryId { get; set; }
        //public virtual Library Library { get; set; }

        public virtual String Comments { get; set; }
        //public virtual Boolean HasStarted { get; set; }
        //public virtual Boolean HasCompleted { get; set; }
        public virtual Boolean IsMilestone { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
