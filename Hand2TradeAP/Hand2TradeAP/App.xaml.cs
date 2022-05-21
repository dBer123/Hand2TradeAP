using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.Views;
using Hand2TradeAP.Models;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace Hand2TradeAP
{
    public partial class App : Application
    {
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQyNzQ1QDMyMzAyZTMxMmUzMFpFUThUN0laUzQzQ2VtcS9UTXF6Z3hQU3hwUXRDL29xOGxlTWlQZEtYTms9");
            CurrentUser = null;
            MainPage = new WebData();
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
