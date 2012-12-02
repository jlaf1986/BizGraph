using FHNWPrototype.Domain._Base.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



/// <summary>
/// Contains my site's global variables.
/// </summary>

namespace FHNWPrototype.UI.Web.MVC
{

    public class ConnectionProfile
    {
        //public CompleteProfile Profile { get; set; }
        public String UserId { get; set; }
        public String ConnectionId { get; set; }
    }

    public static class SignalRState
    {
        //private static List<CompleteProfile> _connectedUsers = new List<CompleteProfile>();
        //user,connectionId
        private static Dictionary<String, String> _connectedUsers = new Dictionary<String, String>();

        public static string GetConnectionByUserId(string userId)
        {
            return _connectedUsers[userId];
        }

        public static string GetUserByConnectionId(string connectionId)
        {
            return _connectedUsers.FirstOrDefault(x => x.Value == connectionId).Key;
        }

        public static void RegisterConnection(string userId, string connectionId)
        {
            //  bool success = false;

            if (!_connectedUsers.ContainsKey(userId))
            {
                _connectedUsers.Add(userId, connectionId);
            }
            else
            {
                _connectedUsers[userId] = connectionId;
            }


            // return success;
        }

        public static void UnregisterConnection(string userId)
        {
            if (_connectedUsers.ContainsKey(userId))
            {
                _connectedUsers.Remove(userId);
            }
        }

        public static Dictionary<String,String> GetAllConnections()
        {
            //List<CompleteProfile> allProfiles = new List<CompleteProfile>();
            //foreach (var key in _connectedUsers)
            //{
                
            //}
            return _connectedUsers;
        }


    }
}