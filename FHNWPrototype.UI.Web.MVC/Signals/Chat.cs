
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using FHNWPrototype.Domain._Base.Accounts;
using System.IO;

namespace FHNWPrototype.UI.Web.MVC.Signals
{

    public class BroadcastNotification
    {
        public String AuthorKey { get; set; }
        public String AuthorName { get; set; }
        public String Message { get; set; }
        public String DateTime { get; set; }
    }

    [HubName("chat")]
    public class Chat : Hub
    {
        public void Broadcast(string processedHtml)
        {
            //var notification = new { message = data.message, group = data.group, sender = data.sender };

            //string message = "<div><b>" + notification.Date + " - " + notification.Author + " said: </b>" + notification.Message + "</div>";


            //UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            //var httpContext = HttpContext.Current;

            //if (httpContext == null)
            //{
            //    var request = new HttpRequest("/", "http://localhost:1379/", "");
            //    var response = new HttpResponse(new StringWriter());
            //   // httpContext = new HttpContext(request, response);
            //    httpContext = new HttpContext(HttpContext.Current.Request, response);
            //}
            
            //var httpContextBase = new HttpContextWrapper(httpContext);
            //var routeData = new RouteData();
            //var requestContext = new RequestContext(httpContextBase, routeData);

            //UrlHelper url2 = new UrlHelper(requestContext);

            //UrlHelper url3 = new UrlHelper();
           
            //StringBuilder newMessage = new StringBuilder();

            //newMessage.AppendLine(@"<article class=""post"">");
            //newMessage.AppendLine(@"<img src=""" + url2.Action("GetAvatarPictureByBasicProfile", "Retriever", new { key = notification.AuthorKey , accountType =AccountType.UserAccount }) + @""" alt=""picture""  class=""profile_picture_post"" />");
            //newMessage.AppendLine("<h2>" + notification.AuthorName + "</h2>" );
            //newMessage.AppendLine("<p>" + notification.Message + "</p>" );
            //newMessage.AppendLine(@"<nav class=""actionlinks""><ul><li>" + notification.DateTime + "</li></ul></nav>" );
            //newMessage.AppendLine("</article>");

            Clients.All.Received(processedHtml);
        }

        //public void BroadcastToGroup(dynamic data)
        //{
        //    var notification = new { message = data.message, group = data.group, sender = data.sender };
        //    string[] excludeList = new string[] { };
        //    string groupName = notification.group;
        //    Clients.Group(groupName, excludeList).Send(notification);
        //}

        public void SuscribeMe(dynamic group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        public void UnSuscribeMe(string group)
        {
            Groups.Remove(Context.ConnectionId, group);
        }
    }
}