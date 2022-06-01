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
            if (tabView1.TabItems[2].IsSelected)
                ((ProfileViewModel)tabView1.TabItems[2].Content.BindingContext).RefreshCommand.Execute(null);
            if (tabView1.TabItems[1].IsSelected)
            ((ChatGroupsViewModel)tabView1.TabItems[1].Content.BindingContext).RefreshCommand.Execute(null);
        }

    }
}