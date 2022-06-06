using Hand2TradeAP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabs : ContentPage
    {
        public Tabs()
        {
            
            InitializeComponent();
           
        }

        void MyTab1_TabTapped(System.Object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();          
            ((ProfileViewModel)tabView1.TabItems[2].Content.BindingContext).RefreshCommand.Execute(null);
            ((ChatGroupsViewModel)tabView1.TabItems[1].Content.BindingContext).RefreshCommand.Execute(null);
            ((MarketViewModel)tabView1.TabItems[0].Content.BindingContext).RefreshCommand.Execute(null);
        }

    }
}