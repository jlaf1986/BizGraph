using FHNWPrototype.UI.Web.MVC.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class ContentStreamView
    {
        public List<PostView> Posts { get; set; }
        public List<TweetView> Tweets { get; set; }
        public List<RetweetView> Retweets { get; set; }

        public List<ISortingCapable> PublishedItems { get; set; }
    }
}
