using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.Tweets;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Publishing.ContentStreams
{
    /// <summary>
    /// I wanted to create the holder of the wall as an interface IPublishingCapable
    /// but the following website explains why not <see cref="http://stackoverflow.com/questions/7431756/wrapping-dbsettentity-with-a-custom-dbset-idbset"/>
    /// </summary>
    public class ContentStream : EntityBase , IAggregateRoot
    {
        public virtual List<Post> Posts { get; set; }
        public virtual List<Tweet> Tweets { get; set; }
        public virtual List<Retweet> Retweets { get; set; } 
        public virtual BasicProfile Owner { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
