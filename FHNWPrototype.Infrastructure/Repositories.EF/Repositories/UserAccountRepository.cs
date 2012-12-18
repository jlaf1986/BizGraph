using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Users;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.Friendships.States;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.DTOs;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{




    /// <summary>
    /// Check the reference that explains Lazy/Eager Loading in EF 5
    /// <see cref="http://stackoverflow.com/questions/5521749/how-many-include-i-can-use-on-objectset-in-entityframework-to-retain-performance"/>
    /// <seealso cref="http://msdn.microsoft.com/en-us/magazine/hh205756.aspx"/>
    /// </summary>
    public static class UserAccountRepository //: IUserAccountRepository
    {

        //private FHNWPrototypeDB db = null;

        //public UserAccountRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}

        public static void Save(UserAccount entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                UserAccount foundAccount = db.UserAccounts.FirstOrDefault(account => account.Key == entity.Key);
                //foundAccount.IsConfirmed = entity.IsConfirmed;
                db.SaveChanges();
            }
        }

        public static void Add(UserAccount entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.UserAccounts.Add(entity);
            }
        }

        public static void Remove(UserAccount entity)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.UserAccounts.Remove(entity);
            }
        }

        public static List<CompleteProfile> GetWorkContactsOfUserAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();

            using (var db = new FHNWPrototypeDB())
            {
                
                var dbResult = db.UserAccounts
                                    .Single(x => x.Key == key);

                foreach (FriendshipStateInfo friendship in dbResult.FriendshipsReceived)
                {

                    if ((friendship.Sender.OrganizationAccount.Key == dbResult.OrganizationAccount.Key) && friendship.IsActive == true && (friendship.Action == FriendshipAction.Accept))
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = friendship.Sender.Key, ReferenceType = AccountType.UserAccount }, FullName = friendship.Sender.User.FirstName + " " + friendship.Sender.User.LastName });
                      
                    }

                }
                foreach (FriendshipStateInfo friendship in dbResult.FriendshipsRequested)
                {
                    if ((friendship.Receiver.OrganizationAccount.Key == dbResult.OrganizationAccount.Key) && friendship.IsActive == true && (friendship.Action == FriendshipAction.Accept))
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = friendship.Receiver.Key, ReferenceType = AccountType.UserAccount }, FullName = friendship.Receiver.User.FirstName + " " + friendship.Receiver.User.LastName });
                    }
                }
                return result;
            }
         

        }

        public static List<CompleteProfile> GetPartnershipContactsOfUserAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();

            using (var db = new FHNWPrototypeDB())
            {
                var dbResult = db.UserAccounts
                                            .Single(x => x.Key == key);

                foreach (FriendshipStateInfo friendship in dbResult.FriendshipsReceived)
                {

                    if ((friendship.Sender.OrganizationAccount.Key != dbResult.OrganizationAccount.Key) && (friendship.IsActive==true) && (friendship.Action == FriendshipAction.Accept ))
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = friendship.Sender.Key, ReferenceType = AccountType.UserAccount }, FullName = friendship.Sender.User.FirstName + " " + friendship.Sender.User.LastName });
                    }

                }
                foreach (FriendshipStateInfo friendship in dbResult.FriendshipsRequested)
                {
                    if ((friendship.Receiver.OrganizationAccount.Key != dbResult.OrganizationAccount.Key) && (friendship.IsActive == true) && (friendship.Action == FriendshipAction.Accept))
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = friendship.Receiver.Key, ReferenceType = AccountType.UserAccount }, FullName = friendship.Receiver.User.FirstName + " " + friendship.Receiver.User.LastName });
                    }
                }
                return result;
            }
        

        }

        public static List<CompleteProfile> GetGroupsOfUserAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();
            using (var db = new FHNWPrototypeDB())
            {
                var dbResult = db.UserAccounts
                                            .Include("GroupMemberships.RequestedGroup")
                                            .Include("User")
                                            .FirstOrDefault(x => x.Key == key);
                foreach (GroupMembershipStateInfo membership in dbResult.GroupMemberships)
                {

                    result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = membership.RequestedGroup.Key, ReferenceType = AccountType.Group  }, FullName = membership.RequestedGroup.Name  });

                }
                return result;
            }
         
        }

        public static UserAccount FindBy(Guid key)
        {
            UserAccount accountFound = new UserAccount();
            //ContentStream contentStreamFound = null;
           
            using (var db = new FHNWPrototypeDB())
            {
     
                //UserAccount foundAccount = db.Accounts.FirstOrDefault(account => account.Key==key && account.IsActive);
                 var result = (from account in db.UserAccounts
                                                        .Include("User")
                                                        .Include("OrganizationAccount.Organization")
                                                        //.Include("FriendshipsRequested.Sender.User")
                                                        //.Include("FriendshipsRequested.Sender.OrganizationAccount.Organization")
                                                        //.Include("FriendshipsRequested.Receiver.User")
                                                        //.Include("FriendshipsRequested.Receiver.OrganizationAccount.Organization")
                                                        //.Include("FriendshipsReceived.Sender.User")
                                                        //.Include("FriendshipsReceived.Sender.OrganizationAccount.Organization")
                                                        //.Include("FriendshipsReceived.Receiver.User")
                                                        //.Include("FriendshipsReceived.Receiver.OrganizationAccount.Organization")
                                                        //.Include("GroupMemberships.RequestedGroup")
                                                        //.Include("Wall.Posts.Author")
                                                        //.Include("Wall.Posts.Comments.Author")
                                                        //.Include("Wall.Posts.PostLikes.Author")
                                                        //.Include("Wall.Posts.Comments.CommentLikes.Author")
                                            where account.Key == key
                                            select account).FirstOrDefault();


                //if (accountFound != null)
                //{
                //    contentStreamFound = (from cs in db.ContentStreams
                //                         .Include("Posts.Author")
                //                                    .Include("Posts.Comments.Author")
                //                                    .Include("Posts.PostLikes")
                //                                    .Include("Posts.Comments.CommentLikes")
                //                                        where cs.Owner.ReferenceKey  == accountFound.Key
                //                                        select cs).FirstOrDefault();
                //    if (contentStreamFound != null)
                //    {
                //        accountFound.Wall = contentStreamFound;
                //    }
                //    else
                //    {
                //        ContentStream emptyWall = new ContentStream();
                //        emptyWall.Posts = new List<Post>();
                //        accountFound.Wall = emptyWall;
                //    }
                //}
                //else
                //{
                //    return null;
                //}
                 accountFound.Key = result.Key;
                 accountFound.Email = result.Email;
               
                 accountFound.User = result.User;
                 accountFound.OrganizationAccount = result.OrganizationAccount;
                 accountFound.GroupMemberships = new List<GroupMembershipStateInfo>();
                 accountFound.FriendshipsReceived = new List<FriendshipStateInfo>();
                 accountFound.FriendshipsRequested = new List<FriendshipStateInfo>();
                 accountFound.Wall = new ContentStream();
                 accountFound.Wall.Posts = new List<Post>();
                return accountFound;    
            }
            
        }

        //public static UserAccount FindByEmail(string email)
        //{
        //     UserAccount accountFound = null;
        //     ContentStream contentStreamFound = null;
        //     using (var db = new FHNWPrototypeDB())
        //     {
               
        //         //UserAccount foundAccount = db.Accounts.FirstOrDefault(account => account.Key==key && account.IsActive);
        //         accountFound = (from account in db.UserAccounts
        //                                                .Include("User")
        //                                                .Include("OrganizationAccount.Organization")
        //                                                .Include("FriendshipsRequested.Sender.User")
        //                                                .Include("FriendshipsRequested.Sender.OrganizationAccount.Organization")
        //                                                .Include("FriendshipsRequested.Receiver.User")
        //                                                .Include("FriendshipsRequested.Receiver.OrganizationAccount.Organization")
        //                                                .Include("FriendshipsReceived.Sender.User")
        //                                                .Include("FriendshipsReceived.Sender.OrganizationAccount.Organization")
        //                                                .Include("FriendshipsReceived.Receiver.User")
        //                                                .Include("FriendshipsReceived.Receiver.OrganizationAccount.Organization")
        //                                                .Include("GroupMemberships.RequestedGroup")
        //                                                .Include("Wall.Posts.Author")
        //                                                .Include("Wall.Posts.Comments.Author")
        //                                                .Include("Wall.Posts.PostLikes.Author")
        //                                                .Include("Wall.Posts.Comments.CommentLikes.Author")
        //                         where account.Email == email
        //                         select account).FirstOrDefault();


        //         if (accountFound != null)
        //         {
        //             contentStreamFound = (from cs in db.ContentStreams
        //                                            .Include("Posts.Author")
        //                                            .Include("Posts.Comments.Author")
        //                                            .Include("Posts.PostLikes")
        //                                            .Include("Posts.Comments.CommentLikes")
        //                                   where cs.Owner.ReferenceKey == accountFound.Key
        //                                   select cs).FirstOrDefault();
        //             if (contentStreamFound != null)
        //             {
        //                 accountFound.Wall = contentStreamFound;
        //             }
        //             else
        //             {
        //                 ContentStream emptyWall = new ContentStream();
        //                 emptyWall.Posts = new List<Post>();
        //                 accountFound.Wall = emptyWall;
        //             }
        //         }
        //         else
        //         {
        //             return null;
        //         }

        //         return accountFound;
        //     }
        //}

        public static Byte[] GetProfilePictureByAccountKey(Guid key)
        {

            Byte[] foundPicture = null;
            using (var db = new FHNWPrototypeDB())
            {
                var result = from account in db.UserAccounts
                                            .Include("User")
                             where account.Key == key
                             select account.User.ProfilePicture;

                foundPicture = result.FirstOrDefault();

                return foundPicture;
            }
        }

        public static Byte[] GetHeaderPictureByUserAccountKey(Guid key)
        {

            Byte[] foundPicture = null;
            using (var db = new FHNWPrototypeDB())
            {
                var result = from account in db.UserAccounts
                             where account.Key == key
                             select account.OrganizationAccount.Organization.HeaderPicture;
                foundPicture = result.FirstOrDefault();

                return foundPicture;
            }
        }

        public static  IEnumerable<UserAccount> FindAll()
        {
            IEnumerable<UserAccount> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from account in db.UserAccounts
                                                        .Include("FriendshipsRequested.Sender.OrganizationAccount")
                                                        .Include("FriendshipsRequested.Receiver.User")
                                                        .Include("FriendshipsRequested.Receiver.OrganizationAccount")
                                                        .Include("FriendshipsReceived.Sender.User")
                                                        .Include("FriendshipsReceived.Sender.OrganizationAccount")
                                                        .Include("FriendshipsReceived.Receiver.User")
                                                        .Include("FriendshipsReceived.Receiver.OrganizationAccount")
                         select account;

                return result;
            }
        }

        public static IEnumerable<UserAccount> FindBy(Query query)
        {
            
            throw new NotImplementedException();
        }

        public static IEnumerable<UserAccount> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }


        public static IEnumerable<FriendshipStateInfoDTO> GetAllFriendshipsByAccountKey(Guid key)
        {
             
            using (var db = new FHNWPrototypeDB())
            {
                IEnumerable<FriendshipStateInfoDTO> result = (from r in db.Friendships
                                        .Include("Sender.User")
                                        .Include("Receiver.User")
                                        .Include("Sender.OrganizationAccount.Organization")
                                        .Include("Receiver.OrganizationAccount.Organization")
                                                           where ((r.Receiver.Key == key || r.Sender.Key == key) && (r.Action != FriendshipAction.Cancel && r.Action != FriendshipAction.Reject && r.IsActive==true))
                                                           orderby r.ActionDateTime descending 
                                                           select new FriendshipStateInfoDTO
                                                           {
                                                               Receiver = new UserAccountDTO
                                                               {
                                                                   Key = r.Receiver.Key,
                                                                   Email = r.Receiver.Email,
                                                                   User = new UserDTO { FirstName = r.Receiver.User.FirstName, LastName = r.Receiver.User.LastName },
                                                                   OrganizationAccount = new  OrganizationAccountDTO
                                                                      {
                                                                          Name = r.Receiver.OrganizationAccount.Name,
                                                                          Email=r.Receiver.OrganizationAccount.Email,
                                                                          Description = r.Receiver.OrganizationAccount.Description,
                                                                          Organization = new  OrganizationDTO { Name = r.Receiver.OrganizationAccount.Organization.Name, Description = r.Receiver.OrganizationAccount.Organization.Description }

                                                                      }
                                                               },
                                                               Sender = new UserAccountDTO
                                                               {
                                                                   Key = r.Sender.Key,
                                                                   Email = r.Sender.Email,
                                                                   User = new UserDTO { FirstName = r.Sender.User.FirstName, LastName = r.Sender.User.LastName },
                                                                   OrganizationAccount = new  OrganizationAccountDTO
                                                                   {
                                                                       Name = r.Sender.OrganizationAccount.Name,
                                                                       Email = r.Sender.OrganizationAccount.Email,
                                                                       Description = r.Sender.OrganizationAccount.Description,
                                                                       Organization = new OrganizationDTO { Name = r.Sender.OrganizationAccount.Organization.Name, Description = r.Sender.OrganizationAccount.Organization.Description }

                                                                   }
                                                               },
                                                               Action = r.Action,
                                                               ActionDateTime = r.ActionDateTime

                                                           });


               // foreach (FriendshipStateInfoDTO friendship in result)
               //{
               //    ContentStream emptyWall = new ContentStream();
               //    emptyWall.Posts = new List<Post>();
               //    friendship.Sender.Wall = emptyWall;
               //    friendship.Receiver.Wall = emptyWall;
               //}

               return result.ToList();
            }
        }




        public static IEnumerable<GroupMembershipStateInfo> GetAllGroupMembershipsByAccountKey(Guid key)
        {
            IEnumerable<GroupMembershipStateInfo> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from gm in db.GroupMemberships
                                            .Include("GroupRequested")
                                            .Include("AccountRequestor.User")
                         where gm.RequestorAccount.Key == key
                         select gm;

                return result.ToList();
            }
        }

        public static FriendshipStateInfo GetFriendshipBetweenUserAccounts(Guid userAccountKey1, Guid userAccountKey2)
        {
            FriendshipStateInfo result = null;
            using (var db = new FHNWPrototypeDB())
            {
               result = (from friendships in db.Friendships
                                                .Include("Sender.User")
                                                .Include("Sender.OrganizationAccount.Organization")
                                                .Include("Receiver.User")
                                                .Include("Receiver.OrganizationAccount.Organization")
                         where (((friendships.Sender.Key == userAccountKey1 && friendships.Receiver.Key == userAccountKey2) ||
                                                 (friendships.Sender.Key == userAccountKey2 && friendships.Receiver.Key == userAccountKey1)) &&
                                                 (friendships.IsActive == true))
                         orderby friendships.ActionDateTime descending
                          select friendships)
                                        .FirstOrDefault();

             //  FriendshipStateInfo completeResult = new FriendshipStateInfo { Key=result.Key, Action=result.Action, ActionDateTime=result.ActionDateTime, IsActive=result.IsActive, Receiver=result.Receiver, Sender=result.Sender };

               return result;
            }
        }

        public static Boolean isPotentiallyRelatedWithThisViewerAsOrganization(string organizationAccountEmail)
        {
            return true;
        }

        public static Boolean isPotentiallyRelatedWithThisViewerAsUser(string userAccountEmail)
        {
            return true;
        }




        public static bool UpdateFriendshipStatus(Guid senderUserAccountKey, Guid receiverUserAccountKey, DateTime actionDateTime, FriendshipAction action)
        {

            FriendshipStateInfo lastFriendshipStateInfo = GetFriendshipBetweenUserAccounts(senderUserAccountKey, receiverUserAccountKey);
         
          
             

            if (lastFriendshipStateInfo != null)
            {
                var friendshipState = FriendshipStateFactory.GetFriendshipStateBasedOnInfo(lastFriendshipStateInfo);
                switch (action)
                {
                   
                    case FriendshipAction.Accept:
                        if (friendshipState.CanAcceptFriendshipRequestFrom(senderUserAccountKey, receiverUserAccountKey))
                        {
                            using (var db = new FHNWPrototypeDB())
                            {


                               var lastState = (from friendships in db.Friendships
                                               .Include("Sender.User")
                                               .Include("Sender.OrganizationAccount.Organization")
                                               .Include("Receiver.User")
                                               .Include("Receiver.OrganizationAccount.Organization")
                                                where (((friendships.Sender.Key == senderUserAccountKey && friendships.Receiver.Key == receiverUserAccountKey) ||
                                                  (friendships.Sender.Key == receiverUserAccountKey && friendships.Receiver.Key == senderUserAccountKey)) &&
                                                  (friendships.IsActive==true))
                                          orderby friendships.ActionDateTime descending
                                          select friendships)
                                       .FirstOrDefault();

                               lastState.IsActive = false;


                              UserAccount   sender = db.UserAccounts
                                      .Include("FriendshipsRequested")
                                      .Include("FriendshipsReceived")
                                      .FirstOrDefault(x => x.Key == senderUserAccountKey);
                             UserAccount    receiver = db.UserAccounts
                                                        .Include("FriendshipsRequested")
                                                        .Include("FriendshipsReceived")
                                    .FirstOrDefault(x => x.Key == receiverUserAccountKey);
                               
                                FriendshipStateInfo newFriendshipState = new FriendshipStateInfo();
                                newFriendshipState.Key = Guid.NewGuid();
                                newFriendshipState.Action = FriendshipAction.Accept;
                                newFriendshipState.ActionDateTime = actionDateTime;
                                newFriendshipState.Receiver = receiver;
                                newFriendshipState.Sender = sender;
                                newFriendshipState.IsActive = true;
                                db.Friendships.Add(newFriendshipState);

                               // sender.FriendshipsRequested.Add(newFriendshipState);
                               // receiver.FriendshipsReceived.Add(newFriendshipState);

                                db.SaveChanges();
                                return true;
                            }
                            //friendshipState.AcceptFriendshipRequestFrom(senderUserAccountKey, receiverUserAccountKey);
                        }
                        else
                        {
                            return false;
                        }
                        
                    case FriendshipAction.Cancel:
                        if (friendshipState.CanCancelFriendshipWith(senderUserAccountKey, receiverUserAccountKey))
                        {
                            using (var db = new FHNWPrototypeDB())
                            {


                                var lastState = (from friendships in db.Friendships
                      .Include("Sender.User")
                      .Include("Sender.OrganizationAccount.Organization")
                      .Include("Receiver.User")
                      .Include("Receiver.OrganizationAccount.Organization")
                                                 where (((friendships.Sender.Key == senderUserAccountKey && friendships.Receiver.Key == receiverUserAccountKey) ||
                                                   (friendships.Sender.Key == receiverUserAccountKey && friendships.Receiver.Key == senderUserAccountKey)) &&
                                                   (friendships.IsActive == true))
                                                 orderby friendships.ActionDateTime descending
                                                 select friendships)
              .FirstOrDefault();

                                lastState.IsActive = false;


                                UserAccount sender = db.UserAccounts
                                .Include("FriendshipsRequested")
                                .Include("FriendshipsReceived")
                                .SingleOrDefault(x => x.Key == senderUserAccountKey);
                                UserAccount receiver = db.UserAccounts
                                                           .Include("FriendshipsRequested")
                                                           .Include("FriendshipsReceived")
                                       .SingleOrDefault(x => x.Key == receiverUserAccountKey);

                                FriendshipStateInfo newFriendshipState = new FriendshipStateInfo();
                                newFriendshipState.Key = Guid.NewGuid();
                                newFriendshipState.Action = FriendshipAction.Cancel ;
                                newFriendshipState.ActionDateTime = actionDateTime;
                                newFriendshipState.Receiver = receiver;
                                newFriendshipState.Sender = sender;
                                newFriendshipState.IsActive = true;

                                db.Friendships.Add(newFriendshipState);

                              //  sender.FriendshipsRequested.Add(newFriendshipState);
                               // receiver.FriendshipsReceived.Add(newFriendshipState);

                                db.SaveChanges();
                                return true;
                            }
                           // friendshipState.CancelFriendshipWith(senderUserAccountKey, receiverUserAccountKey);
                        }
                        else
                        {
                            return false;
                        }
                    
                    case FriendshipAction.Reject:
                        if (friendshipState.CanRejectFriendshipRequestFrom(senderUserAccountKey, receiverUserAccountKey))
                        {
                            using (var db = new FHNWPrototypeDB())
                            {

                                var lastState = (from friendships in db.Friendships
                    .Include("Sender.User")
                    .Include("Sender.OrganizationAccount.Organization")
                    .Include("Receiver.User")
                    .Include("Receiver.OrganizationAccount.Organization")
                                                 where (((friendships.Sender.Key == senderUserAccountKey && friendships.Receiver.Key == receiverUserAccountKey) ||
                                                   (friendships.Sender.Key == receiverUserAccountKey && friendships.Receiver.Key == senderUserAccountKey)) &&
                                                   (friendships.IsActive == true))
                                                 orderby friendships.ActionDateTime descending
                                                 select friendships)
            .FirstOrDefault();

                                lastState.IsActive = false;


                                UserAccount sender = db.UserAccounts
                                .Include("FriendshipsRequested")
                                .Include("FriendshipsReceived")
                                .FirstOrDefault(x => x.Key == senderUserAccountKey);
                                UserAccount receiver = db.UserAccounts
                                                           .Include("FriendshipsRequested")
                                                           .Include("FriendshipsReceived")
                                       .SingleOrDefault(x => x.Key == receiverUserAccountKey);

                                FriendshipStateInfo newFriendshipState = new FriendshipStateInfo();
                                newFriendshipState.Key = Guid.NewGuid();
                                newFriendshipState.Action = FriendshipAction.Reject;
                                newFriendshipState.ActionDateTime = actionDateTime;
                                newFriendshipState.Receiver = receiver;
                                newFriendshipState.Sender = sender;
                                newFriendshipState.IsActive = true;

                                db.Friendships.Add(newFriendshipState);

                              //  sender.FriendshipsRequested.Add(newFriendshipState);
                              //  receiver.FriendshipsReceived.Add(newFriendshipState);

                                db.SaveChanges();
                                return true;
                            }
                            //friendshipState.RejectFriendshipRequestFrom(senderUserAccountKey, receiverUserAccountKey);
                        }
                        else
                        {
                            return false;
                        }
                        
                    case FriendshipAction.Request:
                        if (friendshipState.CanRequestFriendshipTo(senderUserAccountKey, receiverUserAccountKey))
                        {
                            using (var db = new FHNWPrototypeDB())
                            {

                                var lastState = (from friendships in db.Friendships
                     .Include("Sender.User")
                     .Include("Sender.OrganizationAccount.Organization")
                     .Include("Receiver.User")
                     .Include("Receiver.OrganizationAccount.Organization")
                                                 where (((friendships.Sender.Key == senderUserAccountKey && friendships.Receiver.Key == receiverUserAccountKey) ||
                                                   (friendships.Sender.Key == receiverUserAccountKey && friendships.Receiver.Key == senderUserAccountKey)) &&
                                                   (friendships.IsActive == true))
                                                 orderby friendships.ActionDateTime descending
                                                 select friendships)
                                                .FirstOrDefault();

                                lastState.IsActive = false;


                                UserAccount sender = db.UserAccounts
                                .Include("FriendshipsRequested")
                                .Include("FriendshipsReceived")
                                .FirstOrDefault(x => x.Key == senderUserAccountKey);
                                UserAccount receiver = db.UserAccounts
                                                           .Include("FriendshipsRequested")
                                                           .Include("FriendshipsReceived")
                                       .FirstOrDefault(x => x.Key == receiverUserAccountKey);

                                FriendshipStateInfo newFriendshipState = new FriendshipStateInfo();
                                newFriendshipState.Key = Guid.NewGuid();
                                newFriendshipState.Action = FriendshipAction.Request;
                                newFriendshipState.ActionDateTime = actionDateTime;
                                newFriendshipState.Receiver = receiver;
                                newFriendshipState.Sender = sender;
                                newFriendshipState.IsActive = true;

                                db.Friendships.Add(newFriendshipState);

                              //  sender.FriendshipsRequested.Add(newFriendshipState);
                              //  receiver.FriendshipsReceived.Add(newFriendshipState);

                                db.SaveChanges();
                                return true;
                            }
                           // friendshipState.RequestFriendshipTo(senderUserAccountKey, receiverUserAccountKey);
                        }
                        else
                        {
                            return false;
                        }
                        //break;
                }

                return false;
            }
            else
            {
                if (action == FriendshipAction.Request)
                {
                    using (var db = new FHNWPrototypeDB())
                    {

                        var lastState = (from friendships in db.Friendships
                                                              .Include("Sender.User")
                                                              .Include("Sender.OrganizationAccount.Organization")
                                                              .Include("Receiver.User")
                                                              .Include("Receiver.OrganizationAccount.Organization")
                                         where (((friendships.Sender.Key == senderUserAccountKey && friendships.Receiver.Key == receiverUserAccountKey) ||
                                           (friendships.Sender.Key == receiverUserAccountKey && friendships.Receiver.Key == senderUserAccountKey)) &&
                                           (friendships.IsActive == true))
                                         orderby friendships.ActionDateTime descending
                                         select friendships)
                                        .FirstOrDefault();

                        lastState.IsActive = false;


                        UserAccount sender = db.UserAccounts
                                .Include("FriendshipsRequested")
                                .Include("FriendshipsReceived")
                                .FirstOrDefault(x => x.Key == senderUserAccountKey);
                        UserAccount receiver = db.UserAccounts
                                                   .Include("FriendshipsRequested")
                                                   .Include("FriendshipsReceived")
                               .SingleOrDefault(x => x.Key == receiverUserAccountKey);

                        FriendshipStateInfo newFriendshipState = new FriendshipStateInfo();
                        newFriendshipState.Key = Guid.NewGuid();
                        newFriendshipState.Action = FriendshipAction.Request;
                        newFriendshipState.ActionDateTime = actionDateTime;
                        newFriendshipState.Receiver = receiver ;
                        newFriendshipState.Sender = sender  ;
                        newFriendshipState.IsActive = true;

                        db.Friendships.Add(newFriendshipState);
                        
                      //  sender.FriendshipsRequested.Add(newFriendshipState);
                      //  receiver.FriendshipsReceived.Add(newFriendshipState);

                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            
        }
    }


}
