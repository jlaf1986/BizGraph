using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Bookmarks
{
    public class Bookmark : EntityBase, IAggregateRoot 
    {
        public virtual UserAccount Owner { get; set; }
        public virtual BookmarkType Type { get; set; }
        public virtual Guid Reference { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

}
