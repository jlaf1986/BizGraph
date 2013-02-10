using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class NotificationViewModel
    {
        public BasicProfileViewModel NotifiedTo { get; set; }
        public EventViewModel Event { get; set; }
    
    }
}
