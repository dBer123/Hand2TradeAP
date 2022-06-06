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
    public partial class MarketView : ContentView
    {
        public MarketView()
        {
            MarketViewModel context = new MarketViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }

        private void searchedItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
               searchedItems.SelectedItem = null;
        }
    }
}