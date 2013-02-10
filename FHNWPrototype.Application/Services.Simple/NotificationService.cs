using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Notifications;
using FHNWPrototype.Infrastructure.Repositories.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Application.Services.Simple
{
    public static class NotificationService
    {

        public static List<NotificationViewModel> GetNewNotifications(String  suscriberKey)
        {
            List<Notification> notifications = SuscriptionRepository.GetAllNewNotifications(new Guid(suscriberKey));
            List<NotificationViewModel> result = new List<NotificationViewModel>();
            foreach (Notification notification in notifications)
            {
                NotificationViewModel notificationVM = new NotificationViewModel
                {
                    NotifiedTo = new BasicProfileViewModel
                    {
                        ReferenceKey = notification.NotifiedTo.ReferenceKey.ToString(),
                        AccountType = notification.NotifiedTo.ReferenceType
                    },
                    Event = new EventViewModel { 
                                    TriggeredBy = new BasicProfileViewModel { 
                                                            ReferenceKey=notification.Event.TriggeredBy.ReferenceKey.ToString(), 
                                                            AccountType=notification.Event.TriggeredBy.ReferenceType  }, 
                                    TriggeredOn=notification.Event.TriggeredOn, 
                                    Type=notification.Event.Type , 
                                    PostOrComment=notification.Event.PostOrComment.ToString()  }
                };
                result.Add(notificationVM);
            }

            return result;
            
        }

        public static Int32 GetCountOfNewNotifications(String suscriberKey)
        {
            return SuscriptionRepository.GetCountOfNewNotifications(new Guid(suscriberKey));
        }

        public static List<NotificationViewModel> GetAllNotifications(String suscriberKey)
        {
            List<Notification> notifications = SuscriptionRepository.GetAllNewNotifications(new Guid(suscriberKey));
            List<NotificationViewModel> result = new List<NotificationViewModel>();
            foreach (Notification notification in notifications)
            {
                NotificationViewModel notificationVM = new NotificationViewModel
                {
                    NotifiedTo = new BasicProfileViewModel
                    {
                        ReferenceKey = notification.NotifiedTo.ReferenceKey.ToString(),
                        AccountType = notification.NotifiedTo.ReferenceType
                    },
                    Event = new EventViewModel
                    {
                        TriggeredBy = new BasicProfileViewModel
                        {
                            ReferenceKey = notification.Event.TriggeredBy.ReferenceKey.ToString(),
                            AccountType = notification.Event.TriggeredBy.ReferenceType
                        },
                        TriggeredOn = notification.Event.TriggeredOn,
                        Type = notification.Event.Type,
                        PostOrComment = notification.Event.PostOrComment.ToString()
                    }
                };
                result.Add(notificationVM);
            }



            return result;

        }

    }
}
