using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Publishing.ContentStreams;

namespace FHNWPrototype.Domain.Publishing.Tweets
{
    public class Retweet : EntityBase, IAggregateRoot, IPublishingCapable 
    {
        public virtual BasicProfile Author { get; set; }
        public virtual Tweet Tweet { get; set; }
        public virtual ContentStream Wall { get; set; }
        public DateTime PublishDateTime { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
         
    }
}
