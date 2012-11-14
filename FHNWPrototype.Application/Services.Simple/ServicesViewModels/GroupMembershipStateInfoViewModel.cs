using FHNWPrototype.Domain.GroupMemberships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class GroupMembershipStateInfoViewModel
    {
        public GroupMembershipAction Action {get; set;}
        public String RequestorAccountKey { get; set; }
        public String RequestedGroupKey { get; set; }
        public DateTime ActionDateTime { get; set; }
    }
}
