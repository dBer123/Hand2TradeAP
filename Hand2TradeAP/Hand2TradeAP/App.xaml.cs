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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU5NDE1QDMxMzkyZTM0MmUzMGIvSWRjT2RaMWNDdnZ5QzJvbzI1SlIySmNSQjFPbDdSRlhTRFN5NWRJSTA9");
            CurrentUser = null;
            MainPage = new MakeLoan();
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
