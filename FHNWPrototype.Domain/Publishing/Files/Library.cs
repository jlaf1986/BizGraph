using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Publishing.Files
{
    public class Library : EntityBase, IAggregateRoot
    {

        public Library()
        {

        }
        public UserAccount Owner { get; set; }
        //public virtual String Name { get; set; }

       // public virtual int? RootFolderId { get; set; }
        public virtual List<Folder> Folders { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
