using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.ViewModels;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LikedItems : ContentPage
    {
        public LikedItems()
        {
            LikedItemsViewModel context = new LikedItemsViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}