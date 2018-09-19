using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SignalRApp
{

    public class User
    {
        public string ConId { get; set; }
        public string UserName { get; set; }
    }


    public class ChatHub : Hub
    {

        public static List<User> AllConnectedUsers = new List<User>();


        public void SendMessage(string username, string message)
        {
            Clients.All.MessageReceived(username, message);
        }

        public override Task OnConnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"], "Bağlandı!");
            
            string conId = Context.ConnectionId;
            AllConnectedUsers.Add(new User { ConId = conId, UserName = Context.QueryString["username"] });
            Clients.All.UserReceived(AllConnectedUsers);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.MessageReceived(Context.QueryString["username"], "Bağlantı Kesildi!");

            string conId = Context.ConnectionId;
            AllConnectedUsers.Remove(AllConnectedUsers.Where(x => x.ConId == conId).FirstOrDefault());
            Clients.All.UserReceived(AllConnectedUsers);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"], "Yeniden Bağlandı!");

            string conId = Context.ConnectionId;
            User user = AllConnectedUsers.Where(x => x.ConId == conId).FirstOrDefault();
            AllConnectedUsers.Remove(AllConnectedUsers.Where(x => x.ConId == conId).FirstOrDefault());
            AllConnectedUsers.Add(user);

            return base.OnReconnected();
        }
    }
}