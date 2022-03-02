using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Models;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        public ItemPage(Item item)
        {
            ItemPageViewModel context = new ItemPageViewModel(item);           
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}