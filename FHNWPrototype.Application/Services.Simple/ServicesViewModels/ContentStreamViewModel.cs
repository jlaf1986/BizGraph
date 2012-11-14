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
    }
}