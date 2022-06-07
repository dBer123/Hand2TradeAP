using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            RegisterViewModel context = new RegisterViewModel();
            this.BindingContext = context;
            context.SetImageSourceEvent += OnSetImageSource;

            InitializeComponent();
        }
        private void ToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopUpAddImage(this.BindingContext));


        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            profileImage.Source = imgSource;

        }
    }
}