using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain._Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.Notifications
{
    public class Event : EntityBase, IAggregateRoot
    {
        public EventType Type { get; set; }
        public BasicProfile TriggeredBy { get; set; }
        public DateTime TriggeredOn { get; set; }
        public Guid PostOrComment { get; set; }
        //public BasicProfile WallOwnerOfPostOrComment { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public enum EventType
    {
        NewPostOnMyWall = 0,
        NewCommentOnPostOnMyWall = 1,
        LikedMyPost = 2,
        LikedMyComment = 3,
        NewCommentOnMyPost=4,
        NewCommentOnPostILiked = 5,
        NewPostOnGroup = 6,
        NewPostOnEmployer=7,
        NewPostToMyTag=8,
        NewTweetForTag=9
    }
}
