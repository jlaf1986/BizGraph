using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public enum PartnershipAction
    {
        New = 0,
        Request = 1,
        Accept = 2,
        Reject = 3,
        Cancel = 4
    }

    //public class PartnershipAction : EntityBase, IAggregateRoot
    //{

    //    public virtual String Name { get; set; }

    //    protected override void Validate()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
