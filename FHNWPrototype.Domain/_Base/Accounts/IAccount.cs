using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain._Base.Accounts
{
    public interface IAccount
    {
        String GetUsername();
        AccountType GetAccountType();
        String GetEmail();
    }

}
