using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Organizations;
using FHNWPrototype.Domain.Partnerships.States;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.DTOs;
using FHNWPrototype.Domain.Users;


namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class OrganizationAccountRepository //: IOrganizationAccountRepository
    {

       // private FHNWPrototypeDB db = null;

        //public OrganizationAccountRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //   // db = new FHNWPrototypeDB();
        //}


        public static  IEnumerable<PartnershipStateInfoDTO> GetAllPartnershipsByOrganizationAccountKey(Guid key)
        {
            IEnumerable<PartnershipStateInfoDTO> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from p in db.Partnerships
                                        .Include("Receiver.Organization")
                                        .Include("Sender.Organization")
                         where p.Receiver.Key == key || p.Sender.Key == key
                         select new PartnershipStateInfoDTO
                         {
                      
                             Receiver = new OrganizationAccountDTO
                             {
                                 Key = p.Receiver.Key,
                                 Name = p.Receiver.Name,
                                 Description = p.Receiver.Description,
                                 Organization = new OrganizationDTO { Name = p.Receiver.Organization.Name, Description = p.Receiver.Organization.Description }
                             },
                             Sender = new OrganizationAccountDTO
                             {
                                 Key = p.Sender.Key,
                                 Name = p.Sender.Name,
                                 Description = p.Sender.Description,
                                 Organization = new OrganizationDTO { Name=p.Sender.Organization.Name, Description=p.Sender.Organization.Description  }
                             },
                             Action=p.Action,
                             ActionDateTime=p.ActionDateTime 
                         };





                //foreach (PartnershipStateInfo partnership in result)
                //{
                //    ContentStream emptyWall = new ContentStream();
                //    emptyWall.Posts = new List<Post>();
                //    partnership.Sender.Wall = emptyWall;
                //    partnership.Receiver.Wall = emptyWall;
                //}

                return result.ToList();
            }
        }
        public static IEnumerable<UserAccount> GetAllEmployeesByOrganizationKey(Guid key)
        {
            IEnumerable<UserAccount> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = (from organizationAccount in db.OrganizationAccounts
                          where organizationAccount.Key == key
                          select organizationAccount.Employees).FirstOrDefault();

                return result.ToList();
            }
        }
        public static IEnumerable<AllianceMembershipStateInfo> GetAllAllianceMembershipsByOrganizationKey(Guid key)
        {
            IEnumerable<AllianceMembershipStateInfo> result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = from p in db.AllianceMemberships
                                            .Include("AllianceRequested")
                                            .Include("OrganizationRequestor")
                         where p.OrganizationRequestor.Key == key
                         select p;

                return result;
            }
        }

        public static byte[] GetAvatarPictureByOrganizationKey(Guid key)
        {
            byte[] result = null;
            using (var db = new FHNWPrototypeDB())
            {
                result = (from organizationAccount in db.OrganizationAccounts
                          where organizationAccount.Key == key
                          select organizationAccount.AvatarPicture).FirstOrDefault();


                return result;
            }
        }

        public static void Save(OrganizationAccount entity)
        {
            throw new NotImplementedException();
        }

        public static void Add(OrganizationAccount entity)
        {
            throw new NotImplementedException();
        }

        public static void Remove(OrganizationAccount entity)
        {
            throw new NotImplementedException();
        }

        public static OrganizationAccount FindBy(Guid key)
        {
            OrganizationAccount organizationAccountFound = new OrganizationAccount();
          //  ContentStream contentStreamFound = null;
            using (var db = new FHNWPrototypeDB())
            {
               var result = (from organizationAccount in db.OrganizationAccounts
                                                 .Include("Organization")
                                                 //.Include("PartnershipsRequested.Sender.Organization")
                                                 //.Include("PartnershipsRequested.Receiver.Organization")
                                                 //.Include("PartnershipsReceived.Sender.Organization")
                                                 //.Include("PartnershipsReceived.Receiver.Organization")
                                                 //.Include("AllianceMemberships.AllianceRequested")
                                                 //.Include("Employees.OrganizationAccount.Organization")
                                                 //.Include("Employees.User")
                                                 //.Include("Location")
                                                 //.Include("Wall.Posts.Author")
                                                 //.Include("Wall.Posts.Comments.Author")
                                            where organizationAccount.Key == key
                                            select organizationAccount).FirstOrDefault();

                //contentStreamFound = (from cs in db.ContentStreams
                //                               .Include("Posts.Author")
                //                                .Include("Posts.Comments.Author")
                //                      where cs.Owner.ReferenceKey == organizationAccountFound.Key
                //                      select cs).FirstOrDefault();

                //if (organizationAccountFound != null)
                //{
                //    if (contentStreamFound != null)
                //    {
                //        organizationAccountFound.Wall = contentStreamFound;
                //    }
                //    else
                //    {
                //        ContentStream emptyWall = new ContentStream();
                //        emptyWall.Posts = new List<Post>();
                //        organizationAccountFound.Wall = emptyWall;
                //    }
                //}
                //else
                //{
                //    return null;
                //}
                organizationAccountFound.Key = result.Key;
                organizationAccountFound.Name = result.Name;
                organizationAccountFound.Organization = result.Organization;
                organizationAccountFound.Description = result.Description;
                organizationAccountFound.Location = result.Location;
                organizationAccountFound.PartnershipsReceived = new List<PartnershipStateInfo>();
                organizationAccountFound.PartnershipsRequested = new List<PartnershipStateInfo>();
                organizationAccountFound.AllianceMemberships = new List<AllianceMembershipStateInfo>();
                organizationAccountFound.Wall = new ContentStream();
                organizationAccountFound.Wall.Posts = new List<Post>();
                return organizationAccountFound;
            }
        }

        //public static OrganizationAccount FindByEmailSuffix(string emailSuffix)
        //{
        //    OrganizationAccount organizationAccountFound = null;
        //    ContentStream contentStreamFound = null;
        //    using (var db = new FHNWPrototypeDB())
        //    {
        //        organizationAccountFound = (from organizationAccount in db.OrganizationAccounts
        //                                        .Include("Organization")
        //                                        .Include("PartnershipsRequested.Sender.Organization")
        //                                        .Include("PartnershipsRequested.Receiver.Organization")
        //                                        .Include("PartnershipsReceived.Sender.Organization")
        //                                        .Include("PartnershipsReceived.Receiver.Organization")
        //                                        .Include("AllianceMemberships.AllianceRequested")
        //                                        .Include("Employees.Organization")
        //                                        .Include("Location")
        //                                        .Include("Wall.Posts.Author")
        //                                        .Include("Wall.Posts.Comments.Author")
        //                                    where organizationAccount.EmailSuffix == emailSuffix
        //                                    select organizationAccount).FirstOrDefault();

        //        contentStreamFound = (from cs in db.ContentStreams
        //                                        .Include("Posts.Author")
        //                                        .Include("Posts.Comments.Author")
        //                              where cs.Owner.ReferenceKey == organizationAccountFound.Key
        //                              select cs).FirstOrDefault();

        //        if (organizationAccountFound != null)
        //        {
        //            if (contentStreamFound != null)
        //            {
        //                organizationAccountFound.Wall = contentStreamFound;
        //            }
        //            else
        //            {
        //                ContentStream emptyWall = new ContentStream();
        //                emptyWall.Posts = new List<Post>();
        //                organizationAccountFound.Wall = emptyWall;
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //        return organizationAccountFound;
        //    }
        //}
        //public static OrganizationAccount FindByEmail(string email)
        //{
        //    OrganizationAccount organizationAccountFound = null;
        //    ContentStream contentStreamFound = null;
        //    using (var db = new FHNWPrototypeDB())
        //    {
        //        organizationAccountFound = (from organizationAccount in db.OrganizationAccounts
        //                                       .Include("Organization")
        //                                       .Include("PartnershipsRequested.Sender.Organization")
        //                                       .Include("PartnershipsRequested.Receiver.Organization")
        //                                       .Include("PartnershipsReceived.Sender.Organization")
        //                                       .Include("PartnershipsReceived.Receiver.Organization")
        //                                       .Include("AllianceMemberships.AllianceRequested")
        //                                       .Include("Location")
        //                                       .Include("Employees.OrganizationAccount.Organization")
        //                                        .Include("Employees.User")
        //                                       .Include("Wall.Posts.Author")
        //                                       .Include("Wall.Posts.Comments.Author")
        //                                    where organizationAccount.Email == email
        //                                    select organizationAccount).FirstOrDefault();

        //        contentStreamFound = (from cs in db.ContentStreams
        //                                        .Include("Posts.Author")
        //                                        .Include("Posts.Comments.Author")
        //                              where cs.Owner.ReferenceKey == organizationAccountFound.Key
        //                              select cs).FirstOrDefault();

        //        if (organizationAccountFound != null)
        //        {
        //            if (contentStreamFound != null)
        //            {
        //                organizationAccountFound.Wall = contentStreamFound;
        //            }
        //            else
        //            {
        //                ContentStream emptyWall = new ContentStream();
        //                emptyWall.Posts = new List<Post>();
        //                organizationAccountFound.Wall = emptyWall;
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
               
        //        return organizationAccountFound;
        //    }
        //}

        public static OrganizationAccount GetOrganizationAccountByOrganizationAccountKey(Guid userAccountKey)
        {
           // OrganizationAccount userAccountFound = null;
            OrganizationAccount organizationAccountFound = null;
            //ContentStream contentStreamFound = null;
            using (var db = new FHNWPrototypeDB())
            {
                //userAccountFound = (from userAccount in db.OrganizationAccounts
                //                                        .Include("Organization")
                //                                        .Include("OrganizationAccount.Organization")
                //                                        .Include("OrganizationAccount.PartnershipsRequested.Sender")
                //                                        .Include("OrganizationAccount.PartnershipsRequested.Receiver")
                //                                        .Include("OrganizationAccount.PartnershipsReceived.Sender")
                //                                        .Include("OrganizationAccount.PartnershipsReceived.Receiver")
                //                                        .Include("OrganizationAccount.AllianceMemberships.AllianceRequested")
                //                                        .Include("PartnershipsRequested.Sender.Organization")
                //                                        .Include("PartnershipsRequested.Receiver.Organization")
                //                                        .Include("PartnershipsReceived.Sender.Organization")
                //                                        .Include("PartnershipsReceived.Receiver.Organization")
                //                                        .Include("GroupMemberships.RequestedGroup")
                //                                        .Include("Wall.Posts.Author.Organization")
                //                                        .Include("Wall.Posts.Comments.Author.Organization")
                //                                where userAccount.Key == userAccountKey
                //                                select userAccount).FirstOrDefault();

                var result = db.UserAccounts 
                                                   // .Include("Organization")
                                                    .Include("OrganizationAccount.Organization")
                                                    //.Include("OrganizationAccount.PartnershipsRequested.Sender")
                                                    //.Include("OrganizationAccount.PartnershipsRequested.Receiver")
                                                    //.Include("OrganizationAccount.PartnershipsReceived.Sender")
                                                    //.Include("OrganizationAccount.PartnershipsReceived.Receiver")
                                                    //.Include("OrganizationAccount.AllianceMemberships.AllianceRequested")
                                                    //.Include("OrganizationAccount.Location")
                                                    //.Include("OrganizationAccount.Employees.Organization")
                                                    //.Include("PartnershipsRequested.Sender.Organization")
                                                    //.Include("PartnershipsRequested.Receiver.Organization")
                                                    //.Include("PartnershipsReceived.Sender.Organization")
                                                    //.Include("PartnershipsReceived.Receiver.Organization")
                                                    //.Include("GroupMemberships.RequestedGroup")
                    .Single(x => x.Key == userAccountKey).OrganizationAccount;

                //contentStreamFound = (from cs in db.ContentStreams
                //                               .Include("Posts.Author")
                //                                 .Include("Posts.Comments.Author")
                //                      where cs.Owner.ReferenceKey == organizationAccountFound.Key
                //                      select cs).FirstOrDefault();

                //if (organizationAccountFound != null)
                //{
                //    if (contentStreamFound != null)
                //    {
                //        organizationAccountFound.Wall = contentStreamFound;
                //    }
                //    else
                //    {
                //        ContentStream emptyWall = new ContentStream();
                //        emptyWall.Posts = new List<Post>();
                //        organizationAccountFound.Wall = emptyWall;
                //    }
                //}
                //else
                //{
                //    return null;
                //}
                organizationAccountFound.Key = result.Key;
                organizationAccountFound.Name = result.Name;
                organizationAccountFound.Organization = result.Organization;
                organizationAccountFound.Description = result.Description;
                organizationAccountFound.Location = result.Location;
                organizationAccountFound.PartnershipsReceived = new List<PartnershipStateInfo>();
                organizationAccountFound.PartnershipsRequested = new List<PartnershipStateInfo>();
                organizationAccountFound.AllianceMemberships = new List<AllianceMembershipStateInfo>();
                organizationAccountFound.Wall = new ContentStream();
                organizationAccountFound.Wall.Posts = new List<Post>();

                return organizationAccountFound;
            }
        }

        public static PartnershipStateInfo GetPartnershipBetweenOrganizationAccounts(Guid  organizationAccountKey1, Guid  organizationAccountKey2)
        {
            PartnershipStateInfo result = null;
            using (var db = new FHNWPrototypeDB())
            {
               result = (from partnerships in db.Partnerships 
                                                .Include("Sender.Organization")
                                                .Include("Receiver.Organization")
                         where (((partnerships.Sender.Key == organizationAccountKey1 && partnerships.Receiver.Key == organizationAccountKey2) ||
                                                 (partnerships.Sender.Key == organizationAccountKey2 && partnerships.Receiver.Key == organizationAccountKey1)) &&
                                                 (partnerships.IsActive == true))
                         orderby partnerships.ActionDateTime descending
                          select partnerships)
                                        .FirstOrDefault();

             //  FriendshipStateInfo completeResult = new FriendshipStateInfo { Key=result.Key, Action=result.Action, ActionDateTime=result.ActionDateTime, IsActive=result.IsActive, Receiver=result.Receiver, Sender=result.Sender };

               return result;
            }
        }

        public static bool UpdatePartnershipStatus(Guid senderOrganizationAccountKey, Guid receiverOrganizationAccountKey, DateTime actionDateTime, PartnershipAction action)
        {
            //OrganizationAccount sender = null;
            //OrganizationAccount receiver = null;
            //PartnershipStateInfo newPartnershipState = null;

            //using (var db = new FHNWPrototypeDB())
            //{
            //     sender = db.OrganizationAccounts.Single(x => x.Key == senderOrganizationAccountKey);
            //    sender.Wall = new ContentStream();
            //    sender.Wall.Posts = new List<Post>();
            //     receiver = db.OrganizationAccounts.Single(x => x.Key == receiverOrganizationAccountKey);
            //    receiver.Wall = new ContentStream();
            //    receiver.Wall.Posts = new List<Post>();

            //     newPartnershipState = new PartnershipStateInfo();
            //    newPartnershipState.Key = Guid.NewGuid();
            //    newPartnershipState.Action = action;
            //    newPartnershipState.ActionDateTime = actionDateTime;
            //    newPartnershipState.Receiver = sender;
            //    newPartnershipState.Sender = receiver;

            //    sender.PartnershipsRequested.Add(newPartnershipState);
            //    receiver.PartnershipsReceived.Add(newPartnershipState);

            //    db.SaveChanges();
            //}

              PartnershipStateInfo lastPartnershipStateInfo = GetPartnershipBetweenOrganizationAccounts(senderOrganizationAccountKey, receiverOrganizationAccountKey);




              if (lastPartnershipStateInfo != null)
              {
                  var partnershipState = PartnershipStateFactory.GetPartnershipStateBasedOnInfo(lastPartnershipStateInfo);
                  switch (action)
                  {

                      case PartnershipAction.Accept:
                          if (partnershipState.CanAcceptPartnershipRequestFrom(senderOrganizationAccountKey, receiverOrganizationAccountKey))
                          {
                              using (var db = new FHNWPrototypeDB())
                              {


                                  var lastState = (from partnerships in db.Partnerships
                                                                   .Include("Sender.Organization")
                                                                   .Include("Receiver.Organization")
                                                   where (((partnerships.Sender.Key == senderOrganizationAccountKey && partnerships.Receiver.Key == receiverOrganizationAccountKey) ||
                                                     (partnerships.Sender.Key == receiverOrganizationAccountKey && partnerships.Receiver.Key == senderOrganizationAccountKey)) &&
                                                     (partnerships.IsActive == true))
                                                   orderby partnerships.ActionDateTime descending
                                                   select partnerships)
                                          .FirstOrDefault();

                                  lastState.IsActive = false;


                                  OrganizationAccount sender = db.OrganizationAccounts
                                          .Include("PartnershipsRequested")
                                          .Include("PartnershipsReceived")
                                          .SingleOrDefault(x => x.Key == senderOrganizationAccountKey);
                                  OrganizationAccount receiver = db.OrganizationAccounts
                                                             .Include("PartnershipsRequested")
                                                             .Include("PartnershipsReceived")
                                         .SingleOrDefault(x => x.Key == receiverOrganizationAccountKey);

                                  PartnershipStateInfo newPartnershipState = new PartnershipStateInfo();
                                  newPartnershipState.Key = Guid.NewGuid();
                                  newPartnershipState.Action = PartnershipAction.Accept;
                                  newPartnershipState.ActionDateTime = actionDateTime;
                                  newPartnershipState.Receiver = receiver;
                                  newPartnershipState.Sender = sender;
                                  newPartnershipState.IsActive = true;
                                  db.Partnerships.Add(newPartnershipState);

                                  // sender.PartnershipsRequested.Add(newPartnershipState);
                                  // receiver.PartnershipsReceived.Add(newPartnershipState);

                                  db.SaveChanges();
                                  return true;
                              }
                              //friendshipState.AcceptPartnershipRequestFrom(senderOrganizationAccountKey, receiverOrganizationAccountKey);
                          }
                          else
                          {
                              return false;
                          }

                      case PartnershipAction.Cancel:
                          if (partnershipState.CanCancelPartnershipWith(senderOrganizationAccountKey, receiverOrganizationAccountKey))
                          {
                              using (var db = new FHNWPrototypeDB())
                              {


                                  var lastState = (from partnerships in db.Partnerships
                        .Include("Sender.Organization")
                         .Include("Receiver.Organization")

                                                   where (((partnerships.Sender.Key == senderOrganizationAccountKey && partnerships.Receiver.Key == receiverOrganizationAccountKey) ||
                                                     (partnerships.Sender.Key == receiverOrganizationAccountKey && partnerships.Receiver.Key == senderOrganizationAccountKey)) &&
                                                     (partnerships.IsActive == true))
                                                   orderby partnerships.ActionDateTime descending
                                                   select partnerships)
                .FirstOrDefault();

                                  lastState.IsActive = false;


                                  OrganizationAccount sender = db.OrganizationAccounts
                                  .Include("PartnershipsRequested")
                                  .Include("PartnershipsReceived")
                                  .SingleOrDefault(x => x.Key == senderOrganizationAccountKey);
                                  OrganizationAccount receiver = db.OrganizationAccounts
                                                             .Include("PartnershipsRequested")
                                                             .Include("PartnershipsReceived")
                                         .SingleOrDefault(x => x.Key == receiverOrganizationAccountKey);

                                  PartnershipStateInfo newPartnershipState = new PartnershipStateInfo();
                                  newPartnershipState.Key = Guid.NewGuid();
                                  newPartnershipState.Action = PartnershipAction.Cancel;
                                  newPartnershipState.ActionDateTime = actionDateTime;
                                  newPartnershipState.Receiver = receiver;
                                  newPartnershipState.Sender = sender;
                                  newPartnershipState.IsActive = true;

                                  db.Partnerships.Add(newPartnershipState);

                                  //  sender.PartnershipsRequested.Add(newPartnershipState);
                                  // receiver.PartnershipsReceived.Add(newPartnershipState);

                                  db.SaveChanges();
                                  return true;
                              }
                              // friendshipState.CancelPartnershipWith(senderOrganizationAccountKey, receiverOrganizationAccountKey);
                          }
                          else
                          {
                              return false;
                          }

                      case PartnershipAction.Reject:
                          if (partnershipState.CanRejectPartnershipRequestFrom(senderOrganizationAccountKey, receiverOrganizationAccountKey))
                          {
                              using (var db = new FHNWPrototypeDB())
                              {

                                  var lastState = (from partnerships in db.Partnerships
                      .Include("Sender.Organization")
                     .Include("Receiver.Organization")
                                                   where (((partnerships.Sender.Key == senderOrganizationAccountKey && partnerships.Receiver.Key == receiverOrganizationAccountKey) ||
                                                                                      (partnerships.Sender.Key == receiverOrganizationAccountKey && partnerships.Receiver.Key == senderOrganizationAccountKey)) &&
                                                                                      (partnerships.IsActive == true))
                                                   orderby partnerships.ActionDateTime descending
                                                   select partnerships)
              .FirstOrDefault();

                                  lastState.IsActive = false;


                                  OrganizationAccount sender = db.OrganizationAccounts
                                  .Include("PartnershipsRequested")
                                  .Include("PartnershipsReceived")
                                  .SingleOrDefault(x => x.Key == senderOrganizationAccountKey);
                                  OrganizationAccount receiver = db.OrganizationAccounts
                                                             .Include("PartnershipsRequested")
                                                             .Include("PartnershipsReceived")
                                         .SingleOrDefault(x => x.Key == receiverOrganizationAccountKey);

                                  PartnershipStateInfo newPartnershipState = new PartnershipStateInfo();
                                  newPartnershipState.Key = Guid.NewGuid();
                                  newPartnershipState.Action = PartnershipAction.Reject;
                                  newPartnershipState.ActionDateTime = actionDateTime;
                                  newPartnershipState.Receiver = receiver;
                                  newPartnershipState.Sender = sender;
                                  newPartnershipState.IsActive = true;

                                  db.Partnerships.Add(newPartnershipState);

                                  //  sender.PartnershipsRequested.Add(newPartnershipState);
                                  //  receiver.PartnershipsReceived.Add(newPartnershipState);

                                  db.SaveChanges();
                                  return true;
                              }
                              //friendshipState.RejectPartnershipRequestFrom(senderOrganizationAccountKey, receiverOrganizationAccountKey);
                          }
                          else
                          {
                              return false;
                          }

                      case PartnershipAction.Request:
                          if (partnershipState.CanRequestPartnershipTo(senderOrganizationAccountKey, receiverOrganizationAccountKey))
                          {
                              using (var db = new FHNWPrototypeDB())
                              {

                                  var lastState = (from partnerships in db.Partnerships
                       .Include("Sender.Organization")
                       .Include("Receiver.Organization")

                                                   where (((partnerships.Sender.Key == senderOrganizationAccountKey && partnerships.Receiver.Key == receiverOrganizationAccountKey) ||
                                                     (partnerships.Sender.Key == receiverOrganizationAccountKey && partnerships.Receiver.Key == senderOrganizationAccountKey)) &&
                                                     (partnerships.IsActive == true))
                                                   orderby partnerships.ActionDateTime descending
                                                   select partnerships)
                                                  .FirstOrDefault();

                                  lastState.IsActive = false;


                                  OrganizationAccount sender = db.OrganizationAccounts
                                  .Include("PartnershipsRequested")
                                  .Include("PartnershipsReceived")
                                  .SingleOrDefault(x => x.Key == senderOrganizationAccountKey);
                                  OrganizationAccount receiver = db.OrganizationAccounts
                                                             .Include("PartnershipsRequested")
                                                             .Include("PartnershipsReceived")
                                         .SingleOrDefault(x => x.Key == receiverOrganizationAccountKey);

                                  PartnershipStateInfo newPartnershipState = new PartnershipStateInfo();
                                  newPartnershipState.Key = Guid.NewGuid();
                                  newPartnershipState.Action = PartnershipAction.Request;
                                  newPartnershipState.ActionDateTime = actionDateTime;
                                  newPartnershipState.Receiver = receiver;
                                  newPartnershipState.Sender = sender;
                                  newPartnershipState.IsActive = true;

                                  db.Partnerships.Add(newPartnershipState);

                                  //  sender.PartnershipsRequested.Add(newPartnershipState);
                                  //  receiver.PartnershipsReceived.Add(newPartnershipState);

                                  db.SaveChanges();
                                  return true;
                              }
                              // friendshipState.RequestPartnershipTo(senderOrganizationAccountKey, receiverOrganizationAccountKey);
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
                  if (action == PartnershipAction.Request)
                  {
                      using (var db = new FHNWPrototypeDB())
                      {

                          var lastState = (from partnerships in db.Partnerships
                                                                      .Include("Sender.Organization")
                                                                      .Include("Receiver.Organization")

                                           where (((partnerships.Sender.Key == senderOrganizationAccountKey && partnerships.Receiver.Key == receiverOrganizationAccountKey) ||
                                             (partnerships.Sender.Key == receiverOrganizationAccountKey && partnerships.Receiver.Key == senderOrganizationAccountKey)) &&
                                             (partnerships.IsActive == true))
                                           orderby partnerships.ActionDateTime descending
                                           select partnerships)
                                          .FirstOrDefault();

                          lastState.IsActive = false;


                          OrganizationAccount sender = db.OrganizationAccounts
                                  .Include("PartnershipsRequested")
                                  .Include("PartnershipsReceived")
                                  .SingleOrDefault(x => x.Key == senderOrganizationAccountKey);
                          OrganizationAccount receiver = db.OrganizationAccounts
                                                     .Include("PartnershipsRequested")
                                                     .Include("PartnershipsReceived")
                                 .SingleOrDefault(x => x.Key == receiverOrganizationAccountKey);

                          PartnershipStateInfo newPartnershipState = new PartnershipStateInfo();
                          newPartnershipState.Key = Guid.NewGuid();
                          newPartnershipState.Action = PartnershipAction.Request;
                          newPartnershipState.ActionDateTime = actionDateTime;
                          newPartnershipState.Receiver = receiver;
                          newPartnershipState.Sender = sender;
                          newPartnershipState.IsActive = true;

                          db.Partnerships.Add(newPartnershipState);

                          //  sender.PartnershipsRequested.Add(newPartnershipState);
                          //  receiver.PartnershipsReceived.Add(newPartnershipState);

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

        public static List<CompleteProfile> GetEmployeesOfOrganizationAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();

            using(var db = new FHNWPrototypeDB())
            {
                var dbResult = db.OrganizationAccounts
                                                    .Include("Employees.OrganizationAccount.Organization")
                                                    .Include("Employees.User")
                                                    .SingleOrDefault(x=> x.Key==key).Employees;
                foreach(var item in dbResult)
                {
                    result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = item.Key, ReferenceType = AccountType.OrganizationAccount }, FullName = item.User.FirstName + " " + item.User.LastName, Description1 = item.OrganizationAccount.Name, Description2 = item.OrganizationAccount.Organization.Name });
                }
            }

            return result;
        }

        public static List<CompleteProfile> GetSisterDivisionsOfOrganizationAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();

            using (var db = new FHNWPrototypeDB())
            {
                var dbResult = db.OrganizationAccounts
                                                    .Include("PartnershipsRequested.Sender.Organization")
                                                      .Include("PartnershipsRequested.Receiver.Organization")
                                                    .Include("PartnershipsReceived.Sender.Organization")
                                                     .Include("PartnershipsReceived.Receiver.Organization")
                                                    .Include("Organization")
                                                    .Single(x => x.Key == key);
                foreach (PartnershipStateInfo partnership in dbResult.PartnershipsReceived)
                {

                    if (partnership.Sender.Organization.Key == dbResult.Organization.Key)
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = partnership.Sender.Key, ReferenceType = AccountType.OrganizationAccount }, FullName = partnership.Sender.Name , Description1= partnership.Sender.Description  });
                    }

                }
                foreach (PartnershipStateInfo partnership in dbResult.PartnershipsRequested)
                {
                    if (partnership.Receiver.Organization.Key == dbResult.Organization.Key)
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = partnership.Receiver.Key, ReferenceType = AccountType.OrganizationAccount }, FullName = partnership.Receiver.Name, Description1=partnership.Receiver.Description  });
                    }
                }
                return result;
            }
        }

        public static List<CompleteProfile> GetPartnersOfOrganizationAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();

            using (var db = new FHNWPrototypeDB())
            {
                var dbResult = db.OrganizationAccounts
                                                   .Include("PartnershipsRequested.Sender.Organization")
                                                      .Include("PartnershipsRequested.Receiver.Organization")
                                                    .Include("PartnershipsReceived.Sender.Organization")
                                                     .Include("PartnershipsReceived.Receiver.Organization")
                                                    .Include("Organization")
                                                    .Single(x => x.Key == key);
                foreach (PartnershipStateInfo partnership in dbResult.PartnershipsReceived )
                {

                    if (partnership.Sender.Organization.Key != dbResult.Organization.Key)
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = partnership.Sender.Key, ReferenceType = AccountType.OrganizationAccount }, FullName = partnership.Sender.Name , Description1= partnership.Sender.Description  });
                    }

                }
                foreach (PartnershipStateInfo partnership in dbResult.PartnershipsRequested )
                {
                    if (partnership.Receiver.Organization.Key != dbResult.Organization.Key)
                    {
                        result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = partnership.Receiver.Key, ReferenceType = AccountType.OrganizationAccount }, FullName = partnership.Receiver.Name , Description1=partnership.Receiver.Description  });
                    }
                }
                return result;
            }
        
        }

        public static List<CompleteProfile> GetAlliancesOfOrganizationAccountByKey(Guid key)
        {
            List<CompleteProfile> result = new List<CompleteProfile>();
            using (var db = new FHNWPrototypeDB())
            {
                var dbResult = db.OrganizationAccounts
                                            .Include("AllianceMemberships.AllianceRequested")
                                            .Single(x => x.Key == key);
                foreach (AllianceMembershipStateInfo membership in dbResult.AllianceMemberships)
                {

                    result.Add(new CompleteProfile { BasicProfile = new BasicProfile { ReferenceKey = membership.AllianceRequested.Key, ReferenceType = AccountType.Alliance }, FullName = membership.AllianceRequested.Name });

                }
                return result;
            }
        }

        public static OrganizationAccount GetOrganizationAccountByUserAccountKey(Guid userAccountKey)
        {
            OrganizationAccount organizationAccountFound = null;
            ContentStream contentStreamFound = null;
            using (var db = new FHNWPrototypeDB())
            {
                organizationAccountFound = db.UserAccounts
                                    .Include("OrganizationAccount.Organization")

                                                 .Include("OrganizationAccount.PartnershipsRequested.Sender.Organization")
                                                 .Include("OrganizationAccount.PartnershipsRequested.Receiver.Organization")
                                                 .Include("OrganizationAccount.PartnershipsReceived.Sender.Organization")
                                                 .Include("OrganizationAccount.PartnershipsReceived.Receiver.Organization")
                                                 .Include("OrganizationAccount.AllianceMemberships.AllianceRequested")
                                                 .Include("OrganizationAccount.Employees.OrganizationAccount.Organization")
                                                     .Include("OrganizationAccount.Employees.User")
                                                 .Include("OrganizationAccount.Location")
                                           
                                    .SingleOrDefault(x => x.Key == userAccountKey).OrganizationAccount;
                contentStreamFound = (from cs in db.ContentStreams
                                              .Include("Posts.Author")
                                               .Include("Posts.Comments.Author")
                                      where cs.Owner.ReferenceKey == organizationAccountFound.Key
                                      select cs).FirstOrDefault();

                if (organizationAccountFound != null)
                {
                    if (contentStreamFound != null)
                    {
                        organizationAccountFound.Wall = contentStreamFound;
                    }
                    else
                    {
                        ContentStream emptyWall = new ContentStream();
                        emptyWall.Posts = new List<Post>();
                        organizationAccountFound.Wall = emptyWall;
                    }
                }
                else
                {
                    return null;
                }

            }
            return organizationAccountFound;
        }

        public static Boolean isPotentiallyRelatedWithThisViewerAsOrganization(string organizationAccountEmail)
        {
            return true;
        }

        //public static Boolean isPotentiallyRelatedWithThisViewerAsOrganization(string userAccountEmail)
        //{
        //    return true;
        //}



        public static IEnumerable<OrganizationAccount> FindAll()
        {
            IEnumerable<OrganizationAccount> result = null;

            using (var db = new FHNWPrototypeDB())
            {
                result = from organizationAccount in db.OrganizationAccounts
                         select organizationAccount;

                return result.ToList();
            }
        }

        public static IEnumerable<OrganizationAccount> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<OrganizationAccount> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
