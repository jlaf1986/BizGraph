using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.Likes;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Publishing
{
    public class Comment:  EntityBase, Likeable 
    {

        public Comment()
        {
            //this.Key = Guid.NewGuid();
        }

        public virtual String Text { get; set; }

        //public virtual int? AuthorId { get; set; }
        //public virtual UserAccount Author { get; set; }
        public virtual BasicProfile Author { get; set; }
        public virtual DateTime PublishDateTime { get; set; }
        public virtual Post Post { get; set; }

        public virtual IList<CommentLike> CommentLikes { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
