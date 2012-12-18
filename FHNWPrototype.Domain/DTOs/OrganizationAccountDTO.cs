using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.DTOs
{
    public class OrganizationAccountDTO
    {
        public Guid Key { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Email { get; set; }
        public OrganizationDTO Organization { get; set; }
    }
}
