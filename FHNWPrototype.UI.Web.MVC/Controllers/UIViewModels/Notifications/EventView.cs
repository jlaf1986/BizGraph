using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Notifications
{
    public class EventView
    {
        public EventType Type { get; set; }
        public CompleteProfileView TriggeredBy { get; set; }
        public DateTime TriggeredOn { get; set; }
        public String PostOrComment { get; set; }
    }
}