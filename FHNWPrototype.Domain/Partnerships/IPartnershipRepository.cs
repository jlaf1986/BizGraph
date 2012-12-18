using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;
using FHNWPrototype.Domain.Partnerships.States;

namespace FHNWPrototype.Domain.Partnerships
{
    public interface IPartnershipRepository : IRepository<PartnershipStateInfo>
    {

        IEnumerable<PartnershipStateInfo> GetAllPartnerships();

    }
}
