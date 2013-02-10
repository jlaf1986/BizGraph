using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Infrastructure.Repositories.EF.Repositories
{
    public static class SuscriptionRepository
    {

        public static List<Notification> GetAllNewNotifications(Guid suscriberKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var lastAccess = db.SystemAccounts
                    .Include("Holder")
                    .FirstOrDefault(x => x.Holder.ReferenceKey == suscriberKey).LastCheck;

                var references = db.Suscriptions
                                                .Include("Suscriber")
                                                .Where(x => x.Suscriber.ReferenceKey == suscriberKey)
                                                .Select(y=>y.ReferencePoint)
                                                .ToList();
                List<Notification> notifications = new List<Notification>();
                foreach(var reference  in references){
                    notifications.AddRange(
                        db.Notifications
                        .Include("Event.TriggeredBy")
                        .Include("NotifiedTo")
                        .Where(x => x.Event.PostOrComment == reference && x.NotifiedTo.ReferenceKey == suscriberKey && x.Event.TriggeredOn > lastAccess)
                        );
                }
                //var author = db.UserAccounts.FirstOrDefault(x => x.Key == suscriberKey);

                return notifications;
            }
        }

        public static Int32 GetCountOfNewNotifications(Guid suscriberKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                var lastAccess = db.SystemAccounts.FirstOrDefault(x => x.Holder.ReferenceKey == suscriberKey).LastCheck;

                var references = db.Suscriptions
                                                .Include("Suscriber")
                                                .Where(x => x.Suscriber.ReferenceKey == suscriberKey)
                                                .Select(y => y.ReferencePoint)
                                                .ToList();
                Int32 counter = 0;
                foreach (var reference in references)
                {
                   counter+= db.Notifications.Where(x => x.Event.PostOrComment == reference && x.NotifiedTo.ReferenceKey == suscriberKey && x.Event.TriggeredOn>lastAccess).Count();
                }
                //var author = db.UserAccounts.FirstOrDefault(x => x.Key == suscriberKey);

                return counter;
            }
        }

        public static List<Notification> GetAllNotifications(Guid suscriberKey)
        {
            using (var db = new FHNWPrototypeDB())
            {
                //var lastAccess = db.SystemAccounts.FirstOrDefault(x => x.Holder.ReferenceKey == suscriberKey).LastCheck;

                var references = db.Suscriptions
                                                .Include("Suscriber")
                                                .Where(x => x.Suscriber.ReferenceKey == suscriberKey)
                                                .Select(y => y.ReferencePoint)
                                                .ToList();
                List<Notification> notifications = new List<Notification>();
                foreach (var reference in references)
                {
                    notifications.AddRange(db.Notifications.Where(x => x.Event.PostOrComment == reference && x.NotifiedTo.ReferenceKey == suscriberKey).Take(5));
                }
                //var author = db.UserAccounts.FirstOrDefault(x => x.Key == suscriberKey);

                return notifications;
            }
        }

    }
}
