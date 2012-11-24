
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace FHNWPrototype.UI.Web.MVC.Signals
{
    [Serializable]
    public class Notification
    {
        public string Group { get; set; }
        public string Message { get; set; }
    }

    [HubName("notifier")]
    public class Notifier : Hub
    {

        //public void Broadcast(dynamic data)
        //{
        //    var notification = new { message = data.message, group = data.group, sender = data.sender };
        //    Clients.All.Notify(notification);
        //}

        public void NotifyMyNewPostToEveryone(Notification data)
        {
            //var notification = new { key = data.key, group = data.group };
            string[] excludeList = new string[] {  };
            string groupName = data.Group;
            string postKey = data.Message;
            Clients.Group(groupName, excludeList).NewPostReceived(postKey);
        }

        public void NotifyMyNewCommentToEveryone(Notification data)
        {
            //var notification = new { key = data.key, group = data.group };
            string[] excludeList = new string[] {  };
            string commentKey = data.Message;
            string groupName = data.Group;
            Clients.Group(groupName, excludeList).NewCommentReceived(commentKey);
        }

        public void SuscribeMe(string group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        public void UnSuscribeMe(string group)
        {
            Groups.Remove(Context.ConnectionId, group);
        }

    }
}