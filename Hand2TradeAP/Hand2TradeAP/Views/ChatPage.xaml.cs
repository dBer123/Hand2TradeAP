using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Services;
using Hand2TradeAP.Models;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage(TradeChat chat, ChatService chatService)
        {
            ChatViewModel context = new ChatViewModel(chat);
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}