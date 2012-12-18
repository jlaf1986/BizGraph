using FHNWPrototype.Domain.Partnerships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class PartnershipStateInfoViewModel
    {
        public PartnershipAction PartnershipAction { get; set; }
        public CompleteProfileViewModel Sender { get; set; }
        public CompleteProfileViewModel Receiver { get; set; }
        public DateTime ActionDateTime { get; set; }
    }
}
