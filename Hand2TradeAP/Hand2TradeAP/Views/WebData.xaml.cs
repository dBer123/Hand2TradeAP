using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.ViewModels;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebData : ContentPage
    {
        public WebData()
        {
            WebDataViewModel context = new WebDataViewModel();
            this.BindingContext = context;
            InitializeComponent();
            
            

        }
    }
}