using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class AllianceMembershipStateInfoViewModel
    {
        public AllianceMembershipAction Action { get; set;}

        public String RequestorOrganizationAccountKey { get; set; }

        public String RequestedAllianceKey { get; set;}

        public DateTime ActionDateTime {get; set;}
    }
}
