using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Tags
{
    public class Tag : EntityBase, IAggregateRoot
    {


        //public Tag()
        //{
        //    //this.Key = Guid.NewGuid();
        //}

        //public Tag(Guid key, String name)
        //{
        //    this.Key = key;
        //    this.Name = name;
        //}

        //public Tag(String name)
        //{
        //    this.Key = Guid.NewGuid();
        //    this.Name = name;
        //}

        public String Name { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
