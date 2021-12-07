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
            context.NavigateToPageEvent += NavigateToAsync;
            this.BindingContext = context;
            InitializeComponent();

        }

        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }

        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            //When ever item is clicked then we are navigating to the details page
        //    var myselecteditem = e.Item as PageItem;
        //    switch (myselecteditem.Id)
        //    {
        //        case 1:
        //            await Navigation.PushAsync(new  EditProfile());
        //            break;

        //    }
        //    ((ListView)sender).SelectedItem = null;
  
        }

        void OnRightButtonClicked(object sender, EventArgs e)
            => SideMenuView.State = SideMenuState.RightMenuShown;

        private void navigationDrawerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}

public class PageItem
{
    public PageItem()
    {
        TargetType = typeof(PageItem);
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
    public Type TargetType { get; set; }
}