using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Application.Controllers.UIViewModels.UserAccounts
{
    public class UserAccountView
    {
      //  public String UserAccountKeyOfThisProfile { get; set; }
      //  public String UserKeyOfThisProfile { get; set; }
        public CompleteProfileView Profile { get; set; }
        public String EmailOfThisProfile { get; set; }

        //Properties related with viewer of the account
        public Boolean IsThisMyOwnProfile { get; set; }
        public Boolean IsThisProfileAFriendOfMine { get; set; }
        public Boolean isWaitingForFriendshipResponse { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsOrganization { get; set; }
        public Boolean isEmployeeOfThisViewerAsOrganization { get; set; }
        public Boolean isPotentiallyRelatedWithThisViewerAsUser { get; set; }

        public RightColumnView MyProfileRightColumnData { get; set; }


        public Boolean ShowFriendshipButtonForThisProfile { get; set; }
        public Boolean EnableFriendshipButtonForThisProfile { get; set; }
        public String FriendshipButtonCaptionForThisProfile { get; set; }
        public String FriendshipButtonActionNameForThisProfile { get; set; }
        public String FriendshipButtonControllerNameForThisProfile { get; set; }

       // public KeyValuePair<String,String> OrganizationAccountOfThisProfile { get; set; }
        public CompleteProfileView OrganizationAccountOfThisProfile { get; set; }
        public List<CompleteProfileView> WorkContactsOfThisProfile { get; set; }
        public List<CompleteProfileView> PartnershipContactsOfThisProfile { get; set; } // partnership,contact
        public List<CompleteProfileView> GroupsOfThisProfile { get; set; }
        public Dictionary<String, String> FoldersOfThisProfile { get; set; }
        public ContentStreamView WallOfThisProfile { get; set; }
        public Boolean IsThisProfileStillActive { get; set; }

        //public IEnumerable<Access> AccessHistory { get; set; }
        //public Guid AutheticationToken { get; set; }
    }
}
