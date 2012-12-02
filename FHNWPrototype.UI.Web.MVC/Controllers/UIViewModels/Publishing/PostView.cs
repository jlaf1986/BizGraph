using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.UI.Web.MVC.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class PostView : ISortingCapable
    {
        public String Key { get; set; }
        //public String AuthorKey { get; set; }
        //public String AuthorName { get; set; }
        //public Boolean IsCorporateAccount { get; set; }
        public CompleteProfileView Viewer { get; set; }
        public CompleteProfileView Author { get; set; }
        public Boolean ILikedIt { get; set; }
        public String Text { get; set; }
        public Int32 Likes { get; set; }
        public DateTime PublishDateTime { get; set; }
        public List<CommentView> Comments { get; set; }
        public Boolean AllowedToDeletePost { get; set; }
    }
}
