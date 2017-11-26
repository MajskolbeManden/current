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
        Task Send();
        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
