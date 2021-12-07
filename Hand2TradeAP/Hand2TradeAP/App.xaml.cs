using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Views;
using Hand2TradeAP.Models;

namespace Hand2TradeAP
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }

        //The current logged in user
        public User CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();
            CurrentUser = null;
            MainPage = new Tabs();
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
