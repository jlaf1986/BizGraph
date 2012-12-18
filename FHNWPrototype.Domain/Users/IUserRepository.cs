using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.Friendships;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.Users;

namespace FHNWPrototype.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<UserAccount> GetAllAccountsByUserKey(Guid key);
        Byte[] GetProfilePictureByUserKey(Guid key);

    }
}
