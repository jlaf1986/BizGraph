using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Publishing.Tweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    [Serializable]
    public class RetweetViewModel
    {
        public String RetweetKey { get; set; }
        public CompleteProfileViewModel RetweetAuthor { get; set; }
        //public TweetViewModel Tweet { get; set; }
        public DateTime PublishDateTime { get; set; }

        public String TweetKey { get; set; }
        public CompleteProfileViewModel TweetAuthor { get; set; }
        public String Text { get; set; }
        public DateTime TweetPublishDateTime { get; set; }
    }
}
