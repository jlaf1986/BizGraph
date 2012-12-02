using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.UI.Web.MVC.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class TweetView: ISortingCapable
    {
        public String Key { get; set; }
        public CompleteProfileView Viewer { get; set; }
        public CompleteProfileView Author { get; set; }
        public String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Boolean AllowedToDeleteTweet { get; set; }
    }
}