using client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    interface IChatService
    {
        Task Connect();
        event EventHandler<ChatMessage> OnMessageReceived;
        Task Send(ChatMessage message);
    }
}
