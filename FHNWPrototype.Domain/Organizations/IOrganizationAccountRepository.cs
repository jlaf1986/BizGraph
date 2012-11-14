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
    public interface IOrganizationAccountRepository : IRepository<OrganizationAccount>
    {
        OrganizationAccount FindByEmail(string email);
        OrganizationAccount FindByEmailSuffix(string email);
        IEnumerable<PartnershipStateInfo> GetAllPartnershipsByOrganizationAccountKey(Guid key);
        IEnumerable<UserAccount> GetAllEmployeesByOrganizationKey(Guid key);
        IEnumerable<AllianceMembershipStateInfo> GetAllAllianceMembershipsByOrganizationKey(Guid key);

        byte[] GetAvatarPictureByOrganizationKey(Guid key);
    }
}
