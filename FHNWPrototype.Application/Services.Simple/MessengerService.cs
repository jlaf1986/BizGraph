using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Messenger;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public class MessengerService
    {

        public static string SubmitMessage(string senderKey, string chatRoom, string message)
        {

           // BasicProfile authorProfile = new BasicProfile { ReferenceKey = new Guid(senderKey), ReferenceType = AccountType.UserAccount };

            List<MessengerPostViewModel> result = new List<MessengerPostViewModel>();

            Guid returnGuid = MessengerRepository.SubmitNewChatMessage(new Guid(senderKey), new Guid(chatRoom), message);

            return returnGuid.ToString();
        }

        public static List<MessengerPostViewModel> GetMessagesByChatRoom(string chatRoom)
        {

            List<MessengerPostViewModel> result = new List<MessengerPostViewModel>();

            List<MessengerPost> chatPosts = MessengerRepository.GetMessagesByChatRoom(new Guid(chatRoom));

            foreach (MessengerPost item in chatPosts)
            {
                result.Add(new MessengerPostViewModel { Text = item.Text, PublishDateTime = item.PublishDateTime, Author = new BasicProfileViewModel { ReferenceKey = item.Author.ReferenceKey.ToString(), AccountType = item.Author.ReferenceType } });
            }

            return result;
        }

    }
}
