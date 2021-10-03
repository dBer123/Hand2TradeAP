using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Views;

namespace Hand2TradeAP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new EnterPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
