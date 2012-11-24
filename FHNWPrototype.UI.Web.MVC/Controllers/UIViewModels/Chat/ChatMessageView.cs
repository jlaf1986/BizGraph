using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Chat
{
    public class ChatMessageView
    {
        public CompleteProfileView Author { get; set; }
        public String Text { get; set; }
        public String TimeStamp { get; set; }
    }
}
