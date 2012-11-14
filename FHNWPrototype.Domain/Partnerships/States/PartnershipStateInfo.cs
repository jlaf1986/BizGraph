using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Organizations;

namespace FHNWPrototype.Domain.Partnerships.States
{
    public class PartnershipStateInfo : EntityBase, IAggregateRoot //, IPartnershipStateInfo 
    {

        //private PartnershipAction _action;
        //private Organization _sender;
        //private Organization _receiver;
        //private DateTime _actionDateTime;


        //public PartnershipStateInfo(PartnershipState state)
        //{
        //    this.Action = state.GetAction();
        //    this.Sender = state.GetSender();
        //    this.Receiver = state.GetReceiver();
        //    this.ActionDateTime = state.GetActionDateTime();
        //}

        //public PartnershipStateInfo()
        //{
        //}

        public virtual PartnershipAction Action { get; set; }

        public virtual int? SenderID { get; set; }
        public virtual OrganizationAccount Sender { get; set; }

        public virtual int? ReceiverID { get; set; }
        public virtual OrganizationAccount Receiver { get; set; }

        public virtual DateTime ActionDateTime { get; set; }

        public virtual Boolean IsActive { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        //public PartnershipAction GetAction()
        //{
        //    return this.Action;
        //}

        //public OrganizationAccount GetSender()
        //{
        //    return this.Sender;
        //}

        //public OrganizationAccount GetReceiver()
        //{
        //    return this.Receiver;
        //}

        //public DateTime GetActionDateTime()
        //{
        //    return this.ActionDateTime;
        //}
    }
}
