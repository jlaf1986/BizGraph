using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Publishing.Files
{
    public class Folder : EntityBase, IAggregateRoot
    {

        public Folder()
        {
            //this.Key = Guid.NewGuid();
        }

        public virtual string Name { get; set; }
        public virtual int? LibraryID { get; set; }
        public virtual Library Library { get; set; }
        public virtual int? ParentFolderID { get; set; }
        public virtual Folder ParentFolder { get; set; }
        public virtual IList<Folder> SubFolders { get; set; }
        public virtual IList<Document> Documents { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
