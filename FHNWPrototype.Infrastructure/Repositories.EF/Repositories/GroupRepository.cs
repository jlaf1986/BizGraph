using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain.Groups;
using FHNWPrototype.Domain._Base.Querying;
using FHNWPrototype.Domain.GroupMemberships.States;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class GroupRepository //: IGroupRepository
    {

        //private FHNWPrototypeDB db = null;

        //public GroupRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}

        public static  void Save(Group entity)
        {
            throw new NotImplementedException();
        }

        public static  void Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public static  void Remove(Group entity)
        {
            throw new NotImplementedException();
        }

        public static  Group FindBy(Guid key)
        {
            Group groupFound = new Group() ;
            //ContentStream contentStreamFound = new ContentStream();
            //contentStreamFound.Posts = new List<Post>();
            
            using (var db = new FHNWPrototypeDB())
            {
                var result = (from g in db.Groups
                                        //.Include("GroupMemberships.RequestedGroup")
                                        .Include("GroupMemberships.RequestorAccount.User")
                                        //.Include("Wall.Posts.Author")
                                        //.Include("Wall.Posts.Comments.Author")
                              where g.Key == key
                              select g).FirstOrDefault();
                //contentStreamFound = (from cs in db.ContentStreams
                //                                    .Include("Posts.Author")
                //                                    .Include("Posts.PostLikes")
                //                                    .Include("Posts.Comments.Author")
                //                                    .Include("Posts.Comments.CommentLikes")
                //                      where cs.Owner.ReferenceKey  == groupFound.Key
                //                      select cs).FirstOrDefault();

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
                //groupFound.Wall = contentStreamFound;
                groupFound.Key = result.Key;
                groupFound.Name = result.Name;
                groupFound.Description = result.Description;
                groupFound.GroupMemberships = result.GroupMemberships;
                return groupFound;
            }
        }

        public static  IEnumerable<Group> FindAll()
        {
            IEnumerable<Group> results = null;
            using (var db = new FHNWPrototypeDB())
            {
                results = from g in db.Groups
                                        .Include("GroupMemberships.RequestedGroup")
                                        .Include("GroupMemberships.RequestorAccount.User")
                              select g;
                return results;
            }
            
        }

        public static  IEnumerable<Group> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public static  IEnumerable<Group> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public static  IEnumerable<GroupMembershipStateInfo> GetAllGroupMembershipsByGroupKey(Guid key)
        {
              IEnumerable<GroupMembershipStateInfo> results = null;
              using (var db = new FHNWPrototypeDB())
              {
                  results = from g in db.GroupMemberships
                                        .Include("RequestorAccount.User")
                            where g.RequestedGroup.Key == key
                            select g;

                  return results;
              }
        }


        public static  byte[] GetHeaderPictureByGroupKey(Guid key)
        {
            Group results = null;

            using (var db = new FHNWPrototypeDB())
            {
                results = (from g in db.Groups
                           where g.Key == key
                           select g).FirstOrDefault();

                return results.HeaderPicture;
            }
        }

        public static  byte[] GetProfilePictureByGroupKey(Guid key)
        {
             Group results = null;

             using (var db = new FHNWPrototypeDB())
             {
                 results = (from g in db.Groups
                            where g.Key == key
                            select g).FirstOrDefault();

                 return results.ProfilePicture;
             }
        }

    }
}
