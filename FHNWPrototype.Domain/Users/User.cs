using System;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain.Users;
using System.Collections.Generic;
using FHNWPrototype.Domain.Geographics;

namespace FHNWPrototype.Domain.Users
{
    public class User : EntityBase, IAggregateRoot
    {

        public User()
        {
            //this.Key = Guid.NewGuid();
        }

        //public User(Guid key, String userName)
        //{
        //    this.Key = key;
        //    this.UserName = userName;
        //}

        //public User(Guid key, String userName, String firstName, String lastName)
        //{
        //    this.Key = key;
        //  /*  this.UserName = userName;*/
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //}


      /*  public virtual String UserName { get; set; }*/

        public virtual GeoLocation GeoLocation { get; set; }

        public virtual String FirstName { get; set; }

        public virtual String LastName { get; set; }

        public virtual Byte[] ProfilePicture { get; set; }

        public virtual IList<UserAccount> UserAccounts { get; set; }

        //public Workspace PersonalWorkspace { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
