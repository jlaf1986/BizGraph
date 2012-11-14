using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.DTOs
{
    public class UserAccountDTO
    {
        public Guid Key { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Description { get; set; }
        public UserDTO User { get; set; }
        public OrganizationAccountDTO OrganizationAccount { get; set; }
    }
}
