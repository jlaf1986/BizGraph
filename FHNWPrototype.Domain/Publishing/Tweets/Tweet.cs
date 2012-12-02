using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Publishing.Tweets
{
    public class Tweet : EntityBase, IAggregateRoot , IPublishingCapable 
    {
        public virtual BasicProfile Author { get; set; }
       // public virtual Hashtag Hashtag { get; set; }
        public virtual String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
        public virtual ContentStream Wall { get; set; }

        public virtual List<Retweet> Retweets { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
