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

        public ImageSource ItemImage { get; set; }

        //The current logged in user
        public User CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();
            ItemImage = null;
            CurrentUser = null;
            MainPage = new AddItem();
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
