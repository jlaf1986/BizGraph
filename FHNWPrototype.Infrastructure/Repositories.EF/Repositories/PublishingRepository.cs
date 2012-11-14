using FHNWPrototype.Domain.Publishing;
using FHNWPrototype.Domain.Publishing.ContentStreams;
using FHNWPrototype.Domain.Publishing.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static  class PublishingRepository
    {
        //private FHNWPrototypeDB db = null;

        //public ContentStreamRepository()
        //{
        //    //db = FHNWSimulationDBContext.Current;
        //    //db = new FHNWPrototypeDB();
        //}

        public static ContentStream GetWallByOwnerReferenceKey(Guid OwnerKey)
        {
           // var result = null;
            using (var db = new FHNWPrototypeDB())
            {
                ContentStream result = db.ContentStreams
                              .Include("Posts.Author")
                              .Include("Posts.PostLikes.Author")
                              .Include("Posts.Comments.Author")
                              .Include("Posts.Comments.CommentLikes.Author")
                              .SingleOrDefault(x => x.Owner.ReferenceKey  == OwnerKey);
                if (result != null)
                {
                    var newPostList = result.Posts.OrderByDescending(x => x.PublishDateTime).ToList();
                    foreach (var post in newPostList)
                    {
                        var newCommentList = post.Comments.OrderBy(x => x.PublishDateTime).ToList();
                        post.Comments = newCommentList;
                    }
                    result.Posts = newPostList;
                }
                else
                {
                    result = new ContentStream();
                    result.Posts = new List<Post>();

                }

                

                return result;
            }
          
        }

        public static void LikePost(Guid AuthorKey, Guid postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisPost = db.Posts
                    .Include("PostLikes")
                    .Single(x => x.Key == postKey);
                var author= db.BasicProfiles.Single(x=> x.ReferenceKey ==AuthorKey);
                PostLike newLike = new PostLike();
                newLike.Author = author;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Post = thisPost;
                db.PostLikes.Add(newLike);
                db.SaveChanges();
            }

        }

        public static void UnLikePost(Guid AuthorUserAccountKey, Guid postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisPost = db.Posts.Single(x => x.Key == postKey);
                var author = db.UserAccounts.Single(x => x.Key == AuthorUserAccountKey);
                var unlike = db.PostLikes.Single(x => x.Post.Key == postKey && x.Author.ReferenceKey == AuthorUserAccountKey);
                db.PostLikes.Remove(unlike);
                db.SaveChanges();
            }
        }

        public static void LikeComment(Guid AuthorKey, Guid commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisComment = db.Comments.SingleOrDefault(x => x.Key == commentKey);
                var author = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == AuthorKey);
                CommentLike newLike = new CommentLike();
                newLike.Author = author;
                newLike.DateTime = DateTime.Now;
                newLike.Value = LikeValue.Positive;
                newLike.Comment  = thisComment;
                db.CommentLikes.Add(newLike);
                db.SaveChanges();
            }
        }

        public static void UnLikeComment(Guid AuthorKey, Guid commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var thisComment = db.Posts.SingleOrDefault(x => x.Key == commentKey);
                //var author = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey  == AuthorKey);
                var unlike = db.CommentLikes.SingleOrDefault(x => x.Comment.Key == commentKey && x.Author.ReferenceKey  == AuthorKey);
                db.CommentLikes.Remove(unlike);
                db.SaveChanges();
            }
        }

        public static Guid  SubmitNewPost(Guid AuthorKey, Guid wallOwnerReferenceKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();
                var wall = db.ContentStreams.SingleOrDefault(x => x.Owner.ReferenceKey == wallOwnerReferenceKey);
                var author = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey  == AuthorKey);

                Post newPost = new Post();
                newPost.Author = author;
                newPost.Key = newGuid;
                newPost.PublishDateTime = DateTime.Now;
                newPost.Text = text;
                newPost.Wall = wall;

                db.Posts.Add(newPost);
                db.SaveChanges();
                return newGuid;
            }
        }

        public static Guid SubmitNewComment(Guid AuthorKey, Guid postKey, string text)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid  newGuid = Guid.NewGuid();
                var post = db.Posts.Single(x => x.Key == postKey);
                // var author = db.UserAccounts.Single(x => x.Key == AuthorKey);
                var author = db.BasicProfiles.SingleOrDefault(x => x.ReferenceKey == AuthorKey);

                Comment newComment = new Comment();
                newComment.Author = author;
                newComment.Key = newGuid;
                newComment.PublishDateTime = DateTime.Now;
                newComment.Text = text;
                newComment.Post = post;

                db.Comments.Add(newComment);
                db.SaveChanges();
                return newGuid;
            }  
        }

        public static  void DeletePost(Guid  postKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
              //  db.Configuration.LazyLoadingEnabled = false;
                var post = db.Posts
                    .Include("Author")
                    .Include("PostLikes.Author")
                    .Include("Comments.CommentLikes")
                    .Include("Wall")
                    .SingleOrDefault(x => x.Key == postKey);

                List<CommentLike> commentLikesToDelete = new List<CommentLike>();
                List<Comment> commentsToDelete = new List<Comment>();
                List<PostLike> postLikesToDelete = new List<PostLike>();

                foreach (Comment comment in post.Comments)
                {
                    foreach (CommentLike like in comment.CommentLikes)
                    {
                        commentLikesToDelete.Add(like);
                    }
                    commentsToDelete.Add(comment);
                }
                foreach (PostLike like in post.PostLikes)
                {
                    postLikesToDelete.Add(like);
                }

                foreach (var item in commentLikesToDelete)
                {
                    db.CommentLikes.Remove(item);
                }

                foreach (var item in commentsToDelete)
                {
                    db.Comments.Remove(item);
                }

                foreach (var item in postLikesToDelete)
                {
                    db.PostLikes.Remove(item);
                }

                db.Posts.Remove(post);

                db.SaveChanges();
            }
        }

        public static  void DeleteComment(Guid  commentKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var comment = db.Comments
                    .Include("CommentLikes")
                    .SingleOrDefault(x => x.Key == commentKey);

                List<CommentLike> commentLikesToDelete = new List<CommentLike>();

                foreach (CommentLike like in comment.CommentLikes)
                {
                    commentLikesToDelete.Add(like);
                }

                foreach (var item in commentLikesToDelete)
                {
                    db.CommentLikes.Remove(item);
                }

                db.Comments.Remove(comment);
                db.SaveChanges();
            }
        }


    }
}
