﻿using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Publishing
{
    public class PostView
    {
        public String Key { get; set; }
        //public String AuthorKey { get; set; }
        //public String AuthorName { get; set; }
        //public Boolean IsCorporateAccount { get; set; }
        public CompleteProfileView Author { get; set; }
        public Boolean ILikedIt { get; set; }
        public String Text { get; set; }
        public Int32 Likes { get; set; }
        public String TimeStamp { get; set; }
        public List<CommentView> Comments { get; set; }
        public Boolean AllowedToDeletePost { get; set; }
    }
}
