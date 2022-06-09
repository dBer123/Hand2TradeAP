using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Hand2TradeAP.Services;
using Hand2TradeAP.Views;
using Hand2TradeAP.Models;
using Xamarin.Essentials;
using System.Linq;
using Hand2TradeAP.AppFonts;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Cards;


namespace Hand2TradeAP.ViewModels
{
    class ProfileViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private ImageSource imageU;
        public ImageSource ImageU
        {
            get { return imageU; }
            set
            {
                imageU = value;
                OnPropertyChanged("ImageU");
            }
        }
        private string coins;
        public string Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged("Coins");
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private double rating;
        public double Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }

        private string isAdmin;
        public string IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }
        public ObservableCollection <string> Stars { get; set; }
        public ObservableCollection <Item> MyItems { get; set; }
        public List<PageItem> MenuItems { get; set; }

        public ProfileViewModel()
        {
            MyItems = new ObservableCollection<Item>();

            Stars = new ObservableCollection<string>();
            App theApp = (App)Application.Current;
            Profile(theApp.CurrentUser);
            

        }
        public void Profile(User CurrentUser)
        {
            Email = CurrentUser.Email;
            Coins = CurrentUser.Coins.ToString();
            Address = CurrentUser.Adress;
            Username = CurrentUser.UserName;
            double sum = CurrentUser.SumRanks;
            int count = CurrentUser.CountRanked;
            if (sum != 0)
            {
                Rating = sum / count;
                double num = sum / count - Rating;
                if (num > 0.5) Rating += 1;
            }

            ImageU = CurrentUser.ImgSource == null ? "profile.png" : CurrentUser.ImgSource;
            //if (theApp.CurrentUser.ImgSource == null)
            //    ImageU = "profile.png";
            //else
            //    ImageU = theApp.CurrentUser.ImgSource;
            MyItems.Clear();
            foreach (var item in CurrentUser.Items)
            {
                MyItems.Add(item);
            }


            string icon1 = AppFonts.FontIconClass.Pencil;
            string icon2 = AppFonts.FontIconClass.PlusThick;
            string icon3 = AppFonts.FontIconClass.Heart;
            string icon4 = AppFonts.FontIconClass.Graph;
            string icon5 = AppFonts.FontIconClass.AccountCheck;
            string icon6 = AppFonts.FontIconClass.Logout;

            double count2 = Rating;
            for (int i = 0; i <= 5; i++)

            {
                if (count2 >= 0.75)
                    Stars.Add(AppFonts.FontIconClass.Star);
                else if (count2 > 0.25 && count2 < 0.75)
                    Stars.Add(AppFonts.FontIconClass.StarHalfFull);
                else Stars.Add(AppFonts.FontIconClass.StarOutline);
                count2--;
            }


            if (CurrentUser.IsAdmin)
            {

                MenuItems = new List<PageItem>(new[]
                   {
                    new PageItem { Id = 1, Title = "Edit Profile", Icon=icon1},
                    new PageItem { Id = 2, Title = "Add Item", Icon=icon2},
                    new PageItem { Id = 3, Title = "Liked Items", Icon=icon3},
                    new PageItem { Id = 4, Title = "Web Data", Icon=icon4},
                    new PageItem { Id = 5, Title = "Accounts", Icon=icon5},
                    new PageItem { Id = 6, Title = "Log Out", Icon=icon6}

                });
                IsAdmin = AppFonts.FontIconClass.CheckCircle;
            }
            else
            {

                MenuItems = new List<PageItem>(new[]
                   {
                    new PageItem { Id = 1, Title = "Edit Profile", Icon=icon1},
                    new PageItem { Id = 2, Title = "Add Item", Icon=icon2},
                    new PageItem { Id = 3, Title = "Liked Items", Icon=icon3},
                    new PageItem { Id = 6, Title = "Log Out", Icon=icon6}

                });
                IsAdmin = " ";
            }
        }
        public ICommand RefreshCommand => new Command(async () =>
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            Profile(await proxy.GetLoggedUser());
        });

        public ICommand Choose => new Command<Object>(ChooseAction);
        public async void ChooseAction(Object obj)
        {
            string s = await App.Current.MainPage.DisplayActionSheet("Item Actions:",null,"CANCEL", "Edit Item", "Delete Item");
            if (s == "Edit Item")
                GoEditItem(obj);
            else if (s == "Delete Item") DeleteItem(obj);
        }
        public async void DeleteItem(Object obj)
        {
            bool f = await App.Current.MainPage.DisplayAlert("Be Careful!", "Are you sure you want to delete this item?", "DELETE", "CANCEL");

            if (obj is SfCardLayout)
            {
                if (f == true)
                {
                    Item item = MyItems[((SfCardLayout)obj).VisibleCardIndex];
                    item.User = null;
                    App theApp = (App)Application.Current;
                    Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                    bool isDeleted = await proxy.DeleteItem(item);
                    if (isDeleted == true)
                    {
                        theApp.CurrentUser.Items.Remove(item);
                        MyItems.Remove(item);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Can not delete this item", "OK");

                    }
                }
            }
        }
       
        public async void GoEditItem(Object obj)
        {
            if (obj is SfCardLayout)
            {

                Item item = MyItems[((SfCardLayout)obj).VisibleCardIndex];
                Page p = new EditItem(item);
                await App.Current.MainPage.Navigation.PushModalAsync(p);      
            }
        }

        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public async void OnSelectionChanged(Object obj)
        {
            if (obj is PageItem)
            {
                PageItem SelectedItem = (PageItem)obj;

                switch (SelectedItem.Id)
                {
                    case 1:
                        Page p1 = new EditProfile();
                        await App.Current.MainPage.Navigation.PushModalAsync(p1);
                        
                        break;
                    case 2:
                        Page p2 = new AddItem();
                        await App.Current.MainPage.Navigation.PushModalAsync(p2);
                        break;
                    case 3:
                        Page p3 = new LikedItems();
                        await App.Current.MainPage.Navigation.PushModalAsync(p3);
                        break;
                    case 4:
                        Page p4 = new WebDataTabs();
                        await App.Current.MainPage.Navigation.PushModalAsync(p4);
                        break;
                    case 5:
                        Page p5 = new Accounts();
                        await App.Current.MainPage.Navigation.PushModalAsync(p5);
                        break;
                    case 6:
                        Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                        bool found = await proxy.LogOut();
                        if (found)
                        {
                            App theApp = (App)Application.Current;
                            theApp.CurrentUser = null;
                            Page p6 = new LogInPage();
                            App.Current.MainPage = p6;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Could not log out", "OK");
                        }
                        break;
                }

            }
        }

       
    }

    public class PageItem
    {
        public PageItem()
        {
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }


}
