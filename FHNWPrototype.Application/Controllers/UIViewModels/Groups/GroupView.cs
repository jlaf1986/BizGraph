using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Groups
{
    public class GroupView
    {
 
        public Boolean IsViewerAllowedToCollaborate { get; set; }
        public CompleteProfileView Profile { get; set; }
        public List<CompleteProfileView> Members { get; set; }
        public List<String> Documents { get; set; }
        public ContentStreamView WallOfThisProfile { get; set; }
    }
}
