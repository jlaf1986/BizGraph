using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Publishing.Likes
{
    public class CommentLike : EntityBase, IAggregateRoot
    {
        //public virtual UserAccount Author { get; set; }
        public virtual BasicProfile Author { get; set; }
        public virtual LikeValue Value { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual Comment Comment { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
