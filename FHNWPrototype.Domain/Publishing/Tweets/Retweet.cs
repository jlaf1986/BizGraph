using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Publishing.Tweets
{
    public class Retweet : EntityBase, IAggregateRoot
    {
        public virtual UserAccount Retweeter { get; set; }
        public virtual Tweet Tweet { get; set; }
      
        public virtual DateTime DateTime { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
