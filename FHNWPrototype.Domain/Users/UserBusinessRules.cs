using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain.Users
{
    public class UserBusinessRules
    {
        public static readonly BusinessRule FirstNameRequired = new BusinessRule("FirstName", "A customer must have a first name.");
        public static readonly BusinessRule LastNameRequired = new BusinessRule("LastName", "A customer must have a last name.");
        public static readonly BusinessRule EmailRequired = new BusinessRule("Email", "A customer must have a valid email address.");
        public static readonly BusinessRule IdentityTokenRequired = new BusinessRule("IdentityToken", "A customer must have an identity token.");
    }
}
