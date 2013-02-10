using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain._Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Notifications
{
    public class Suscription : EntityBase, IAggregateRoot
    {
        public BasicProfile Suscriber { get; set; }
        public Guid ReferencePoint { get; set; } //usually the GUID of post, comments, tweets but also tags on them 
        public SuscriptionType Type { get; set; }
        
        protected override void Validate()
        {
            throw new NotImplementedException();
           
        }
    }

    public enum TypeOfReference
    {
        Post=0,
        Comment=1,
        Tweet=2,
        Retweet=3
    }

    public enum SuscriptionType
    {
        PostOnMyWall = 0, //correspondent to NewPostOnMyWall, 
        CommentOnPostOnMyWall = 1, //correspondent to NewCommentOnPostOnMyWall
        MyPost = 2, //correspondent to LikedMyPost , NewCommentOnMyPost
        MyComment = 3, //correspondent to LikedMyComment
        PostILiked = 4, //correspondent to NewCommentOnPostILiked
        PostOnGroupIBelong = 5, //correspondent to NewPostOnGroup
        PostOnMyEmployerWall=6,
        TweetOnTagIBelong =7,
        PostInTagIBelong =8
    }

    // EventType
   
 //       NewPostOnMyWall = 0,
 //       NewCommentOnPostOnMyWall = 1,
 //       LikedMyPost = 2,
 //       LikedMyComment = 3,
 //       NewCommentOnMyPost=4,
 //       NewCommentOnPostILiked = 5,
 //       NewPostOnGroup = 6,
 //       NewPostOnEmployer=7,
 //       NewPostToMyTag=8,
 //       NewTweetForTag=9
   


}
