using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            RegisterViewModel context = new RegisterViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}