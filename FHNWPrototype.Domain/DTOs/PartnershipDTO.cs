using FHNWPrototype.Domain.Partnerships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.DTOs
{
    public class PartnershipStateInfoDTO
    {
        public PartnershipAction Action { get; set; }

 
        public OrganizationAccountDTO Sender { get; set; }

 
        public OrganizationAccountDTO Receiver { get; set; }

        public DateTime ActionDateTime { get; set; }
    }
}
