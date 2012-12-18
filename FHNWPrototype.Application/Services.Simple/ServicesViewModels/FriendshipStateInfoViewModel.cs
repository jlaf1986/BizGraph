using FHNWPrototype.Domain.Friendships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class FriendshipStateInfoViewModel
    {
        public CompleteProfileViewModel Sender { get; set; }
        public CompleteProfileViewModel Receiver { get; set; }
        //public String SenderEmail { get; set; }
        //public String ReceiverEmail { get; set; }
        public DateTime ActionDateTime { get; set; }
        public FriendshipAction FriendshipAction { get; set; }
    }

}
