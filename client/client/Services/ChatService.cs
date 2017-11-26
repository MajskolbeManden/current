using client.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace client.Services
{
    class ChatService : IChatService
    {
        private readonly HubConnection connection;
        private readonly IHubProxy proxy;

        public event EventHandler<ChatMessage> OnMessageReceived;

        public ChatService()
        {
            
            connection = new HubConnection("http://sameh.webdesk-dev.dk/");
            proxy = connection.CreateHubProxy("chat");
            
        }

        public async Task Connect()
        {
            //var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //await connection.Start().ContinueWith(task =>
            //{
            //    var ex = task.Exception.InnerExceptions[0];
            //    App.ViewModel.ChatList.Add(new ChatMessage { LineOne = ex.Message });
            //},
            //    CancellationToken.None,
            //    TaskContinuationOptions.OnlyOnFaulted,
            //    scheduler);


            //var dialog = new MessageDialog();
            await connection.Start();
            proxy.On("newMessage", (string lineOne) => OnMessageReceived(this, new ChatMessage
            {
                LineOne = lineOne
            }));
            //proxy.On<string>("newMessage", msg =>
            //{
            //    ChatMessage tmp = new ChatMessage();
            //    tmp.LineOne += string.Format(msg);
            //    App.ViewModel.ChatList.Add(tmp);
            //});
        }

        public Task Send()
        {
            throw new NotImplementedException();
        }
    }
}
