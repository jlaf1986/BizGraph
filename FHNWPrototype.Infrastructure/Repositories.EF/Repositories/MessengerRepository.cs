using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static class MessengerRepository
    {

        public static Guid SubmitNewChatMessage(Guid authorKey, Guid chatRoom, String message)
        {
            using (var db = new FHNWPrototypeDB())
            {
                Guid newGuid = Guid.NewGuid();
                MessengerPost messengerPost = new MessengerPost();

                messengerPost.Key = newGuid;
                messengerPost.PublishDateTime = DateTime.Now;
                messengerPost.Text = message;
                messengerPost.Author = db.BasicProfiles.FirstOrDefault(x => x.ReferenceKey == authorKey);
                messengerPost.ChatRoom = chatRoom;
                

                db.MessengerPosts.Add(messengerPost);
                db.SaveChanges();
                return newGuid;
            }
        }

        public static List<MessengerPost> GetMessagesByChatRoom(Guid chatRoom)
        {
            List<MessengerPost> result = new List<MessengerPost>();

            using (var db = new FHNWPrototypeDB())
            {
               
                var temp= db.MessengerPosts.Include("Author").Where(x => x.ChatRoom == chatRoom).OrderByDescending(x => x.PublishDateTime).ToList();

                foreach (MessengerPost mp in temp)
                {
                    result.Add(mp);
                }

            }
            return result;

        }


    }
}
