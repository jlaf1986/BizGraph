using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.Files;

namespace FHNWPrototype.Domain.Publishing.Likes
{
    public class DocumentLike : EntityBase, IAggregateRoot
    {

        public virtual UserAccount Author { get; set; }
        public virtual LikeValue Value { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual Document Document { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
