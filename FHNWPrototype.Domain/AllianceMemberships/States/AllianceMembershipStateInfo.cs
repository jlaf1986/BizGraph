using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Alliances;

namespace FHNWPrototype.Domain.AllianceMemberships.States
{
    public class AllianceMembershipStateInfo : EntityBase, IAggregateRoot, IAllianceMembershipStateInfo 
    {

        private AllianceMembershipAction _action;
        private OrganizationAccount _requestorOrganization;
        private Alliance _requestedAlliance;
        private DateTime _actionDateTime;

        public AllianceMembershipStateInfo()
        {
        }

        public AllianceMembershipStateInfo(AllianceMembershipState state)
        {
            _action = state.GetAction();
            _requestorOrganization = state.GetRequestorOrganization();
            _requestedAlliance = state.GetRequestedAlliance();
            _actionDateTime = state.GetActionDateTime();
        }


        public virtual int? AllianceRequestedID { get; set; }
        public virtual Alliance AllianceRequested { get; set; }

        public virtual AllianceMembershipAction AllianceMembershipAction { get; set; }

        public virtual int? OrganizationRequestorID { get; set; }
        public virtual OrganizationAccount OrganizationRequestor { get; set; }

        public AllianceMembershipAction GetAction()
        {
            return _action;
        }

        public OrganizationAccount GetRequestorOrganization()
        {
            return _requestorOrganization;
        }

        public DateTime GetActionDateTime()
        {
            return _actionDateTime;
        }

        public Alliance GetRequestedAlliance()
        {
            return _requestedAlliance;
        }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
