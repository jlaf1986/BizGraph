using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Messenger
{
    public class MessengerPostView
    {
        public String Key { get; set; }
        public CompleteProfileView Author { get; set; }
        public String Text { get; set; }
        public DateTime  PublishDateTime { get; set; }
    }
}