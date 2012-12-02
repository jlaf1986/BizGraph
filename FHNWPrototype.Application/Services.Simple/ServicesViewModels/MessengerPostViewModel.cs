using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    public class MessengerPostViewModel
    {
        public String Key { get; set; }
        //public String ChatRoom { get; set; }
        public String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
        public BasicProfileViewModel Author { get; set; }
    }
}