using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple.ServicesViewModels
{
    [Serializable]
    public class TweetViewModel
    {
        public String Key { get; set; }
        public CompleteProfileViewModel Author { get; set; }
        public String Text { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Int32 Retweets { get; set; }
    }
}
