using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.Alliances
{
    public class AllianceView
    {

        public CompleteProfileView Profile { get; set; }
        public Boolean IsViewerAllowedToCollaborate { get; set; }
        public List<CompleteProfileView> Members { get; set; }
        public ContentStreamView WallOfThisProfile { get; set; }
    }
}
