
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using FHNWPrototype.Domain._Base.Accounts;
using FHNWPrototype.Application.Services.Simple;
using FHNWPrototype.Application.Controllers.UIViewModels._Global;
using FHNWPrototype.Application.Services.Simple.ServicesViewModels;
using System.Web.Mvc;

namespace FHNWPrototype.UI.Web.MVC.Signals
{
    [Serializable]
    public class Notification
    {
        public string Group { get; set; }
        public string Message { get; set; }
    }

    [Microsoft.AspNet.SignalR.Hubs.Authorize]
    [HubName("notifier")]
    public class Notifier : Hub
    {
        
        public void Broadcast(dynamic data)
        {
            var notification = new { message = data.message, group = data.group, sender = data.sender };
            Clients.All.Notify(notification);
        }

        //public void NotifyMyNewPostToEveryone(string processedHtml)
        //{
        //    //var notification = new { key = data.key, group = data.group };
        //    string[] excludeList = new string[] {  };
        //    string groupName = data.Group;
        //    string postKey = data.Message;
        //    Clients.Group(groupName, excludeList).NewPostReceived(processedHtml);
        //}

        //public void NotifyMyNewCommentToEveryone(Notification data)
        //{
        //    //var notification = new { key = data.key, group = data.group };
        //    string[] excludeList = new string[] {  };
        //    string commentKey = data.Message;
        //    string groupName = data.Group;
        //    Clients.Group(groupName, excludeList).NewCommentReceived(commentKey);
        //}

        public override System.Threading.Tasks.Task OnConnected()
        {
            //CompleteProfile myProfile = (CompleteProfile) HttpContext.Current.Session["myProfile"];
            //CompleteProfileViewModel profile =  SecurityService.GetCompleteProfileFromUserId(Context.User.Identity.Name);
            SignalRState.RegisterConnection(Context.User.Identity.Name , Context.ConnectionId );
            var msg = new { success = true, email = Context.User.Identity.Name };
            //string[] excluded = new string[] { Context.User.Identity.Name};
            //return Clients.AllExcept(excluded).UserConnected(msg);
            //return base.OnConnected();
            Groups.Add(Context.ConnectionId, "A0000001-B002-C003-D004-E00000000005");
            return Clients.Others.UserConnected(msg);

        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
           //CompleteProfile myProfile = (CompleteProfile) HttpContext.Current.Session["myProfile"];

            //var emailOfDisconnectedUser = SignalRState.GetAllConnections().FirstOrDefault(x => x.Value == Context.ConnectionId).Key;

            var profile = SecurityService.GetCompleteProfileFromUserEmail(Context.User.Identity.Name);

            SignalRState.UnregisterConnection(Context.User.Identity.Name);

            var msg = new { success=true, userKey=profile.BasicProfile.ReferenceKey.ToString() };

            return Clients.Others.Disconnected(msg);
           // return base.OnDisconnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            //CompleteProfile myProfile = (CompleteProfile)HttpContext.Current.Session["myProfile"];

            SignalRState.RegisterConnection(Context.User.Identity.Name, Context.ConnectionId);

            return Clients.All.Reconnected(Context.User.Identity.Name);

           // return base.OnReconnected();
        }

        public void SuscribeMe(string group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        public void Suscribe(string connectionId, string group)
        {
            Groups.Add(connectionId, group);
        }

        public void UnSuscribeMe(string group)
        {
            Groups.Remove(Context.ConnectionId, group);
        }

    }
}