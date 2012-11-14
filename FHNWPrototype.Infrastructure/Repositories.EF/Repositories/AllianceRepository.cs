using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Alliances;
using FHNWPrototype.Domain.AllianceMemberships.States;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    /// <summary>
    /// It is safe to return inside a using statement <see cref="http://brendan.enrick.com/post/Returning-From-Inside-a-Using-Statement.aspx"/>
    /// </summary>
    public static  class AllianceRepository // : IAllianceRepository
    {

        //private FHNWPrototypeDB db = null;

        //public AllianceRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}


        public static  void Save(Alliance entity)
        {
            throw new NotImplementedException();
        }

        public static  void Add(Alliance entity)
        {
            throw new NotImplementedException();
        }

        public static  void Remove(Alliance entity)
        {
            throw new NotImplementedException();
        }

        public static  Alliance FindBy(Guid key)
        {
            Alliance allianceFound = new Alliance();
           // ContentStream contentStreamFound = null;
            using (var db = new FHNWPrototypeDB())
            {
                                            //                .Include("Wall.Posts.Author.User")
                                            //.Include("Wall.Posts.Comments.Author.User")
                var result = (from alliance in db.Alliances
                                            //.Include("AllianceMemberships.AllianceRequested")
                                            .Include("AllianceMemberships.OrganizationRequestor")
                                            //.Include("Wall.Posts.Author")
                                            //.Include("Wall.Posts.Comments.Author")
                                     where alliance.Key == key
                                     select alliance).FirstOrDefault();

                //contentStreamFound = (from cs in db.ContentStreams
                //                                                .Include("Posts.Author")
                //                                                .Include("Posts.PostLikes")
                //                                                .Include("Posts.Comments.Author")
                //                                                .Include("Posts.Comments.CommentLikes")
                //                                                where cs.Owner.ReferenceKey == allianceFound.Key
                //                                                select cs).FirstOrDefault();

                //if (contentStreamFound != null)
                //{
                //    var newPostList = contentStreamFound.Posts.OrderByDescending(x => x.PublishDateTime).ToList();
                //    foreach (var post in newPostList)
                //    {
                //        var newCommentList = post.Comments.OrderBy(x => x.PublishDateTime).ToList();
                //        post.Comments = newCommentList;
                //    }
                //    contentStreamFound.Posts = newPostList;
                //}
                //else
                //{
                //    contentStreamFound = new ContentStream();
                //    contentStreamFound.Posts = new List<Post>();
                //}


               // allianceFound.Wall = contentStreamFound;

                allianceFound.Key = result.Key;
                allianceFound.Name = result.Name;
                allianceFound.Description = result.Description;
              
                allianceFound.AllianceMemberships = result.AllianceMemberships;

                return allianceFound;
            }
           
        }

        public static  IEnumerable<Alliance> FindAll()
        {
            IEnumerable<Alliance> results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = from alliances in db.Alliances
                                            .Include("AllianceMemberships.AllianceRequested")
                                            .Include("AllianceMemberships.OrganizationRequestor")
                              select alliances;
                return results;
            }
         
        }

        public static  IEnumerable<Alliance> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public static  IEnumerable<Alliance> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }


        public static  IEnumerable<AllianceMembershipStateInfo> GetAllAllianceMembershipsByAllianceKey(Guid key)
        {
            IEnumerable<AllianceMembershipStateInfo> results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = from membership in db.AllianceMemberships
                                                .Include("AllianceRequested")
                                                .Include("OrganizationRequestor")
                              where membership.AllianceRequested.Key == key
                              select membership;
                return results;
            }
          
        }

        public static  byte[] GetHeaderPictureByAllianceKey(Guid key)
        {
            byte[] results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = db.Alliances.Single(x => x.Key == key).HeaderPicture;
                return results;
            }
          
        }

        public static  byte[] GetProfilePictureByAllianceKey(Guid key)
        {
            byte[] results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = db.Alliances.Single(x => x.Key == key).ProfilePicture;
                return results;
            }
         
        }

    }
}
