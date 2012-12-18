using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Friendships.States
{
    public enum FriendshipAction
    {
       // Null=0,
        New = 0,
        Request = 1,
        Accept = 2,
        Reject = 3,
        Cancel = 4
    }

    //public class FriendshipAction : EntityBase, IAggregateRoot
    //{

    //    public virtual String Name { get; set; }

    //    protected override void Validate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
