using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.GroupMemberships.States
{
    public class GroupMembershipStateInfo : EntityBase, IAggregateRoot, IGroupMembershipStateInfo 
    {

        private GroupMembershipAction _action;
        private UserAccount  _requestorAccount;
        private Group _requestedGroup;
        private DateTime _actionDateTime;

        public GroupMembershipStateInfo()
        {
        }

        public GroupMembershipStateInfo(GroupMembershipState state)
        {
            _action = state.GetAction();
            _requestorAccount = state.GetRequestor();
            _requestedGroup = state.GetRequestedGroup();
            _actionDateTime = state.GetActionDateTime();
        }


        public virtual int? RequestorAccountID { get; set; }
        public virtual UserAccount RequestorAccount { get; set; }

        public virtual int? RequestedGroupID { get; set; }
        public virtual Group RequestedGroup { get; set; }

        public virtual GroupMembershipAction GroupMembershipAction { get; set; }


           public GroupMembershipAction GetAction()
           {
               return _action;
           }

           public UserAccount GetRequestor()
           {
               return _requestorAccount;
           }

        

           public Group GetRequestedGroup()
           {
               return _requestedGroup;
           }


           public DateTime GetActionDateTime()
           {
               return _actionDateTime;
           }


           protected override void Validate()
           {
               throw new NotImplementedException();
           }
    }
}
