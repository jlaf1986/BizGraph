using FHNWPrototype.Domain.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    [Serializable]
    public class ContentStreamViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public List<TweetViewModel> Tweets { get; set; }

        public List<RetweetViewModel> Retweets { get; set; }

        public List<IPublishingCapable> Publications { get; set; }
    }
}