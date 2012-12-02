using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class NewPostView
    {
        public String PostKey { get; set; }
        //public String AuthorKey { get; set; }
        //public String AuthorName { get; set; }
        public CompleteProfileView Author { get; set; }
        public String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
