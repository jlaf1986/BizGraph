using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Publishing.ContentStreams;

namespace FHNWPrototype.Domain.Publishing.Tweets
{
    public class Tweet : EntityBase, IAggregateRoot 
    {
        public virtual int? AuthorID { get; set; }
        public virtual UserAccount Author { get; set; }
        public virtual Hashtag Hashtag { get; set; }
        public virtual String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
        public ContentStream Wall { get; set; }

        public virtual List<Retweet> Retweets { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
