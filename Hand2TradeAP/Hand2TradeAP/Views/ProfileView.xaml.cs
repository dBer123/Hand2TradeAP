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
    public partial class ProfileView : ContentView
    {

      

        public ProfileView()
        {

            ProfileViewModel context = new ProfileViewModel();
            this.BindingContext = context;
            InitializeComponent();

        }

       

       

        void OnRightButtonClicked(object sender, EventArgs e)
            => SideMenuView.State = SideMenuState.RightMenuShown;

        private void navigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}

