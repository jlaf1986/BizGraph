using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.UI.Web.MVC.Signals;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Controllers.UIViewModels.Messenger;
using FHNWPrototype.UI.Web.MVC.Controllers;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.UI.Web.MVC;
using System.Xml.Linq;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;

namespace FHNWPrototype.Application.Controllers.Controllers
{
    public class MessengerController : Controller
    {
        //
        // GET: /Messenger/

        public ActionResult Index(string id = "A0000001-B002-C003-D004-E00000000005")
        {
            CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();
          //  var context2 = GlobalHost.

          //  SignalRState.AddOrUpdateAliveConnections(myProfile.BasicProfile.ReferenceKey.ToString(), context.

            //context.Clients.All.Received(newMessage.ToString());
            MessengerView messengerView = new MessengerView();
            messengerView.ChatRoom = id;
            messengerView.Profile = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=myProfile.BasicProfile.ReferenceKey.ToString(), AccountType=myProfile.BasicProfile.ReferenceType }, FullName=myProfile.FullName, Description1=myProfile.Description1 , Description2= myProfile.Description2  };
            messengerView.Users = new List<CompleteProfileView>();
            var connections = SignalRState.GetAllConnections();

            

            foreach (var connection in connections)
            {
                CompleteProfileViewModel profile = SecurityService.GetCompleteProfileFromUserEmail(connection.Key);

                messengerView.Users.Add(new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=profile.BasicProfile.ReferenceKey, AccountType=profile.BasicProfile.AccountType  }, FullName=profile.FullName, Description1=profile.Description1, Description2=profile.Description2  });

            }
            List<MessengerPostViewModel> chatMessages = MessengerService.GetMessagesByChatRoom(id);

            messengerView.Posts = new List<MessengerPostView>();
            
            foreach (var chatMessage in chatMessages)
            {
                if (chatMessage.Author.ReferenceKey != myProfile.BasicProfile.ReferenceKey.ToString())
                {
                    BasicProfile thisProfile = new BasicProfile { ReferenceKey = new Guid(chatMessage.Author.ReferenceKey), ReferenceType = chatMessage.Author.AccountType };
                    CompleteProfileViewModel thisAuthorProfile = SecurityService.GetCompleteProfileFromBasicProfile(thisProfile);
                    messengerView.Posts.Add(new MessengerPostView
                    {
                        Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = thisAuthorProfile.BasicProfile.ReferenceKey, AccountType = thisAuthorProfile.BasicProfile.AccountType }, FullName = thisAuthorProfile.FullName, Description1 = thisAuthorProfile.Description1, Description2 = thisAuthorProfile.Description2 },
                        Key = chatMessage.Key,
                        Text = chatMessage.Text,
                        PublishDateTime = chatMessage.PublishDateTime
                    });
                }
                else
                {
                    messengerView.Posts.Add(new MessengerPostView
                    {
                        Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey=myProfile.BasicProfile.ReferenceKey.ToString(), AccountType=myProfile.BasicProfile.ReferenceType  }, FullName=myProfile.FullName, Description1=myProfile.Description1, Description2=myProfile.Description2  },
                        Key = chatMessage.Key,
                        Text = chatMessage.Text,
                        PublishDateTime = chatMessage.PublishDateTime
                    });
                }
            }
          

            return View(messengerView);
        }

        public JsonResult  SubmitMessengerPost(string chatRoom, string text)
        {
             CompleteProfile myProfile = (CompleteProfile)Session["myProfile"];
            string messageKey =  MessengerService.SubmitMessage(myProfile.BasicProfile.ReferenceKey.ToString(), chatRoom, text);

            MessengerPostView messengerPost = new MessengerPostView();
            messengerPost.Key = messageKey;
            messengerPost.Text = text;
            messengerPost.PublishDateTime = DateTime.Now;
            messengerPost.Author = new CompleteProfileView { BasicProfile = new BasicProfileView { ReferenceKey = myProfile.BasicProfile.ReferenceKey.ToString(), AccountType = myProfile.BasicProfile.ReferenceType }, FullName = myProfile.FullName, Description1 = myProfile.Description1, Description2 = myProfile.Description2 }; 
            
            var msg = new { success = true };

            string processedHtml = PartialViewUtility.RenderPartialToString("_partial_article_messenger_post", messengerPost, ControllerContext);

            var context = GlobalHost.ConnectionManager.GetHubContext<Notifier>();
            string[] excluded = null;
            var result = new {success=true, processedHtml = processedHtml };
            context.Clients.Group(chatRoom, excluded).NewMessengerPostReceived(result);

            return Json(msg);
        }

    }
}
