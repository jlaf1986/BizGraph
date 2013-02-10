using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Notifications
{
    public class Notification : EntityBase , IAggregateRoot //, IPublishingCapable 
    {
        public Notification()
        {
        }

        public Event Event { get; set; }
        public BasicProfile NotifiedTo { get; set; }

        //public DateTime PublishDateTime { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }


        
    }

}
