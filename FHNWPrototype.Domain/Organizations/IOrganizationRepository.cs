using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain.AllianceMemberships.States;

namespace FHNWPrototype.Domain.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        //extra methods specifically for this repository
        byte[] GetHeaderPictureByOrganizationKey(Guid key);
    }
}
