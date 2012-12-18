using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Publishing.Likes
{
    /// <summary>
    /// At first I thought it could be a good idea to have a single class that holds 
    /// all of the likes in the world, but apparently I can't make DBSet to work 
    /// against interfaces, so I'll make a LIKE for each Likeable object
    /// </summary>
    public class Like : EntityBase, IAggregateRoot
    {
        public virtual UserAccount Author { get; set; }
        public virtual LikeValue Value { get; set; }
        public virtual Likeable Holder { get; set; }
        public virtual LikeType HolderType { get; set; }
        public virtual Guid HolderReference { get; set; }
        public virtual DateTime DateTime { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
