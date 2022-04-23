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
using System.Collections.ObjectModel;

namespace Hand2TradeAP.ViewModels
{
    class ItemPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private string itemName;
        public string Itemname
        {
            get { return itemName; }
            set
            {
                itemName = value;
                OnPropertyChanged("Itemname");
            }
        }
        private User itemUser;
        public User ItemUser
        {
            get { return itemUser; }
            set
            {
                itemUser = value;
                OnPropertyChanged("ItemUser");
            }
        }

        private ImageSource itemImage;
        public ImageSource ItemImage
        {
            get { return itemImage; }
            set
            {
                itemImage = value;
                OnPropertyChanged("ItemImage");
            }
        }
        private double rate;
        public double Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        public ICommand ToOwner => new Command(ToOwnerPage);
        async void ToOwnerPage()
        {
           
            await App.Current.MainPage.Navigation.PushModalAsync(new OwnerPage(ItemUser));
            
        }
        public Command CreateGroupCommand => new Command(CreateGroup);
        private async void CreateGroup()
        {
          
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            App theApp = (App)Application.Current;
            User u = theApp.CurrentUser;
            TradeChat c = new TradeChat()
            {
                Buyer = u,
                BuyerId = u.UserId,
                Seller = ItemUser,
                SellerId = ItemUser.UserId,
                Item = Item,
                ItemId = Item.ItemId,
                IsTradeAgreed = false,
            };
            TradeChat returnedGroup = await proxy.CreateGroup(c);

  
            if (returnedGroup != null)
            {
                //await App.Current.MainPage.Navigation.PushModalAsync(new ChatView());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again later.", "OK");
            }
            
        }
        public ItemPageViewModel(Item item)
        {
            Price = item.Price.ToString();
            Item = item;
            Description = item.Desrciption;
            Itemname = item.ItemName;
            ItemImage = item.ImgSource;
            ItemUser = item.User;
            if (item.User.CountRanked != 0)
                Rate = (item.User.SumRanks / item.User.CountRanked);
            else
                Rate = 0;


        }
        private Item Item;
    }
    
}
