using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    [Serializable]
    public class CommentViewModel
    {
        public String Key { get; set; }
        //public String AuthorKey { get; set; }
        //public String AuthorName { get; set; }
        public CompleteProfileViewModel Author { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public Int32 Likes { get; set; }
        public Boolean ILikedIt { get; set; }
    }
}