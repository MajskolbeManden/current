using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.Models;
using client.Services;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace client.ViewModels
{
    public class MainViewModel
    {
        private ChatService chatservice = new ChatService();
        public ObservableCollection<ChatMessage> ChatList { get; private set; }

        private ChatMessage cm;
        public ChatMessage Cm
        {
            get { return cm; }
            set
            {
                cm = value;
                OnPropertyChanged(nameof(Cm));
            }
        }

        public MainViewModel()
        {
            
            cm = new ChatMessage();
            ChatList = new ObservableCollection<ChatMessage>();
            ChatList.Add(new ChatMessage { LineOne = "grete" });
            ChatList.Add(new ChatMessage { LineOne = "grete" });
            ChatList.Add(new ChatMessage { LineOne = "nigger" });
            ChatList.Add(new ChatMessage { LineOne = "fugg:DD" });
            ChatList.Add(new ChatMessage { LineOne = "faggot" });
            ChatList.Add(new ChatMessage { LineOne = chatservice.Connection.State.ToString() });

            
            chatservice.Connect();
            chatservice.OnMessageReceived += chatservice_OnMessageReceived;
        }

        private void chatservice_OnMessageReceived(object sender, ChatMessage e)
        {
            ChatList.Add(new ChatMessage { LineOne = e.LineOne });
        }

        #region Property of datatype PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method to handle updating the view

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
