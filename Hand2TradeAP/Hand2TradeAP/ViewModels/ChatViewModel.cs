using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Hand2TradeAP.Services;
using Hand2TradeAP.Models;
using System.Linq;
using Hand2TradeAP.Views;
using System.Collections.ObjectModel;

namespace Hand2TradeAP.ViewModels
{
    internal class ChatViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private int chatId;
        private ChatService chatService;
        private Hand2TradeAPIProxy proxy;
        public ChatViewModel(int chatId, ChatService chatService)
        {
            this.chatId = chatId;
            this.chatService = chatService;
            this.proxy = Hand2TradeAPIProxy.CreateProxy();

            InitializeHub();
            LoadGroup();
        }

        public async void InitializeHub()
        {
            try
            {
                //chatService.ReceiveMessage(GetMessage);
                //await chatService.Connect();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public Command SendMsgCommand => new Command(SendMsg);
        private void SendMsg()
        {
            string text = Message;
            if (text != null)
            {
                Message = "";
                TextMessage message = new TextMessage()
                {
                    SenderId = CurrentAccount.UserId,
                    ChatId = chatId,
                    TextMessage1 = text,
                    SentTime = DateTime.Now,
                    Sender = CurrentAccount
                };

                chatService.SendMessage(message.SenderId.ToString(), message.TextMessage1);
                AddMessage(message);
            }
        }

        private void GetMessage(MsgDTO message)
        {
            if (message != null)
            {
                AddMessage(new TextMessage()
                {
                    SenderId = message.SenderId,
                    SentTime = message.SentTime,
                    TextMessage1 = message.TextMessage1,
                    Sender = message.Sender,
                    ChatId = message.ChatId,
                    Chat = message.Chat
                });
            }
        }

        private void AddMessage(TextMessage message)
        {
            Messages.Insert(0, message);
        }

        private async void LoadGroup()
        {
            Group = await proxy.GetGroup(chatId);

            Messages = new ObservableCollection<TextMessage>((from msg in Group.TextMessages orderby msg.SentTime descending select msg));
           
            CurrentAccount = ((App)App.Current).CurrentUser;
            MessagesLoaded?.Invoke();
        }
        private async void GetGroups()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            IEnumerable<TradeChat> userGroups = await proxy.GetGroups();
            Groups.Clear();
            foreach (TradeChat chat in userGroups)
            {
                chat.LastMessage = chat.TextMessages.OrderByDescending(m => m.SentTime).FirstOrDefault();
                Groups.Add(chat);
            }
        }



        private TradeChat group;
        public TradeChat Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
           
        }

        private Item tradedItem;
        public Item TradedItem
        {
            get => tradedItem;
            set
            {
                tradedItem = value;
                OnPropertyChanged("TradedItem");
            }
        }

        private ObservableCollection<TextMessage> Messages;

        private ObservableCollection<TradeChat> Groups;

        private User currentAccount;
        public User CurrentAccount
        {
            get => currentAccount;
            set
            {
                currentAccount = value;
                OnPropertyChanged("CurrentAccount");
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public Action MessagesLoaded;
    }
}

