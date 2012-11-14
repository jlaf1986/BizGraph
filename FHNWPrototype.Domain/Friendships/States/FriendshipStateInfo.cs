using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Friendships.States
{
    public class FriendshipStateInfo : EntityBase, IAggregateRoot //, IFriendshipStateInfo 
    {

        //private FriendshipAction _action;
        //private UserAccount _sender;
        //private UserAccount _receiver;
        //private DateTime _actionDateTime;
        //public FriendshipStateInfo()
        //{
        //    // this.Key = Guid.NewGuid();
        //}

        //public FriendshipStateInfo(FriendshipState state)
        //{
        //    this.Key = Guid.NewGuid();
        //    this.Action = state.GetAction();
        //    this.Sender = state.GetSender();
        //    this.Receiver = state.GetReceiver();
        //    this.ActionDateTime = state.GetActionDateTime();
        //}

    

        public virtual FriendshipAction Action { get; set; }

        public virtual int? SenderID { get; set; }
        public virtual UserAccount Sender { get; set; }


        public virtual int? ReceiverID { get; set; }
        public virtual UserAccount Receiver { get; set; }

        public virtual DateTime ActionDateTime { get; set; }


        public virtual Boolean IsActive { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        //public FriendshipAction GetAction()
        //{
        //    return this.Action;
        //}

        //public UserAccount GetSender()
        //{
        //    return this.Sender;
        //}

        //public UserAccount GetReceiver()
        //{
        //    return this.Receiver;
        //}

        //public DateTime GetActionDateTime()
        //{
        //    return this.ActionDateTime;
        //}
    }
}
