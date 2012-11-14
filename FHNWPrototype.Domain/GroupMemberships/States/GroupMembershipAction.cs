using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public enum GroupMembershipAction
    {
        New = 0,
        Offer = 1,
        Allow = 2,
        Request = 3,
        Accept = 4,
        Reject = 5,
        Cancel = 6
    }

    //public class GroupMembershipAction : EntityBase, IAggregateRoot
    //{

    //    public virtual String Name { get; set; }

    //    protected override void Validate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
