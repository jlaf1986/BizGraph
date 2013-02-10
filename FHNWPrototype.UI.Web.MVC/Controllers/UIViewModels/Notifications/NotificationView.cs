using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Notifications
{
    public class NotificationView
    {
        public CompleteProfileView NotifiedTo { get; set; }
        public EventView Event { get; set; }
    }
}