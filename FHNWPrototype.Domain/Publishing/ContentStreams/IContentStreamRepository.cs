using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Repositories;

namespace FHNWPrototype.Domain.Publishing.ContentStreams
{
    public interface IContentStreamRepository : IRepository<ContentStream>
    {
        ContentStream GetWallByOwner(IPublishingCapable owner);
        List<Post> GetPostsByWall(ContentStream wall);
        Post GetPostById(Guid postId);
        //void Save(ContentStream wall);
        //void Add(ContentStream  wall);
        //void Remove(ContentStream  wall);

        //post related
        void AddPostToWall(ContentStream wall, Post post);
        void RemovePostFromWall(ContentStream wall, Post post);
    }
}
