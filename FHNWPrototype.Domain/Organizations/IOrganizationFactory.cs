using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FHNWPrototype.Domain.Organizations
{
    public interface IOrganizationFactory
    {
        OrganizationAccount CreateEntity(IDataReader reader);
    }
}
