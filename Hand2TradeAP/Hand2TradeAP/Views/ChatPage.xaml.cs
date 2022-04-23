using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Services;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage(int chatId, ChatService chatService)
        {
            ChatViewModel context = new ChatViewModel(chatId, chatService);
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}