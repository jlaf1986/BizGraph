using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Messenger
{

    public class MessengerView
    {
        public CompleteProfileView Profile { get; set; }
        public string ChatRoom { get; set; }
        public List<CompleteProfileView> Users { get; set; }
        public List<MessengerPostView> Posts { get; set; }
    }

}