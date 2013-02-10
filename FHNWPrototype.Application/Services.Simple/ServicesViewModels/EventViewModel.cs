using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class EventViewModel
    {
        public EventType Type { get; set; }
        public BasicProfileViewModel TriggeredBy { get; set; }
        public DateTime TriggeredOn { get; set; }
        public String PostOrComment { get; set; }
    }
}
