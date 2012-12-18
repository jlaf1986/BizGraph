using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Tags;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Publishing.Files
{
    public class Document : EntityBase, IAggregateRoot, ITagCapable, IAttachmentCapable
    {

        public Document()
        {
        }
        public virtual String Name { get; set; }
        public virtual Object Content { get; set; }
        public virtual DateTime PublishDateTime { get; set; }

        //public virtual int? AuthorId { get; set; }
        public virtual UserAccount Author { get; set; }
        //public virtual IList<Tag> Tags { get; set; }
        public virtual Folder ParentFolder { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
