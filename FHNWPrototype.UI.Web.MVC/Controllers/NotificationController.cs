using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Controllers.UIViewModels.Notifications;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class NotificationController : Controller
    {
        //
        // GET: /Notification/

        public PartialViewResult GetAllNotifications()
        {
            List<NotificationViewModel> notificationsVM = new List<NotificationViewModel>();
            //List<NotificationView> notifications = new List<NotificationView>();
            NotificationsView notificationsView = new NotificationsView();

            notificationsView.Notifications = new List<NotificationView>();

            CompleteProfile profile = (CompleteProfile)Session["myProfile"];

            notificationsVM = NotificationService.GetAllNotifications(profile.BasicProfile.ReferenceKey.ToString());

            foreach (NotificationViewModel nv in notificationsVM)
            {

                BasicProfile basicProfileTriggeredBy = new BasicProfile { ReferenceKey = new Guid( nv.Event.TriggeredBy.ReferenceKey) , ReferenceType = nv.Event.TriggeredBy.AccountType };
                CompleteProfileViewModel completeProfileTriggeredBy = SecurityService.GetCompleteProfileFromBasicProfile(basicProfileTriggeredBy);

                BasicProfile basicProfileNotifiedTo = new BasicProfile{ ReferenceKey= new Guid(nv.NotifiedTo.ReferenceKey), ReferenceType= nv.NotifiedTo.AccountType  };
                CompleteProfileViewModel completeProfileNotifiedTo = SecurityService.GetCompleteProfileFromBasicProfile(basicProfileNotifiedTo);


                notificationsView.Notifications.Add(
                    new NotificationView
                    {
                        Event = new EventView
                        {
                            TriggeredBy = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = basicProfileTriggeredBy.ReferenceKey.ToString(), AccountType = basicProfileTriggeredBy.ReferenceType }, FullName = completeProfileTriggeredBy.FullName, Description1 = completeProfileTriggeredBy.Description1, Description2 = completeProfileTriggeredBy.Description2 },
                            TriggeredOn = nv.Event.TriggeredOn,
                            PostOrComment = nv.Event.PostOrComment,
                            Type = nv.Event.Type
                        },
                        NotifiedTo = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=basicProfileNotifiedTo.ReferenceKey.ToString(), AccountType=basicProfileNotifiedTo.ReferenceType  }, FullName=completeProfileNotifiedTo.FullName, Description1=completeProfileNotifiedTo.Description1 , Description2=completeProfileNotifiedTo.Description2  }
                    });
            }
 
            return PartialView("_partial_notifications", notificationsView);
        }

        public PartialViewResult  GetLatestNotifications()
        {
            List<NotificationViewModel> notificationsVM = new List<NotificationViewModel>();
            //List<NotificationView> notifications = new List<NotificationView>();
            NotificationsView notificationsView = new NotificationsView();
            notificationsView.Notifications = new List<NotificationView>();
            CompleteProfile profile = (CompleteProfile)Session["myProfile"];

            notificationsVM = NotificationService.GetNewNotifications(profile.BasicProfile.ReferenceKey.ToString());

            foreach (NotificationViewModel nv in notificationsVM)
            {

                BasicProfile basicProfileTriggeredBy = new BasicProfile { ReferenceKey = new Guid(nv.Event.TriggeredBy.ReferenceKey), ReferenceType = nv.Event.TriggeredBy.AccountType };
                CompleteProfileViewModel completeProfileTriggeredBy = SecurityService.GetCompleteProfileFromBasicProfile(basicProfileTriggeredBy);

                BasicProfile basicProfileNotifiedTo = new BasicProfile { ReferenceKey = new Guid(nv.NotifiedTo.ReferenceKey), ReferenceType = nv.NotifiedTo.AccountType };
                CompleteProfileViewModel completeProfileNotifiedTo = SecurityService.GetCompleteProfileFromBasicProfile(basicProfileNotifiedTo);


                notificationsView.Notifications.Add(
                    new NotificationView
                    {
                        Event = new EventView
                        {
                            TriggeredBy = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = basicProfileTriggeredBy.ReferenceKey.ToString(), AccountType = basicProfileTriggeredBy.ReferenceType }, FullName = completeProfileTriggeredBy.FullName, Description1 = completeProfileTriggeredBy.Description1, Description2 = completeProfileTriggeredBy.Description2 },
                            TriggeredOn = nv.Event.TriggeredOn,
                            PostOrComment = nv.Event.PostOrComment,
                            Type = nv.Event.Type
                        },
                        NotifiedTo = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = basicProfileNotifiedTo.ReferenceKey.ToString(), AccountType = basicProfileNotifiedTo.ReferenceType }, FullName = completeProfileNotifiedTo.FullName, Description1 = completeProfileNotifiedTo.Description1, Description2 = completeProfileNotifiedTo.Description2 }
                    });
            }

            return PartialView("_partial_notifications", notificationsView);
        }

        public Int32 GetCountOfNewNotifications()
        {
             CompleteProfile profile = (CompleteProfile)Session["myProfile"];

            return NotificationService.GetCountOfNewNotifications(profile.BasicProfile.ReferenceKey.ToString());
        }

    }
}
