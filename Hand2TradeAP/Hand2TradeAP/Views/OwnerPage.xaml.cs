using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.Models;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnerPage : ContentPage
    {
        public OwnerPage(User owner)
        {
            OwnerPageViewModel context = new OwnerPageViewModel(owner);
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}