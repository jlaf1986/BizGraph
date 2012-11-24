using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Groups
{
    public class GroupMembershipsView
    {
        public String GroupName { get; set; }
        public Dictionary<String, String> GroupMembershipStatuses; 
    }
}
