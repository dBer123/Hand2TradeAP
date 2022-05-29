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
using System.Windows.Input;

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
        private Item item;

        public Item Item
        {
            get => item;
            set
            {
                item = value;
                OnPropertyChanged("Item");
            }
        }
        private bool isSeller;

        public bool IsSeller
        {
            get => isSeller;
            set
            {
                isSeller = value;
                OnPropertyChanged("IsSeller");
            }
        }

        public ObservableCollection<TextMessage> Messages { get; set; }
        //Declare the chat service to be allive as long as the chat view is on!
        //In other cases the live connection should be alive while the app in on
        //in such cases it will be declared in the App class
        private IChatService chatService;
        private User user;
        //private User chatMember;
        public ObservableCollection<string> Groups { get; set; }
        public ChatViewModel(TradeChat chat, ChatService chatService)
        {
            Group = chat;
            Messages = new ObservableCollection<TextMessage>();
            foreach (TextMessage textMessage in chat.TextMessages)
            {
                Messages.Add(textMessage);
            }
            Groups = new ObservableCollection<string>();
            App app = (App)Application.Current;
            user = app.CurrentUser;
            Item = chat.Item;
            if (user == chat.Buyer)
            {
                IsSeller = false;
            }
            else
            {
                IsSeller = true;
            }
            this.chatService = chatService;
            chatService.RegisterToReceiveMessage(ReceiveMessage);
            Message = String.Empty;
            //ConnectToChatService();
        }

        private async void ConnectToChatService()
        {
            //connect to server and register to all groups
            await chatService.Connect(Groups.ToArray());
        }
        private void ReceiveMessage(string sender, string receiver, string chatId, string message)
        {
            if (user.UserId.ToString().Equals(receiver))
            {
                TextMessage chatMessage = new TextMessage()
                {
                    SenderId = int.Parse(sender),
                    ChatId = int.Parse(chatId),
                    TextMessage1 = message,
                    SentTime = DateTime.Now,
                };
                Messages.Add(chatMessage);
            }
        }

        private void ReceiveMessageFromGroup(string userId, string message, string groupName)
        {
            TextMessage chatMessage = new TextMessage()
            {
                SenderId = int.Parse(userId),
                TextMessage1 = Message,
                SentTime = DateTime.Now,
                ChatId = int.Parse(groupName)
            };

            //if (chatMessage.UserId == user.Email)
            //    chatMessage.Recieved = false;
            Messages.Add(chatMessage);

        }

        public ICommand SendMessage => new Command(OnSendMessage);
        public async void OnSendMessage()
        {
            TextMessage message = new TextMessage()
            {
                SenderId = this.user.UserId,
                TextMessage1 = this.Message,
                SentTime = DateTime.Now,
                ChatId = this.Group.ChatId,
            };
            Messages.Add(message);
            Message = String.Empty;
            string receiver;
            if (Group.BuyerId == this.user.UserId)
                receiver = Group.SellerId.ToString();
            else
                receiver = Group.BuyerId.ToString();
            await chatService.SendMessage(user.UserId.ToString(), receiver,message.ChatId.ToString(), message.TextMessage1);
        }
        public ICommand ToItem => new Command<Object>(ToItemPage);
        async void ToItemPage(Object obj)
        {
            if (obj is Item)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ItemPage((Item)obj));
            }
        }
        public ICommand Sell => new Command(SellItem);
        private void SellItem()
        {

        }
        public ICommand Regect => new Command(RegectTrade);
        private void RegectTrade()
        {

        }
    }
}

    


