using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.UI.Web.MVC.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class RetweetView: ISortingCapable
    {
        public String RetweetKey { get; set; }
        public CompleteProfileView RetweetAuthor { get; set; }
        //public TweetViewModel Tweet { get; set; }
        public DateTime PublishDateTime { get; set; }

        public String TweetKey { get; set; }
        public CompleteProfileView TweetAuthor { get; set; }
        public String Text { get; set; }
        public String TweetPublishDateTime { get; set; }

        public Boolean AllowedToDeleteRetweet { get; set; }
    }
}