using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Publishing.Files;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;
using FHNWPrototype.Domain._Base.Accounts;

namespace FHNWPrototype.Domain.Publishing
{
    /// <summary>
    /// to scan a url and provide a preview in the post <see cref="http://nsoup.codeplex.com/"/>
    /// </summary>
    public class Post : EntityBase , IAggregateRoot, Likeable , IPublishingCapable 
    {

        public Post()
        {
            //this.Key = Guid.NewGuid();
        }

        public virtual String Text { get; set; }

        //public virtual int? AttachmentId { get; set; }
        //public IAttachmentCapable Attachment { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public DateTime PublishDateTime { get; set; }
        
        //public virtual int? AuthorId { get; set; }
        //public virtual UserAccount Author { get; set; }
        public virtual BasicProfile Author { get; set; }

        public virtual ContentStream Wall { get; set; }

        public virtual IList<PostLike> PostLikes { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
