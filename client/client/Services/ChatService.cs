﻿using client.Models;
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
            await connection.Start();
            proxy.On("newMessage", (string lineOne) => OnMessageReceived(this, new ChatMessage
            {
                LineOne = lineOne
            }));
        }


        public async Task Send(ChatMessage message)
        {
            await proxy.Invoke("SendMessage", message.LineTwo);
        }
    }
}
